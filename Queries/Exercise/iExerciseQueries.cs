using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Queries.Exercise
{
    public interface iExerciseQueries
    {
        Task<IEnumerable<ExerciseViewModel>> GetAll();
        Task<ExerciseViewModel> GetById(int id);
    }
}
