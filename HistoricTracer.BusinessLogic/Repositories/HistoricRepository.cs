using HistoricTracer.DataAccess.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricTracer.BusinessLogic.Repositories
{
    public class HistoricRepository: IHistoricRepository
    {
        private readonly IMongoDatabase _databases;

        public HistoricRepository(IMongoDatabase mongoDatabase)
        {
            _databases = mongoDatabase;
        }

        public async Task<IEnumerable<HistorizationActions>> FetchAllHistoricAsync(CancellationToken cancellationToken)
        {
            var historizationActions = await _databases.GetCollection<HistorizationActions>("HistorizationActions").AsQueryable().ToListAsync();
            return historizationActions;
        }


        public async Task<HistorizationActions> FetchOneHistoricAsync(string id, CancellationToken cancellationToken)
        {
            var historic = await _databases.GetCollection<HistorizationActions>("HistorizationActions").Find(x => x.Id == id).FirstOrDefaultAsync();
            return historic;
        }

        public async Task SaveHistorizationAsync(HistorizationActions historizationActions, CancellationToken cancellationToken)
        {
            await _databases.GetCollection<HistorizationActions>("HistorizationActions").InsertOneAsync(historizationActions);
        }
    }
}
