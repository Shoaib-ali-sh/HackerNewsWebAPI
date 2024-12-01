using HackerNewsWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<IHackerNewsService, HackerNewsService>();
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("HackerNewsWeb", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()                    
            .AllowAnyMethod();                   
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("HackerNewsWeb");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
