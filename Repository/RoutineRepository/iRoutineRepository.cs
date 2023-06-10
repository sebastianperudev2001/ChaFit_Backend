using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RoutineRepository
{
    public interface iRoutineRepository
    {
        Task<int> Create(Routine routine);
        Task<int> Delete(int id);
        Task<int> Update(Routine routine);
    }
}
