using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Stat
{
    public interface iStatQueries
    {
        Task<IEnumerable<StatViewModel>> GetAll();
        Task<StatViewModel> GetById(int id);
    }
}
