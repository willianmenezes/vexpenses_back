using System;
using System.Collections.Generic;
using System.Text;
using vexpenses.data.IRepositories;

namespace vexpenses.business.Components
{
    public class AgendaContatoComponent
    {
        private readonly IAgendaContatoRepository _agendaContatoRepository;
        public AgendaContatoComponent(IAgendaContatoRepository agendaContatoRepository)
        {
            _agendaContatoRepository = agendaContatoRepository;
        }
    }
}
