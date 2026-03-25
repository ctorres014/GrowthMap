using Microsoft.Extensions.DependencyInjection;

namespace GrowthMap.Application.Abstraction
{
    public class CommandDispacher : ICommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispacher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task Dispatch<TCommand>(TCommand command)
        {
            var handler = _provider.GetRequiredService<ICommandHandler<TCommand>>();

            await handler.Handle(command);
        }
    }
}
