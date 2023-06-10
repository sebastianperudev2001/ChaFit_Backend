using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public interface iUserRepository
    {
        Task<int> Create(User user);
        Task<int> Delete(int id);
        Task<int> Update(User user);
    }
}
