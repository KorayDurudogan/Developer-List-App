using DeveloperListApp.Models;
using DeveloperListApp.Types;
using DeveloperListApp.Types.Inputs;
using GraphQL.Types;

namespace DeveloperListApp.Fields
{
    public class DevelopersMutation : ObjectGraphType
    {
        public DevelopersMutation(DevelopersContext _developersContext)
        {
            Field<DeveloperType>("CreateDeveloper",
                arguments: new QueryArguments { new QueryArgument<DeveloperInputType> { Name = "developer" } },
                resolve: context =>
                {
                    var developer = context.GetArgument<Developer>("Developer");
                    return _developersContext.AddDeveloper(developer);
                });
        }
    }
}
