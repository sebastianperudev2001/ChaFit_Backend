using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MuscleRepository
{
    public interface iMuscleRepository
    {
        Task<int> Create(Muscle muscle);
        Task<int> Delete(int id);
        Task<int> Update(Muscle muscle);
    }
}
