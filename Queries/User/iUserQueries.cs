using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.User
{
    public interface iUserQueries
    {
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int id);
    }
}
