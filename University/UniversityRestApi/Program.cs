
using Microsoft.OpenApi.Models;
using UniversityBusinessLogic.BusinessLogics;
using UniversityBusinessLogic.MailWorker;
using UniversityBusinessLogic.OfficePackage;
using UniversityBusinessLogic.OfficePackage.Implements;
using UniversityBusinessLogics.BusinessLogics;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicContracts;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.StorageContracts;
using UniversityDatabaseImplement.Implements;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Logging.AddLog4Net("log4net.config");


// Add services to the container.
builder.Services.AddTransient<IUserStorage, UserStorage>();
builder.Services.AddTransient<IDisciplineStorage, DisciplineStorage>();
builder.Services.AddTransient<ITeacherStorage, TeacherStorage>();
builder.Services.AddTransient<IPlanOfStudyStorage, PlanOfStudyStorage>();
builder.Services.AddTransient<IAttestationStorage, AttestationStorage>();
builder.Services.AddTransient<IStatementStorage, StatementStorage>();
builder.Services.AddTransient<IStudentStorage, StudentStorage>();

builder.Services.AddTransient<AbstractSaveToExcelWorker, SaveToExcelWorker>();
builder.Services.AddTransient<AbstractSaveToWordWorker, SaveToWordWorker>();
builder.Services.AddTransient<AbstractSaveToPdfWorker, SaveToPdfWorker>();
builder.Services.AddTransient<AbstractSaveToExcelStorekeeper, SaveToExcelStorekeeper>();
builder.Services.AddTransient<AbstractSaveToWordStorekeeper, SaveToWordStorekeeper>();
builder.Services.AddTransient<AbstractSaveToPdfStorekeeper, SaveToPdfStorekeeper>();
builder.Services.AddTransient<IReportLogic, ReportLogic>();
builder.Services.AddTransient<IUserLogic, UserLogic>();
builder.Services.AddTransient<IDisciplineLogic, DisciplineLogic>();
builder.Services.AddTransient<ITeacherLogic, TeacherLogic>();
builder.Services.AddTransient<IPlanOfStudyLogic, PlanOfStudyLogic>();
builder.Services.AddTransient<IAttestationLogic, AttestationLogic>();
builder.Services.AddTransient<IStatementLogic, StatementLogic>();
builder.Services.AddTransient<IStudentLogic, StudentLogic>();
builder.Services.AddSingleton<AbstractMailWorker, MailKitWorker>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UniversityRestApi",
        Version
    = "v1"
    });
});

var app = builder.Build();

var mailSender = app.Services.GetService<AbstractMailWorker>();

mailSender?.MailConfig(new MailConfigBindingModel
{
    MailLogin = builder.Configuration?.GetSection("MailLogin")?.Value?.ToString() ?? string.Empty,
    MailPassword = builder.Configuration?.GetSection("MailPassword")?.Value?.ToString() ?? string.Empty,
    SmtpClientHost = builder.Configuration?.GetSection("SmtpClientHost")?.Value?.ToString() ?? string.Empty,
    SmtpClientPort = Convert.ToInt32(builder.Configuration?.GetSection("SmtpClientPort")?.Value?.ToString()),
    PopHost = builder.Configuration?.GetSection("PopHost")?.Value?.ToString() ?? string.Empty,
    PopPort = Convert.ToInt32(builder.Configuration?.GetSection("PopPort")?.Value?.ToString())
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversityRestApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
