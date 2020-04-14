using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using vexpenses.library.Models.Response;

namespace vexpenses.business.Components
{
    public class CorreiosComponent
    {
        private readonly RestfullComponent _restfullComponent;
        public CorreiosComponent(RestfullComponent restfullComponent)
        {
            _restfullComponent = restfullComponent;
        }

        public async Task<EnderecoViaCepResponse> BuscarEnderecoPorCep(string cep)
        {

            if (string.IsNullOrWhiteSpace(cep))
            {
                throw new Exception("Cep inválido");
            }

            cep = Regex.Replace(cep, "[^0-9]", "");

            if (cep.Length != 8)
            {
                throw new Exception("Cep inválido");
            }

            var url = $"https://viacep.com.br/ws/{cep}/json/";

            return await _restfullComponent.GetAsync<EnderecoViaCepResponse>(url);
        }
    }
}
