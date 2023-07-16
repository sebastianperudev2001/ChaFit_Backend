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
    public class ExercisesByRoutine : iExercisesByRoutine
    {
        private readonly string _connectionString;

        public ExercisesByRoutine(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

     
        public async Task<IEnumerable<ExercisesByRoutineViewModel>> GetByRoutineId(int id)
        {
            IEnumerable<ExercisesByRoutineViewModel> result = new List<ExercisesByRoutineViewModel>();

            var parameters = new DynamicParameters();
            parameters.Add("@routine_id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<ExercisesByRoutineViewModel>("[dbo].[ROUTINE_PROC_SELECT_EXERCISE_BY_ROUTINE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
