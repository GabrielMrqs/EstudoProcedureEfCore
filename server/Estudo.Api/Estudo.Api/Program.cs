using Estudo.Infra;
using Estudo.Infra.Clients;
using Estudo.Infra.Procedures.ClientsAndProducts;
using Estudo.Infra.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Estudo.Infra"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

AddFeatures();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt => opt.AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await ApplyMigrations();

app.Run();

void AddFeatures()
{
    builder.Services.AddScoped<ClientRepository>();

    builder.Services.AddScoped<ProductRepository>();

    builder.Services.AddScoped<ClientAndProductsRepository>();

    builder.Services.AddScoped<Context>();
}

async Task ApplyMigrations()
{
    using (var scope = app.Services.CreateAsyncScope())
        await scope.ServiceProvider.GetRequiredService<Context>().Database.MigrateAsync();
}