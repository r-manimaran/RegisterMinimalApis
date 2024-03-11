using Carter;

namespace RegisterMinimalApis.Modules;

public class Endpoint : CarterModule
{
    public Endpoint() : base("api/v1/people")
    {
        this
            .RequireRateLimiting("fixedWindowPolicy")
            .WithCacheOutput("cacheoutputpolicy")
            .IncludeInOpenApi();       
                  
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
      //  var people = app.MapGroup("/api/v1/people");
        app.MapGet("", () => DataCollection.People);
        app.MapGet("/{id}", (int id) => DataCollection.People.FirstOrDefault(person => person.Id == id));

        app.MapPost("", (Person person) => DataCollection.People.Add(person));

        app.MapPut("/{id}", (int id, Person person) =>
        {
            Person currentPerson = DataCollection.People.FirstOrDefault(p => p.Id == id);

            if (currentPerson != null)
            {
                currentPerson.FirstName = person.FirstName;
                currentPerson.LastName = person.LastName;
                currentPerson.Email = person.Email;
            }
        });

        app.MapDelete("/{id}", (int id) =>
        {
            var itemForDelete = DataCollection.People.FirstOrDefault(p => p.Id == id);
            if (itemForDelete == null) return;

            DataCollection.People.Remove(itemForDelete);
        });
    }
}
