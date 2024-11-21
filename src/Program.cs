using Nett.Core;

var appDbContext = new AppDbContext();
var result = QuerySpecificationBuilder.GetQuery(appDbContext.Users, new GetUserQuerySpecification());

foreach (var item in result.ToList())
{
    Console.WriteLine(item);
}
