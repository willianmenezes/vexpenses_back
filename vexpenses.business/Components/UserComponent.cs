using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using vexpenses.business.Security;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;
using vexpenses.library.Models;

namespace vexpenses.business.Components
{
    public class UserComponent
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;
        private Pessoa baseUser;


        public UserComponent(IUserRepository userRepository,
                           IRefreshTokenRepository refreshTokenRepository,
                           SigningConfiguration signingConfiguration,
                           TokenConfiguration tokenConfiguration)
        {
            _userRepository = userRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public object GetByLogin(CredenciaisAcesso credenciais)
        {
            bool credentialsIsValid = false;

            if (credenciais != null && !string.IsNullOrWhiteSpace(credenciais.Usuario))
            {
                baseUser = _userRepository.GetByLogin(credenciais.Usuario);

                if (credenciais.TipoConcessao == "password")
                {
                    //converte em base64
                    var plainTextBytes = Encoding.UTF8.GetBytes(credenciais.Senha);
                    string encodedText = Convert.ToBase64String(plainTextBytes);

                    credenciais.Senha = encodedText;

                    credentialsIsValid = (baseUser != null && credenciais.Usuario == baseUser.Email && credenciais.Senha == baseUser.Senha);

                }
                else if (credenciais.TipoConcessao == "refresh_token")
                {
                    if (!String.IsNullOrWhiteSpace(credenciais.RefreshToken))
                    {
                        RefreshToken refreshTokenBase = _refreshTokenRepository.GetRefreshToken(baseUser.PessoaId);

                        DateTime expirationDate = DateTime.Parse(credenciais.Expiration);
                        expirationDate = expirationDate + TimeSpan.FromSeconds(_tokenConfiguration.FinalExpiration);

                        DateTime atual = DateTime.Now;

                        credentialsIsValid = (refreshTokenBase != null &&
                            baseUser.PessoaId == refreshTokenBase.PessoaId &&
                            refreshTokenBase.Token == credenciais.RefreshToken && expirationDate >= atual);
                    }
                }
            }
            if (credentialsIsValid)
            {
                var userClaim = UserClaim.ConvertEntityToClaim(baseUser);
                var identity = new ClaimsIdentity(
                    new GenericIdentity(userClaim.Email, "Email"),
                        new[]
                        {
                            new Claim(ClaimTypes.Sid, userClaim.PessoaId.ToString()),
                            new Claim(ClaimTypes.Email, userClaim.Email),
                            new Claim(ClaimTypes.NameIdentifier, baseUser.Nome)
                        }
                    );

                DateTime createDate = DateTime.Now.ToUniversalTime();
                DateTime expirationDate = createDate.ToUniversalTime() + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                // Calcula o tempo máximo de validade do refresh token
                // (o mesmo será invalidado automaticamente pelo Redis)
                TimeSpan finalExpiration = TimeSpan.FromSeconds(_tokenConfiguration.FinalExpiration);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token, finalExpiration, baseUser.PessoaId);
            }
            else
            {
                return ExceptionObject();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticado = false
            };
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, TimeSpan finalExpiration, Guid Nidpessoa)
        {
            var resultado = new
            {
                autenticado = true,
                criado = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                refreshToken = Guid.NewGuid().ToString().Replace("-", String.Empty)
            };

            // Armazena o refresh token
            var refreshTokenData = new RefreshToken();
            refreshTokenData.Token = resultado.refreshToken;
            refreshTokenData.PessoaId = Nidpessoa;
            refreshTokenData.Expiracao = finalExpiration.ToString();

            _refreshTokenRepository.SetRefreshToken(refreshTokenData);

            return resultado;
        }
    }
}
