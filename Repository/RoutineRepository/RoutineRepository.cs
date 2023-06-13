using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RoutineRepository
{
    public class RoutineRepository: iRoutineRepository
    {
        private readonly string _connectionString;


        public RoutineRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Routine routine)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Name", routine.routine_name);
            parameters.Add("@User_id", routine.user_id);


            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("[dbo].[ROUTINE_PROC_CREATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
                result = await connection.ExecuteScalarAsync<int>("SELECT IDENT_CURRENT('Routine')");

            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Routine_id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[ROUTINE_PROC_DELETE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(Routine routine)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Routine_id", routine.routine_id);
            parameters.Add("@User_id", routine.user_id);
            parameters.Add("@Name", routine.routine_name);



            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[ROUTINE_PROC_UPDATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
