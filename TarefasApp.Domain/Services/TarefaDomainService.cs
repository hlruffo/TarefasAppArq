using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Domain.Entities;
using TarefasApp.Domain.Interfaces.Repositories;
using TarefasApp.Domain.Interfaces.Services;

namespace TarefasApp.Domain.Services
{
    public class TarefaDomainService :BaseDomainService<Tarefa, Guid>, ITarefaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarefaDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.TarefaRepository)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Overide para aplicar regras de negocio. Exemplo: não se pode marcar uma tarefa na mesma data e hora em que uma tarefa já esteja marcada;
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public override async Task Add(Tarefa entity)
        {
           await _unitOfWork.TarefaRepository.Add(entity);
           await _unitOfWork.SaveChanges();
        }

        public override async Task Delete(Tarefa entity)
        {
            await _unitOfWork.TarefaRepository.Delete(entity);
            await _unitOfWork.SaveChanges();
        }

        public override async Task Update(Tarefa entity)
        {
            await _unitOfWork.TarefaRepository.Update(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}
