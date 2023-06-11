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
    public class ExeRouteByDate : iExeRouteByDate
    {
        private readonly string _connectionString;

        public ExeRouteByDate(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }
      
        public async Task<IEnumerable<ExeRouByDateViewModel>> GetByDate(DateTime dateworkout)
        {
            IEnumerable<ExeRouByDateViewModel> result = new List<ExeRouByDateViewModel>();

            var parameters = new DynamicParameters();
            parameters.Add("@Date", dateworkout);
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<ExeRouByDateViewModel>("[dbo].[ExerRou_PROC_SELECT_DATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

    }
}
