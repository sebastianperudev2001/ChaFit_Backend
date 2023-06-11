using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Utils
{
    public interface iRoutineByUser
    {
        Task<IEnumerable<RoutineByUserViewModel>>GetByName(int id);
    }
}
