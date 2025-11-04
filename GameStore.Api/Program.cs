using GameStore.Api.Data;
using GameStore.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("Default")!;

builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MigrateDb();

app.MapGamesEndpoints();
app.MapGenresEndpoints();

app.Run();
