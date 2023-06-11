using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StatRepository
{
    public class StatRepository: iStatRepository
    {
        private readonly string _connectionString;


        public StatRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Stat stat)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Set", stat.gymSet);
            parameters.Add("@Set", stat.gymSet);
            parameters.Add("@Set", stat.gymSet);
            parameters.Add("@Set", stat.gymSet);



            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Stat_PROC_CREATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
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
                result = await connection.ExecuteAsync("[dbo].[Stat_PROC_DELETE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(Stat stat)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", stat.stat_id);
            parameters.Add("@Set", stat.gymSet);
            parameters.Add("@Rep", stat.gymRep);
            parameters.Add("@Weight", stat.weight);
            parameters.Add("@Exercise_Id", stat.routineExercise_id);


            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Stat_PROC_UPDATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
