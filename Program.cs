using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// inyeccion de dependencias
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("DbContext"));
builder.Services.AddScoped<IHelloWorldService, HelloworldService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();
//builder.Services.AddScoped<IHelloWorldService>(p=> new HelloworldService());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();// Authorization

// custom middleware 
//app.UseWelcomePage(); 
//app.useTimeMiddleware();

app.MapControllers(); // endpoint 

app.Run();
