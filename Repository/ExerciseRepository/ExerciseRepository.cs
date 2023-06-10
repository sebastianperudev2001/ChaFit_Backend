using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ExerciseRepository
{
    public class ExerciseRepository: iExerciseRepository
    {
        private readonly string _connectionString;


        public ExerciseRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Exercise exercise)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Name", exercise.name);
            parameters.Add("@Muscle_id", exercise.muscle_id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[EXERCISE_PROC_CREATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Exercise_id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[EXERCISE_PROC_DELETE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(Exercise exercise)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Exercise_id", exercise.exercise_id);
            parameters.Add("@Name", exercise.name);
            parameters.Add("@Muscle_id", exercise.muscle_id);
          

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[EXERCISE_PROC_UPDATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

    }
}
