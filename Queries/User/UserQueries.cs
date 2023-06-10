using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Dapper;

namespace Queries.User
{
    public class UserQueries : iUserQueries

    {
        private readonly string _connectionString;

        public UserQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            IEnumerable<UserViewModel> result = new List<UserViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<UserViewModel>("[dbo].[USER_PROC_SELECT_ALL]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<UserViewModel> GetById(int id)
        {
            var userByIdViewModel = new UserViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@User_id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                userByIdViewModel = await connection.QueryFirstOrDefaultAsync<UserViewModel>("[dbo].[USER_PROC_SELECT_ID]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return userByIdViewModel;

        }
    }
}
