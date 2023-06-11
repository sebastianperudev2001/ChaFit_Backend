using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Utils
{
    public interface iExeRouteByDate
    {
        Task<IEnumerable<ExeRouByDateViewModel>> GetByDate(DateTime dateworkout);

    }
}
