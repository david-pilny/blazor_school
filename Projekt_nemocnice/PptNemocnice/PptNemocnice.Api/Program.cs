using Microsoft.EntityFrameworkCore;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NemocniceDbContext>(
    opt => opt.UseSqlite("FileName=Nemocnice.db")
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.MapGet("/revize/{vyhledavanyRetezec}", (string vyhledavanyRetezec, NemocniceDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec))
    {
        return Results.Problem("Parametr musí být neprázdný");
    }
    //var kdeJeRetezec = db.Revize.SelectMany(x => x.Name).Where(tr => vyhledavanyRetezec.Contains(tr)).ToList();
    List<RevizeModel> revizeList = db.Revize.ToList();
    var kdeJeRetezec = revizeList.Where(x => x.Name.Contains(vyhledavanyRetezec));
    return Results.Json(kdeJeRetezec);
});

app.MapGet("/vybaveni/jensrevizi", (int c) =>
{
    //return seznam.Where(x => !x.NeedsRevision);
});

app.MapGet("/vybaveni", (NemocniceDbContext db, IMapper mapper) =>
{
    List<VybaveniModel> seznam = new();

    List<Vybaveni> Vybaveni = db.Vybaveni.ToList(); 

    foreach (var vybaveni in Vybaveni)
    {
        VybaveniModel item = mapper.Map<VybaveniModel>(vybaveni);
        seznam.Add(item);
    }

    return seznam;
});

app.MapGet("/vybaveni/{Id}", (NemocniceDbContext db, Guid Id, IMapper mapper) =>
{
    Vybaveni item = db.Vybaveni.First(a => a.Id == Id);
    if (item == null) {
        return Results.NotFound("Tato položka nebyla nalezena!!");
    }
    VybaveniModel item2 = mapper.Map<VybaveniModel>(item);
    return Results.Ok(item2);
});

app.MapPut("/vybaveni/{Id}", (NemocniceDbContext db, VybaveniModel incomingItem, IMapper mapper) =>
{
    Vybaveni item = db.Vybaveni.First(a => a.Id == incomingItem.Id);

    if (item == null)
    {
        return Results.NotFound("Tato položka nebyla nalezena!!");
    }

    item.Name = incomingItem.Name;
    item.BoughtDate = incomingItem.BoughtDate;
    item.LastRevisionDate = incomingItem.LastRevisionDate;
    item.PriceCzk = incomingItem.PriceCzk;

    db.SaveChanges();

    return Results.Ok();
});

app.MapPost("/vybaveni", (VybaveniModel prichoziModel, NemocniceDbContext db, IMapper mapper) =>
{
    prichoziModel.Id = Guid.Empty;
    Vybaveni ent = mapper.Map<Vybaveni>(prichoziModel);
    db.Vybaveni.Add(ent);
    db.SaveChanges();

    return Results.Created("/vybaveni", ent.Id);
});

app.MapDelete("/vybaveni/{Id}", (NemocniceDbContext db, Guid Id) =>
{
    var item = db.Vybaveni.Where(x => x.Id == Id);

    if (item == null)
    {
        return Results.NotFound("Tato položka nebyla nalezena!!");
    }

    db.Remove(db.Vybaveni.Single(a => a.Id == Id));
    db.SaveChanges();
    return Results.Ok();
}
);

app.Run();
