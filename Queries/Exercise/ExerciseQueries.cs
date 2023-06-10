using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Exercise
{
    public class ExerciseQueries: iExerciseQueries
    {
        private readonly string _connectionString;

        public ExerciseQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<IEnumerable<ExerciseViewModel>> GetAll()
        {
            IEnumerable<ExerciseViewModel> result = new List<ExerciseViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<ExerciseViewModel>("[dbo].[EXERCISE_PROC_SELECT_ALL]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<ExerciseViewModel> GetById(int id)
        {
            var ExerciseByIdViewModel = new ExerciseViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@Exer_id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                ExerciseByIdViewModel = await connection.QueryFirstOrDefaultAsync<ExerciseViewModel>("[[dbo].[EXERCISE_PROC_SELECT_ID]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return ExerciseByIdViewModel;

        }

    }
}
