using Microsoft.AspNetCore.Mvc;
using Queries.Exercise;
using Queries.Muscle;
using Queries.Routine;
using Queries.RoutineExercise;
using Queries.Stat;
using Queries.User;
using Queries.Utils;
using Repository.ExerciseRepository;
using Repository.MuscleRepository;
using Repository.RoutineExerciseRepository;
using Repository.RoutineRepository;
using Repository.StatRepository;
using Repository.UserRepository;

namespace API_ChaFit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddTransient<iUserQueries, UserQueries>();
            builder.Services.AddTransient<iUserRepository, UserRepository>();

            builder.Services.AddTransient<iMuscleQueries, MuscleQueries>();
            builder.Services.AddTransient<iMuscleRepository, MuscleRepository>();

            builder.Services.AddTransient<iExerciseQueries, ExerciseQueries>();
            builder.Services.AddTransient<iExerciseRepository, ExerciseRepository>();

            builder.Services.AddTransient<iRoutineQueries, RoutineQueries>();
            builder.Services.AddTransient<iRoutineRepository, RoutineRepository>();

            builder.Services.AddTransient<iRoutineExerciseQueries, RoutineExerciseQueries>();
            builder.Services.AddTransient<iRoutineExerciseRepository, RoutineExerciseRepository>();

            builder.Services.AddTransient<iStatQueries, StatQueries>();
            builder.Services.AddTransient<iStatRepository, StatRepository>();

            builder.Services.AddTransient<iRoutineByUser, RoutineByUser>();
            builder.Services.AddTransient<iExeRouteByDate, ExeRouteByDate>();
            builder.Services.AddTransient<iStatByUserExer, StatByUserExer>();





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}