using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Muscle
{
    public interface iMuscleQueries
    {
        Task<IEnumerable<MuscleViewModel>> GetAll();
        Task<MuscleViewModel> GetById(int id);
    }
}
