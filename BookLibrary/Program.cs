using BookLibrary.Data;
using BookLibrary.GraphQL.Mutations;
using BookLibrary.GraphQL.Queries;
using BookLibrary.GraphQL.Types;
using BookLibrary.GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("LibraryContext");
builder.Services.AddDbContext<LibraryContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

builder.Services.AddScoped<BookType>();
builder.Services.AddScoped<AuthorType>();
builder.Services.AddScoped<LibraryQuery>();
builder.Services.AddScoped<LibraryMutation>();
builder.Services.AddScoped<ISchema, LibrarySchema>();

builder.Services.AddGraphQL(b => b.AddSystemTextJson());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphQL<ISchema>();
app.UseGraphQLPlayground();
app.UseGraphQLGraphiQL();

app.MapControllers();

app.Run();
