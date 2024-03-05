using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarefas.Core.Application.Application.Interface;
using tarefas.Core.Application.Service.Interface;
using tarefas.Core.Domain.Entitys;

namespace tarefas.Core.Application.Application.Implementation
{
    public class HistoricoTarefaApplication : IHistoricoTarefaApplication
    {
        private readonly IHistoricoTarefaService _service;
        public HistoricoTarefaApplication()
        {
            
        }
        public Task<ActionResult> AddAsync(HistoricoTarefa historico)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<HistoricoTarefa>>> GetAllByProjetoAsync(int projetoId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<HistoricoTarefa>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> UpdateAsync(HistoricoTarefa historico)
        {
            throw new NotImplementedException();
        }
    }
}
