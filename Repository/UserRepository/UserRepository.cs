using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class UserRepository: iUserRepository
    {
        private readonly string _connectionString;


        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(User user)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Name", user.name);
            parameters.Add("@Lastname", user.lastName);
            parameters.Add("@Email", user.email);

            parameters.Add("@Password", user.password);
            parameters.Add("@Age", user.age);
            parameters.Add("@Gender", user.gender);

            parameters.Add("@Height", user.height);
            parameters.Add("@Weight", user.weight);


            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[USER_PROC_CREATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id_user", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[USER_PROC_DELETE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(User user)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id_user", user.user_id);
            parameters.Add("@Name", user.name);
            parameters.Add("@Lastname", user.lastName);
            parameters.Add("@Email", user.email);

            parameters.Add("@Password", user.password);
            parameters.Add("@Age", user.age);
            parameters.Add("@Gender", user.gender);

            parameters.Add("@Height", user.height);
            parameters.Add("@Weight", user.weight);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[USER_PROC_UPDATE]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
