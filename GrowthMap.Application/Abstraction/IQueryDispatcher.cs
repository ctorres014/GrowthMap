namespace GrowthMap.Application.Abstraction
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query);
    }
}
