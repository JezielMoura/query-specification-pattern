namespace Nett.Core;

public class GetUserQuerySpecification : QuerySpecification<User, string>
{
    public GetUserQuerySpecification()
    {
        Query = (user) => user.Name != "";
        OrderBy = (user) => user.Name;
        Selector = (user) => user.Name;
    }
}
