using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RoutineExerciseRepository
{
    public class RoutineExerciseRepository: iRoutineExerciseRepository
    {
        private readonly string _connectionString;


        public RoutineExerciseRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(RoutineExercise re)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Routine_id", re.routine_id);
            parameters.Add("@Exercise_id", re.exercise_id);
            //parameters.Add("@Dateworkout", re.dateWorkout);


            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[ExerRou_PROC_CREATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[ExerRou_PROC_DELETE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(RoutineExercise re)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", re.routineExercise_id);
            parameters.Add("@Routine", re.routine_id);
            //parameters.Add("@Date", re.dateWorkout);


            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[ExerRou_PROC_UPDATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }


    }
}
