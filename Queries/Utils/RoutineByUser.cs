using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Utils
{
    public class RoutineByUser : iRoutineByUser

    {
        private readonly string _connectionString;

        public RoutineByUser(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }
        public async Task<IEnumerable<RoutineByUserViewModel>> GetByName(int id)
        {
            IEnumerable<RoutineByUserViewModel> result = new List<RoutineByUserViewModel>();

            var parameters = new DynamicParameters();
            parameters.Add("@User_Id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<RoutineByUserViewModel>("[dbo].[ROUTINE_PROC_SELECT_USER]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }


    }
}
