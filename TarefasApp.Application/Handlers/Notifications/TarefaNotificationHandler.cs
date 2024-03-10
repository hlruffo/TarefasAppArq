﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Infra.Storage.Collections;
using TarefasApp.Infra.Storage.Persistence;


namespace TarefasApp.Application.Handlers.Notifications
{
    /// <summary>
    /// Classe para escutar as notificações de tarefas
    /// </summary>
    public class TarefaNotificationHandler : INotificationHandler<TarefaNotification>
    {
        //atributo
        private readonly TarefaPersistence _tarefaPersistence;
        private readonly IMapper _mapper;

        public TarefaNotificationHandler(TarefaPersistence tarefaPersistence, IMapper mapper)
        {
            _tarefaPersistence = tarefaPersistence;
            _mapper = mapper;
        }

        public async Task Handle(TarefaNotification notification, CancellationToken cancellationToken)
        {
            switch (notification.Action)
            {
                case TarefaNotificationAction.TarefaCriada:
                    _tarefaPersistence.Insert(_mapper.Map<TarefaCollection>(notification.Tarefa));
                    break;

                case TarefaNotificationAction.TarefaAlterada:
                    _tarefaPersistence.Update(_mapper.Map<TarefaCollection>(notification.Tarefa));
                    break;

                case TarefaNotificationAction.TarefaExcluida:
                    _tarefaPersistence.Delete(notification.Tarefa.Id.Value);
                    break;
            }

            await Task.CompletedTask;
        }
    }
}



