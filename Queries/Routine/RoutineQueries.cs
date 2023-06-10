using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Routine
{
    public class RoutineQueries: iRoutineQueries
    {
        private readonly string _connectionString;

        public RoutineQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<IEnumerable<RoutineViewModel>> GetAll()
        {
            IEnumerable<RoutineViewModel> result = new List<RoutineViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<RoutineViewModel>("[dbo].[ROUTINE_PROC_SELECT_ALL]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<RoutineViewModel> GetById(int id)
        {
            var routineByIdViewModel = new RoutineViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@Routine_id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                routineByIdViewModel = await connection.QueryFirstOrDefaultAsync<RoutineViewModel>("[dbo].[ROUTINE_PROC_SELECT_ID]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return routineByIdViewModel;

        }

    }
}
