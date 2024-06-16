using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEntityFramework;
using ProjectEntityFramework.Models;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<ActivitiesContext>(p => p.UseInMemoryDatabase("ActivitiesDB"));
builder.Services.AddNpgsql<ActivitiesContext>(builder.Configuration.GetConnectionString("ActivitiesDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", async ([FromServices] ActivitiesContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("In Memory Database: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/activities", async ([FromServices] ActivitiesContext dbContext) => 
{
    return Results.Ok(dbContext.Activities.Include(p => p.Category));
});

app.MapPost("/api/activities", async ([FromServices] ActivitiesContext dbContext, [FromBody] Activity activity) => 
{
    activity.ActivityId = Guid.NewGuid();
    await dbContext.AddAsync(activity);
    // await dbContext.Activities.AddAsync(activity);

    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/activities/{id}", async ([FromServices] ActivitiesContext dbContext, [FromBody] Activity activity, [FromRoute] Guid id) => 
{
    var actualActivity = dbContext.Activities.Find(id);

    if (actualActivity != null)
    {
        actualActivity.CategoryId = activity.CategoryId;
        actualActivity.Title = activity.Title;
        actualActivity.Priority = activity.Priority;
        actualActivity.Description = activity.Description;
        actualActivity.UpdatedAt = DateTime.Now;
        
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/activities/{id}", async ([FromServices] ActivitiesContext dbContext, [FromRoute] Guid id) => 
{
    var actualActivity = dbContext.Activities.Find(id);
    
    if (actualActivity != null) {
        dbContext.Remove(actualActivity);
        
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapGet("/api/categories", ([FromServices] ActivitiesContext dbContext) => 
{
    return Results.Ok(dbContext.Categories);
});

app.MapPost("/api/categories", async ([FromServices] ActivitiesContext dbContext, [FromBody] Category category) => 
{
    category.CategoryId = Guid.NewGuid();
    await dbContext.AddAsync(category);

    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/categories/{id}", async ([FromServices] ActivitiesContext dbContext, [FromBody] Category category, [FromRoute] Guid id) => 
{
    var actualCategory = dbContext.Categories.Find(id);

    if (actualCategory != null)
    {
        actualCategory.Name = category.Name;
        actualCategory.Description = category.Description;
        actualCategory.Weight = category.Weight;
        
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/categories/{id}", async ([FromServices] ActivitiesContext dbContext, [FromRoute] Guid id) => 
{
    var actualCategory = dbContext.Categories.Find(id);
    
    if (actualCategory != null) {
        dbContext.Remove(actualCategory);
        
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
