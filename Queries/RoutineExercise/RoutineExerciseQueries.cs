using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.RoutineExercise
{
    public class RoutineExerciseQueries: iRoutineExerciseQueries
    {
        private readonly string _connectionString;

        public RoutineExerciseQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<IEnumerable<RoutineExerciseViewModel>> GetAll()
        {
            IEnumerable<RoutineExerciseViewModel> result = new List<RoutineExerciseViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<RoutineExerciseViewModel>("[dbo].[ExerRou_PROC_SELECT_ALL]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<RoutineExerciseViewModel> GetById(int id)
        {
            var routineExerciseByIdViewModel = new RoutineExerciseViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                routineExerciseByIdViewModel = await connection.QueryFirstOrDefaultAsync<RoutineExerciseViewModel>("[dbo].[ExerRou_PROC_SELECT_ID]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return routineExerciseByIdViewModel;

        }
    }
}
