using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureNpgsqlContext(builder.Configuration);
builder.Services.ConfigurationCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
