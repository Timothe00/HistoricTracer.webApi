using HistoricTracer.DataAccess.Models;
using HistoricTracer.DataAccess.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricTracer.BusinessLogic.Services
{
    public interface IHistoricService
    {
        Task<IEnumerable<HistoricDto>> GetAllHistoric(CancellationToken cancellationToken);
        Task<HistorizationActions> GetOneHistoric(string id, CancellationToken cancellationToken);
        Task<bool> SaveHistoric(CancellationToken cancellation);
    }
}
