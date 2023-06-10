using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ExerciseRepository
{
    public interface iExerciseRepository
    {
        Task<int> Create(Exercise exercise);
        Task<int> Delete(int id);
        Task<int> Update(Exercise exercise);
    }
}
