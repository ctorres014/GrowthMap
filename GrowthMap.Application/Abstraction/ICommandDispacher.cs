namespace GrowthMap.Application.Abstraction
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command);
    }
}
