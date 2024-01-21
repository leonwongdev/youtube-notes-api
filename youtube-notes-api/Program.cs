using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Dependency Injection
// You add libraries or modules in here to wire them up
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<youtube_notes_api.Data.DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Below are more like middleware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // When you do not have configuration for production endpoint in appsettings.json
    // By default the environment will be production and these code will not execute
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {

        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
        x.RoutePrefix = "swagger";

    }
);

}

app.UseHttpsRedirection();

app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
