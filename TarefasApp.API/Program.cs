using TarefasApp.API.Extensions;
using TarefasApp.Application.Extensions;
using TarefasApp.Infra.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddApplicationServices();
builder.Services.AddDataContext(builder.Configuration);

var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthorization();
app.MapControllers();
app.Run();



