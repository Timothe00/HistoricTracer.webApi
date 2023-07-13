using HistoricTracer.DataAccess.Models;

namespace HistoricTracer.BusinessLogic.Repositories
{
    public interface IHistoricRepository
    {
        Task<IEnumerable<HistorizationActions>> FetchAllHistoricAsync(CancellationToken cancellationToken);
        Task<HistorizationActions> FetchOneHistoricAsync(string id, CancellationToken cancellationToken);
        Task SaveHistorizationAsync(HistorizationActions historizationActions, CancellationToken cancellationToken);
    }
}
