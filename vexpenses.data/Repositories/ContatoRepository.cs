﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using vexpenses.data.Context;
using vexpenses.data.IRepositories;
using vexpenses.library.Entities;

namespace vexpenses.data.Repositories
{
    public class ContatoRepository : BaseRepository, IContatoRepository
    {
        public ContatoRepository(VExpensesContext context) : base(context) { }

        public async Task CadastrarContato(Contato contato, Guid agendaId)
        {
            try
            {
                await _context.Contato.AddAsync(contato);
                await _context.AgendaContato.AddAsync(new AgendaContato { AgendaId = agendaId, ContatoId = contato.ContatoId });
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar contato", ex);
            }
        }
    }
}
