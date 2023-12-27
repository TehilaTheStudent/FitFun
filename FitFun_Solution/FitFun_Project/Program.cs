using FitFun_Project;
using FitFun_Project.Core.Repositories;//added
using FitFun_Project.Core.Services;//added
using FitFun_Project.Data.Rpositories;//added
using FitFun_Project.Service.Services;//added

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<InterfaceParticipantService, ParticipantService>();//for the controller-participant
builder.Services.AddScoped<InterfaceParticipantRepository, ParticipantRepository>();//for the service-participant
builder.Services.AddScoped<InterfaceTeacherService, TeacherService>();//for the controller-teacher
builder.Services.AddScoped<InterfaceTeacherRepository, TeacherRepository>();//for the service-teacher
builder.Services.AddScoped < InterfaceLessonService, LessonService>();//for the controller-lesson
builder.Services.AddScoped<InterfaceLessonRepository, LessonRepository>();//for the service-lesson
builder.Services.AddDbContext<DataContext>();//for the repository
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
