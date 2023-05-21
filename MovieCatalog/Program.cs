using Microsoft.OpenApi.Any;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.HttpLogging;
using MovieCatalog.CatalogOps;
using MovieCatalog.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpLogging(httpLoggingFields =>
{
    httpLoggingFields.LoggingFields = HttpLoggingFields.Request;
});

var app = builder.Build();
app.UseHttpLogging();


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
