namespace RegisterMinimalApis.Endpoints
{
    public static class PersonEndpoints
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var people = routes.MapGroup("/api/v1/people");
            people.MapGet("", () => DataCollection.People);
            people.MapGet("/{id}", (int id) => DataCollection.People.FirstOrDefault(person => person.Id == id));

            people.MapPost("", (Person person) => DataCollection.People.Add(person));

            people.MapPut("/{id}", (int id, Person person) =>
            {
                Person currentPerson = DataCollection.People.FirstOrDefault(p => p.Id == id);

                if (currentPerson != null)
                {
                    currentPerson.FirstName = person.FirstName;
                    currentPerson.LastName = person.LastName;
                    currentPerson.Email = person.Email;
                }
            });

            people.MapDelete("/{id}", (int id) =>
            {
                Task.Delay(5000);
                var itemForDelete = DataCollection.People.FirstOrDefault(p => p.Id == id);
                if (itemForDelete == null) return;

                DataCollection.People.Remove(itemForDelete);
            });
        }


    }
}
