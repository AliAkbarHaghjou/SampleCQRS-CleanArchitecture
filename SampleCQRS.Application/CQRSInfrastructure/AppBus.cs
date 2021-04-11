using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCQRS.Application.CQRSInfrastructure
{
    public class AppBus
    {
        public readonly ServiceProvider serviceProvider;

        public AppBus(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = serviceProvider.GetService<ICommandHandler<TCommand>>();
            commandHandler.Handle(command);
        }
        public async Task SendCommandAsyn<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = serviceProvider.GetService<ICommandHandler<TCommand>>();
            await commandHandler.HandleAsync(command);
        }

        public TResult SendQuery<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
            return queryHandler.Handle(query);
        }
        public Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
            return queryHandler.HandleAsync(query);
        }
    }
}
