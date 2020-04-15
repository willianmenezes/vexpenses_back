using AutoMapper;
using vexpenses.library.Entities;
using vexpenses.library.Models.Response;

namespace Nordisk.Common.SSO.Library.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Agenda, AgendaResponse>();
            CreateMap<TipoAgenda, TipoAgendaResponse>();
            CreateMap<AgendaContato, AgendaContatoResponse>();
            CreateMap<Contato, ContatoResponse>();
            CreateMap<Endereco, EnderecoResponse>();
            CreateMap<Telefone, TelefoneResponse>();
            CreateMap<TipoTelefone, TipoTelefoneResponse>();
        }
    }
}
