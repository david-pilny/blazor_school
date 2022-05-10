using Microsoft.EntityFrameworkCore;
using PptNemocnice.Api.Data;
using PptNemocnice.Shared;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NemocniceDbContext>(
    opt => opt.UseSqlite("FileName=Nemocnice.db")
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins(builder.Configuration["AllowedOrigins"])
    .WithMethods("DELETE", "GET", "PUT", "POST")
    .AllowAnyHeader()
));

var app = builder.Build();

app.UseCors();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hellou");

app.MapGet("/vybaveni/jensrevizi", (int c) =>
{
    //return seznam.Where(x => !x.NeedsRevision);
});

app.MapPost("/revize/onadd", (NemocniceDbContext db, VybaveniModel item, IMapper mapper) =>
{
    Random random = new Random();
    int length = 16;
    var rString = "";

    for (var i = 0; i < length; i++)
    {
        rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
    }

    Revize ent = new();
    ent.Id = Guid.Empty;
    ent.Name = rString;
    ent.DateTime = item.LastRevisionDate;
    ent.VybaveniId = item.Id;
    db.Revize.Add(ent);
    db.SaveChanges();
    return Results.Ok();

});

app.Run();

//app.MapGet("/vybaveni", (NemocniceDbContext db, IMapper mapper) =>
//{
//    List<VybaveniModel> seznam = new();

//    var ents = db.Vybaveni.Include(x => x.Revizes);

//    foreach (var ent in ents)
//    {
//        VybaveniModel item = mapper.Map<VybaveniModel>(ent);
//        if (ent.Revizes.Count > 0)
//        {
//            item.LastRevisionDate = ent.Revizes.Last().DateTime;
//        }

//        seznam.Add(item);
//    }

//    return seznam;
//});

//app.MapGet("/vybaveni/{Id}", (NemocniceDbContext db, Guid Id, IMapper mapper) =>
//{
//    Vybaveni item = db.Vybaveni.Include(x => x.Revizes).First(a => a.Id == Id);
//    if (item == null) {
//        return Results.NotFound("Tato položka nebyla nalezena!!");
//    }
//    VybaveniModel item2 = mapper.Map<VybaveniModel>(item);
//    item2.LastRevisionDate = item.Revizes.Last().DateTime;
//    return Results.Ok(item2);
//});


//app.MapPost("/vybaveni", (VybaveniModel prichoziModel, NemocniceDbContext db, IMapper mapper) =>
//{
//    prichoziModel.Id = Guid.Empty;
//    Vybaveni ent = mapper.Map<Vybaveni>(prichoziModel);

//    db.Vybaveni.Add(ent);
//    db.SaveChanges();

//    return Results.Created("/vybaveni", ent.Id);
//});

//app.MapDelete("/vybaveni/{Id}", (NemocniceDbContext db, Guid Id) =>
//{
//    var item = db.Vybaveni.Where(x => x.Id == Id);

//    if (item == null)
//    {
//        return Results.NotFound("Tato položka nebyla nalezena!!");
//    }

//    db.Remove(db.Vybaveni.Single(a => a.Id == Id));
//    db.SaveChanges();
//    return Results.Ok();
//});

//app.MapPut("/vybaveni/{Id}", (NemocniceDbContext db, VybaveniModel incomingItem, IMapper mapper) =>
//{
//    Vybaveni item = db.Vybaveni.FirstOrDefault(a => a.Id == incomingItem.Id);

//    if (item == null)
//    {
//        return Results.NotFound("Tato položka nebyla nalezena!!");
//    }

//    mapper.Map(incomingItem, item);

//    db.SaveChanges();

//    return Results.Ok();
//});


//app.MapGet("/revize/{vyhledavanyRetezec}", (string vyhledavanyRetezec, NemocniceDbContext db) =>
//{
//    if (string.IsNullOrWhiteSpace(vyhledavanyRetezec))
//    {
//        return Results.Problem("Parametr musí být neprázdný");
//    }
//    List<Revize> revizeList = db.Revize.ToList();
//    var kdeJeRetezec = revizeList.Where(x => x.Name.Contains(vyhledavanyRetezec));
//    return Results.Json(kdeJeRetezec);
//});

//app.MapGet("/revize/detail/{Id}", (Guid Id, NemocniceDbContext db, IMapper mapper) =>
//{
//    var revizeList = db.Revize.Where(x => x.VybaveniId == Id).ToList();
//    List<VybaveniSRevizemiModel> list = new();

//    foreach (var item in revizeList)
//    {

//        VybaveniSRevizemiModel item2 = mapper.Map<VybaveniSRevizemiModel>(item);
//        list.Add(item2);

//    }
//    return Results.Json(list);
//});

//app.MapPost("/revize", (NemocniceDbContext db, VybaveniModel item, IMapper mapper) =>
//{
//    Random random = new Random();
//    int length = 16;
//    var rString = "";

//    for (var i = 0; i < length; i++)
//    {
//        rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
//    }

//    Revize ent = new();
//    ent.Id = Guid.Empty;
//    ent.Name = rString;
//    ent.DateTime = DateTime.Now;
//    ent.VybaveniId = item.Id;
//    db.Revize.Add(ent);
//    db.SaveChanges();
//    return Results.Ok();

//});