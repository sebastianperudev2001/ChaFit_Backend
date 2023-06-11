using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.RoutineExercise
{
    public interface iRoutineExerciseQueries
    {
        Task<IEnumerable<RoutineExerciseViewModel>> GetAll();
        Task<RoutineExerciseViewModel> GetById(int id);
    }
}
