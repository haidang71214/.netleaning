
using docNetCore1.Repository;

namespace docNetCore1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<ITodoRepository, MongoDbTodoRepository>();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapGet("/", () => "Hello World!");
            }
// tự động chuyển thành https nếu có certs
            app.UseHttpsRedirection();

            app.UseAuthorization();

// kích hoạt xác thực và phân quyền
            app.MapControllers();

            app.Run();
        }
    }
}
