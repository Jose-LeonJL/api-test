using api_test.Database;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseMysql>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Carga de las Variables de entorno
DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { Path.Combine(Directory.GetCurrentDirectory(), ".env") }));

app.UseAuthorization();

app.MapControllers();

app.Run();
