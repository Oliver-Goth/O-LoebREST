using Microsoft.EntityFrameworkCore;
using O_LoebREST.DBContext;
using O_LoebREST.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// addning cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Adding database connection
var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
optionsBuilder.UseSqlServer("Data Source=mssql3.unoeuro.com;Initial Catalog=philipv_dk_db_solar;User ID=philipv_dk;Password=wa5pyrtbnRmHEh4fAg6k;Integrated Security=False;Encrypt=True;TrustServerCertificate=True");
DataBaseContext _databaseContext = new(optionsBuilder.Options);


// dependenci injecting RunRepo
builder.Services.AddSingleton<IRunRepo>(new RunRepoDB(_databaseContext));

// dependenci injecting PostRepo
builder.Services.AddSingleton<IPostRepo>(new PostRepoDB(_databaseContext));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
