
using API.Extensions;
using Entities;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config.txt"));
// Add services to the container.

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<WsApplicationDbContext>(options =>
//options.UseSqlite(connectionString));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlServerContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var connectionStringCosmosDb = builder.Configuration.GetValue<string>("ConnectionString:CosmosDb:AccountKey");
//var cosmosDbName = builder.Configuration.GetValue<string>("ConnectionString:CosmosDb:DbName");

////builder.Services.AddDbContext<LogMessageDbContext>(options =>
////        options.UseCosmos(connectionStringCosmosDb, cosmosDbName));
//builder.Services.AddDbContext<RepositoryContext>(options =>
//        options.UseCosmos(connectionStringCosmosDb, cosmosDbName));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
