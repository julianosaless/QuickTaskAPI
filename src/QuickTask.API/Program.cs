using System.Reflection;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using QuickTaskAPI.Business.Data;
using QuickTaskAPI.Business.Features.Task.Data;
using QuickTaskAPI.Business.Features.Task;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.DescribeAllParametersInCamelCase();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuickTask API", Version = "v1" });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename),true);
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("TarefasDatabase");
});


builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddApiVersioning(
                    options =>
                    {
                      
                        options.ReportApiVersions = true;
                    })
                .AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


