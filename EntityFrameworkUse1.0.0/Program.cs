using EntityFrameworkUse1._0._0.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer("Data Source=DESKTOP-AD72JDE;Initial Catalog=EFCoreDemoDB;Integrated Security=True;Trust Server Certificate=True"));

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
