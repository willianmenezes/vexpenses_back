namespace vexpenses.business.Security
{
    public class CredenciaisAcesso
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string RefreshToken { get; set; }

        public string TipoConcessao { get; set; }

        public string Expiration { get; set; }
    }
}
