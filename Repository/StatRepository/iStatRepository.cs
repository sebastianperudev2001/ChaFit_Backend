using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StatRepository
{
    public interface iStatRepository
    {
        Task<int> Create(Stat stat);
        Task<int> Delete(int id);
        Task<int> Update(Stat stat);
    }
}
