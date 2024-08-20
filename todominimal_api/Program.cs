using Microsoft.EntityFrameworkCore;
using todominimal_api.Models;


namespace todominimal_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TododbContext>(x => x.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //Get all Todos.......
            app.MapGet("/todominimal_api/Todos", (TododbContext db) =>
            {
                return db.Todos.ToList();
            });

            ////Get  Todos by Id....
            app.MapGet("/todominimal_api/TodobyID", (TododbContext db,int id) => {
                var todo = db.Todos.Find(id);
                return Results.Ok(todo);
            });

            ////Add New Record in  Todo...
            app.MapPost("/todominimal_api/AddTodo", (TododbContext db, Todo tod) => {
               db.Todos.Add(tod);
                db.SaveChanges();
                return Results.Created($"/todominimal_api/TodobyID/{tod.Id}", tod);
            
            });

            //Update
            app.MapPut("/todominimal_api/UpdateTodo", (TododbContext db, Todo tod) => { 
               var todo=db.Todos.FirstOrDefault(x => x.Id == tod.Id);
                todo.Todo1 = tod.Todo1;
                todo.Completed = tod.Completed;
                todo.UserId = tod.UserId;
                db.Todos.Update(todo);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapDelete("/todominimal_api/DeleteTodo", (TododbContext db,int id) => {
                var todo = db.Todos.Find(id);
                db.Todos.Remove(todo);
                db.SaveChanges();
                return Results.NoContent();
            });

            app.Run();
        }
    }
}
