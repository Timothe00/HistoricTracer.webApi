using HistoricTracer.BusinessLogic.Repositories;
using HistoricTracer.BusinessLogic.Services;
using HistoricTracer.DataAccess.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HistoricTracer.Test
{
    [TestClass]
    public class HistoricServiceTest
    {
        private Mock<IHistoricRepository> _historicRepository;
        private IHistoricService _historicService;
 

        [TestInitialize]
        public void Initialize()
        {
            _historicRepository = new Mock<IHistoricRepository>();
            _historicService = new HistoricService(_historicRepository.Object);
        }


        [TestMethod]
        public async Task GetAllHistoric_returnAllHistorice()
        {
            //Arrange
            var historic = new List<HistorizationActions>
            {
                new HistorizationActions
                {
                    Id= "1",
                    CollaboratorName = "A",
                    LastAccessed = "24/07/2023",
                    Actions = "Assurco Assurco a validé un nouveau contract de réference:CNT-1822-5225"
                },

                new HistorizationActions
                {
                    Id= "2",
                    CollaboratorName = "B",
                    LastAccessed = "23/07/2023",
                    Actions = "Galo Ba a validé un nouveau contract de réference:CNT-6822-7842"
                }
            };

            //_historicRepository.Setup(x=>x.FetchAllHistoricAsync()).ReturnsAsync(historic);

            //ACT
            //var historicRepository = await _historicService.GetAllHistoric();
            //ASSERT

            //Assert.IsNotNull(historicRepository);
            //Assert.AreEqual(historic, historicRepository);



        }
    }
}
