
using System.Data;
using Mail_API;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//Injecting SmtpConfiguration 
builder.Services.Configure<SmtpConfig>(builder.Configuration.GetSection("SmtpConfiguration"));
//Adding the email service into DI
builder.Services.AddTransient<EmailService>();
//Adding the Conenection string from appsettings.json to the DI
var connectionString = builder.Configuration.GetConnectionString("web_api_test");
builder.Services.AddTransient<IDbConnection>(db => new MySqlConnection(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();
//Including Controllers in the endpoint
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
