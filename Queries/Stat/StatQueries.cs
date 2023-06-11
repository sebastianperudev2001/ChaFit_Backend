using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Stat
{
    public class StatQueries: iStatQueries
    {
        private readonly string _connectionString;

        public StatQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<IEnumerable<StatViewModel>> GetAll()
        {
            IEnumerable<StatViewModel> result = new List<StatViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<StatViewModel>("[dbo].[Stat_PROC_SELECT_ALL]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<StatViewModel> GetById(int id)
        {
            var statByIdViewModel = new StatViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                statByIdViewModel = await connection.QueryFirstOrDefaultAsync<StatViewModel>("[dbo].[Stat_PROC_SELECT_ID]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return statByIdViewModel;

        }
    }
}
