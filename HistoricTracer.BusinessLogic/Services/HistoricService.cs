using HistoricTracer.BusinessLogic.Repositories;
using HistoricTracer.DataAccess.Models;
using HistoricTracer.DataAccess.Models.Dto;
using MongoDB.Driver;

namespace HistoricTracer.BusinessLogic.Services
{
    public class HistoricService : IHistoricService
    {
        private readonly IHistoricRepository _ihistoricRepository;
        private readonly IMongoDatabase _database;
        private IHistoricRepository @object;

        public HistoricService(IMongoDatabase mongoDatabase, IHistoricRepository historicRepository)
        {
            _ihistoricRepository = historicRepository;
            _database = mongoDatabase;
        }

        public HistoricService(IHistoricRepository @object)
        {
            this.@object = @object;
        }

        public async Task<IEnumerable<HistoricDto>> GetAllHistoric(CancellationToken cancellationToken)
        {
            var intermediaries = await _database.GetCollection<Intermediary>("Intermediary")
                                                .AsQueryable().ToListAsync(cancellationToken);
                                          
             var users = await _database.GetCollection<Users>("Users")
                                       .AsQueryable()
                                       .ToListAsync(cancellationToken);

            var contract = await _database.GetCollection<Contract>("Contract")
                                          .AsQueryable().ToListAsync(cancellationToken);


            var histories = from c in contract
                            join inter in intermediaries on c.IntermediaryId equals inter.Id
                            join user in users on inter.Collaborators.FirstOrDefault().UsersId equals user.Id into userGroup
                            from u in userGroup.DefaultIfEmpty()
                            select new HistoricDto
                            {
                                Id = u.Id,
                                Actions = $"{inter.Collaborators.FirstOrDefault().FirstName} " +
                                $"{inter.Collaborators.FirstOrDefault().LastName} " +
                                $"a validé un nouveau contract de réference:{c.PolicyNumber}",

                                CollaboratorName = $"{inter.Collaborators.FirstOrDefault().FirstName} " +
                                $"{inter.Collaborators.FirstOrDefault().LastName}",

                                CorporateName = inter.CorporateName,
                                LastAccessed = u.LastAccessed.ToString().Substring(0,10),

                            };

            return histories;
        }



        public async Task<HistorizationActions> GetOneHistoric(string id, CancellationToken cancellationToken)
        {
            var hist = await _ihistoricRepository.FetchOneHistoricAsync(id, cancellationToken);
            HistorizationActions historizationActions = new HistorizationActions();
            if (hist != null)
            {
                historizationActions.Id = hist.Id;
                historizationActions.CollaboratorName = hist.CollaboratorName;
                historizationActions.CorporateName = hist.CorporateName;
                historizationActions.LastAccessed = hist.LastAccessed;
                historizationActions.Actions = hist.Actions;
                return historizationActions;
            }
            return null;
        }



        public async Task <bool> SaveHistoric(CancellationToken cancellation)
        {
            var results = await this.GetAllHistoric(cancellation);
            foreach (var item in results)
            {
                await _ihistoricRepository.SaveHistorizationAsync(new HistorizationActions
                {

                    CollaboratorName=item.CollaboratorName,
                    LastAccessed=item.LastAccessed.ToString().Substring(0, 10),
                    CorporateName =item.CorporateName,
                    Actions = item.Actions
                }, cancellation);
            }
            return true;
        }
    }
}
