using DeveloperListApp.Models;
using GraphQL.Types;

namespace DeveloperListApp.Types
{
    public class DeveloperType : ObjectGraphType<Developer>
    {
        public DeveloperType()
        {
            Name = "Developer";
            Field(p => p.Id);
            Field(p => p.Name);
        }
    }
}
