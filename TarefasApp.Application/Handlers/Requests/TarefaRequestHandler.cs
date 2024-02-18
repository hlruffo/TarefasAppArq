using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Application.Commands;
using TarefasApp.Application.Dtos;
using TarefasApp.Application.Handlers.Notifications;

namespace TarefasApp.Application.Handlers.Requests
{
    public class TarefaRequestHandler :
        IRequestHandler<TarefaCreateCommand, TarefaDto>,
        IRequestHandler<TarefaUpdateCommand, TarefaDto>,
        IRequestHandler<TarefaDeleteCommand, TarefaDto>
    {
        private readonly IMediator _mediator;

        public TarefaRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TarefaDto> Handle(TarefaCreateCommand request, CancellationToken cancellationToken)
        {
            var tarefa = new TarefaDto
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                DataHora = DateTime.Parse($"{request.Data} {request.Hora}"),
                Descricao = request.Descricao,
                Prioridade = (Prioridade)Enum.Parse(typeof(Prioridade), request.Prioridade.ToString())
            };

            //TODO: Gravar os dados no banco de dados

            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefa,
                Action = TarefaNotificationAction.TarefaCriada
            };

            await _mediator.Publish(tarefaNotification);

            return tarefa;
        }

        public async Task<TarefaDto> Handle(TarefaUpdateCommand request, CancellationToken cancellationToken)
        {
            var tarefa = new TarefaDto
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                DataHora = DateTime.Parse($"{request.Data}{request.Hora}"),
                Descricao = request.Descricao,
                Prioridade = (Prioridade)Enum.Parse(typeof(Prioridade), request.Prioridade.ToString())
            };
            //TODO: Atualizar os dados no banco de dados

            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefa,
                Action = TarefaNotificationAction.TarefaAlterada
            };

            await _mediator.Publish(tarefaNotification);
            return tarefa;
        }

        public async Task<TarefaDto> Handle(TarefaDeleteCommand request, CancellationToken cancellationToken)
        {
            var tarefa = new TarefaDto
            {
                Id = request.Id
            };

            //TODO: Gravar os dados no banco de dados

            var tarefaNotification = new TarefaNotification
            {
                Tarefa = tarefa,
                Action = TarefaNotificationAction.TarefaExcluida
            };

            await _mediator.Publish(tarefaNotification);
            return tarefa;
        }
    }
}
