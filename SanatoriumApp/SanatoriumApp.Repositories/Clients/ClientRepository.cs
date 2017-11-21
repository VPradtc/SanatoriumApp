using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.DAL.Clients;
using SanatoriumApp.Domain.Clients;

namespace SanatoriumApp.Repositories.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientsCreateSqlStoredProcedureCommand _createCommand;
        private readonly ClientsGetByIdSqlStoredProcedureQuery _getByIdCommand;
        private readonly ClientsGetByPageSqlStoredProcedureQuery _getByPageCommand;
        private readonly ClientsDeleteSqlStoredProcedureCommand _deleteCommand;
        private readonly ClientsUpdateSqlStoredProcedureCommand _updateCommand;
        private readonly ClientsGetTotalSqlStoredProcedureScalar _getTotalCommand;
        private readonly ClientsGetByPassportSqlStoredProcedureQuery _getByPassportCommand;
        private readonly ClientsGetAllSqlStoredProcedureQuery _getAllCommand;

        public ClientRepository(
            ClientsCreateSqlStoredProcedureCommand createCommand
            , ClientsGetByIdSqlStoredProcedureQuery getByIdCommand
            , ClientsGetByPageSqlStoredProcedureQuery getByPageCommand
            , ClientsGetTotalSqlStoredProcedureScalar getTotalCommand
            , ClientsDeleteSqlStoredProcedureCommand deleteCommand
            , ClientsUpdateSqlStoredProcedureCommand updateCommand
            , ClientsGetByPassportSqlStoredProcedureQuery getByPassportCommand
            , ClientsGetAllSqlStoredProcedureQuery getAllCommand
            )
        {
            _createCommand = createCommand;
            _getByIdCommand = getByIdCommand;
            _getByPageCommand = getByPageCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
            _getTotalCommand = getTotalCommand;
            _getByPassportCommand = getByPassportCommand;
            _getAllCommand = getAllCommand;
        }

        public Task Create(Client Client)
        {
            return _createCommand.ExecuteAsync(Client);
        }

        public async Task<Client> GetById(int id)
        {
            var dbResult = await _getByIdCommand.ExecuteAsync(id);
            return dbResult.FirstOrDefault();
        }

        public async Task<KendoGridResponse<Client>> GetByPage(KendoGridRequest request)
        {
            var records = await _getByPageCommand.ExecuteAsync(request);
            var total = await _getTotalCommand.ExecuteAsync();

            var result = new KendoGridResponse<Client>
            {
                Data = records,
                Total = total,
            };

            return result;
        }

        public async Task Delete(int id)
        {
            await _deleteCommand.ExecuteAsync(id);
        }

        public async Task Update(Client request)
        {
            await _updateCommand.ExecuteAsync(request);
        }

        public async Task<Client> GetByPassport(string passport)
        {
            var dbResult = await _getByPassportCommand.ExecuteAsync(passport);
            return dbResult.FirstOrDefault();
        }

        public async Task<ICollection<Client>> GetAll()
        {
            var dbResult = await _getAllCommand.ExecuteAsync();
            return dbResult;
        }
    }
}
