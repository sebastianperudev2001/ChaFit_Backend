using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Utils
{
    public interface iStatByUserExer
    {
        Task<IEnumerable<StatByUserExerciseViewModel>> GetByUserExer(int user_id, int exer_id);

    }
}
