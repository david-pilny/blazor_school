using PptNemocnice.Shared;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

List<VybaveniModel> seznam = VybaveniModel.GetTestList();

app.MapGet("/vybaveni", () =>
{
    return seznam;
});

app.MapGet("/vybaveni/{Id}", (Guid Id) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");
    return Results.Ok(item);
});

app.MapPut("/vybaveni/{Id}", (Guid Id, string name, DateTime bought, DateTime revision, double price) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");

    item.Name=name;
    item.BoughtDate = bought;
    item.LastRevisionDate = revision;
    item.PriceCzk = price;

    int index = seznam.FindIndex(x => x.Id == Id);

    if (index != -1)
        seznam[index] = item;

    return Results.Ok();
});

app.MapPost("/vybaveni", (string name, DateTime bought, DateTime revision, double price) =>
{
    VybaveniModel prichoziModel = new VybaveniModel
    {
        Id = Guid.NewGuid(),
        Name = name,
        BoughtDate = bought,
        LastRevisionDate = revision,
        IsInEditMode = false,
        PriceCzk = price
    };
    seznam.Insert(0, prichoziModel);
});

app.MapDelete("/vybaveni/{Id}", (Guid Id) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");
    seznam.Remove(item);
    return Results.Ok();
}
);


app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}