using Microsoft.AspNetCore.Mvc;
using Queries.Exercise;
using Queries.Muscle;
using Queries.Routine;
using Queries.User;
using Repository.ExerciseRepository;
using Repository.MuscleRepository;
using Repository.RoutineRepository;
using Repository.UserRepository;

namespace API_ChaFit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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