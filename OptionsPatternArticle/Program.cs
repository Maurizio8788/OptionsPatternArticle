using OptionsPatternArticle.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<OptionsConfigurationBase>(
//    builder.Configuration
//        .GetSection(OptionsConfigurationBase.ConfigurationName)
//);

builder.Services.Configure<OptionsConfigurationBase>(
    OptionsConfigurationBase.NamedOptions1,
    builder.Configuration
        .GetSection($"{nameof(OptionsConfigurationBase)}:{OptionsConfigurationBase.NamedOptions1}")
);

builder.Services.Configure<OptionsConfigurationBase>(
    OptionsConfigurationBase.NamedOptions2,
    builder.Configuration
        .GetSection($"{nameof(OptionsConfigurationBase)}:{OptionsConfigurationBase.NamedOptions2}")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
