using quizeAppApi.Models;
using quizeAppApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Services
builder.Services.AddSingleton<BooksService>();
builder.Services.AddSingleton<CategoryService>();
builder.Services.AddSingleton<QuestionService>();
builder.Services.AddSingleton<UserService>();

//MongoDbConnection
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

builder.Services.Configure<QuizeDatabaseSettings>(
    builder.Configuration.GetSection("QuizeDatabase"));

builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("UserDatabase"));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
