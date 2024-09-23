using Infrastructure.Services.Category;
using Infrastructure.Services.Comment;
using Infrastructure.Services.GetCommands;
using Infrastructure.Services.Task;
using Infrastructure.Services.TaskAttachment;
using Infrastructure.Services.TaskHistory;
using Infrastructure.Services.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskAttachmentService, TaskAttachmentService>();
builder.Services.AddScoped<ITaskHistoryService, TaskHistoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGetCommandsService, GetCommandsService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();

