using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<parking.api.Data.ParkingContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ParkingDatabase");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

///*"ParkingDatabase": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Parking-Db;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True"*/