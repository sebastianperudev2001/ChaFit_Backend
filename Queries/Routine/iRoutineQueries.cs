using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Routine
{
    public interface iRoutineQueries
    {
        Task<IEnumerable<RoutineViewModel>> GetAll();
        Task<RoutineViewModel> GetById(int id);
    }
}
