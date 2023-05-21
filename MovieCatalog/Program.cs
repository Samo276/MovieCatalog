using Microsoft.OpenApi.Any;
using Microsoft.VisualBasic;
using MovieCatalog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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



var Movies = new SampleMovies().AddSampleMovies();

app.MapPost("/POST", (MovieEntry incomingEntry) =>
{
    var result = IncomingMovieEntryConverter.Convert(incomingEntry, Movies);
    Movies.Add(result);
    return Results.Ok(result);
})
.WithName("PostMovieEntry");


app.MapGet("/GET", () =>
{
    return Movies.Where(entries=> entries.EntryCreationTime == Movies.Max(x => x.EntryCreationTime));
})
.WithName("GetLatestEntry");


app.MapGet("/GET/[year]", (int givenYear) =>
{
    return Movies.Where(entries => entries.PremiereTime.Year == givenYear).ToList();
})
.WithName("GetByYear");


app.MapGet("/GET/[genre]", (string givenGenre) =>
{
    return Movies.Where(entries => entries.Genre == givenGenre).ToList();
})
.WithName("GetByGenre");



app.Run();
