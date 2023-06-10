using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MuscleRepository
{
    public class MuscleRepository: iMuscleRepository
    {
        private readonly string _connectionString;


        public MuscleRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Muscle muscle)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Name", muscle.name);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[MUSCLE_PROC_CREATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Muscle_id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[MUSCLE_PROC_DELETE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(Muscle muscle)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Muscle_id", muscle.muscle_id);
            parameters.Add("@Name", muscle.name);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[MUSCLE_PROC_UPDATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

    }
}
