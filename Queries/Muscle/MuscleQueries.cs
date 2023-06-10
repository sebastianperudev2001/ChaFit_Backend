using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Muscle
{
    public class MuscleQueries: iMuscleQueries
    {
        private readonly string _connectionString;

        public MuscleQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<IEnumerable<MuscleViewModel>> GetAll()
        {
            IEnumerable<MuscleViewModel> result = new List<MuscleViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<MuscleViewModel>("[dbo].[MUSCLE_PROC_SELECT_ALL]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<MuscleViewModel> GetById(int id)
        {
            var muscleByIdViewModel = new MuscleViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@Muscle_id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                muscleByIdViewModel = await connection.QueryFirstOrDefaultAsync<MuscleViewModel>("[dbo].[MUSCLE_PROC_SELECT_ID]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return muscleByIdViewModel;
        }
    }
}
