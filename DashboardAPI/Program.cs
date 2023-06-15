using Dashboard.Common.Extensions;
using Dashboard.Common.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Content-Disposition", "Content-Length")
    )
);

// builder.Host.AddLoggingConfiguration();

builder.Services.RegisterDataServices();
builder.Services.RegisterServices();

builder.Services.AddControllers().AddJsonOptions(
    options => { options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter()); }
);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.CreateDbIfNotExists();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();