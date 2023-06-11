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
    public class StatByUserExer : iStatByUserExer
    {
        private readonly string _connectionString;

        public StatByUserExer(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }
        public async Task<IEnumerable<StatByUserExerciseViewModel>> GetByUserExer(int user_id, int exer_id)
        {
            IEnumerable<StatByUserExerciseViewModel> result = new List<StatByUserExerciseViewModel>();

            var parameters = new DynamicParameters();
            parameters.Add("@User_Id", user_id);
            parameters.Add("@Exercise_Id", exer_id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<StatByUserExerciseViewModel>("[dbo].[Stat_PROC_SELECT_EXERCISE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
