using PptNemocnice.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:7132")
    .WithMethods("DELETE", "GET", "PUT", "POST")
    .AllowAnyHeader()
));

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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

app.MapPut("/vybaveni/{Id}", (VybaveniModel incomingItem) =>
{
    var item = seznam.SingleOrDefault(x => x.Id == incomingItem.Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");

    item = incomingItem;

    int index = seznam.FindIndex(x => x.Id == incomingItem.Id);

    if (index != -1)
        seznam[index] = item;

    return Results.Ok();
});

app.MapPost("/vybaveni", (VybaveniModel prichoziModel) =>
{
    prichoziModel.Id = Guid.NewGuid();
    seznam.Insert(0, prichoziModel);
    return prichoziModel.Id;
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
