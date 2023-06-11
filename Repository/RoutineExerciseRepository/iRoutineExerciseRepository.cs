using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RoutineExerciseRepository
{
    public interface iRoutineExerciseRepository
    {
        Task<int> Create(RoutineExercise routineExercise);
        Task<int> Delete(int id);
        Task<int> Update(RoutineExercise routineExercise);
    }
}
