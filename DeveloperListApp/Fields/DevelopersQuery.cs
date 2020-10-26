using DeveloperListApp;
using DeveloperListApp.Types;
using GraphQL.Types;

namespace Fields.DeveloperListApp
{
    public class DevelopersQuery : ObjectGraphType
    {
        public DevelopersQuery(DevelopersContext _developersContext)
        {
            Name = "Developers_Query";
            Description = "Koray's first GraphQL schema.";

            Field<ListGraphType<TeamType>>("Teams", resolve: ctx => _developersContext.GetTeams());

            Field<TeamType>("TeamById",
                arguments: new QueryArguments
                {
                    new QueryArgument<NonNullGraphType<IdGraphType>>{
                        Name="Id",
                        Description="Id of team"
                    }
                },
                resolve: ctx => _developersContext.GetTeamById(ctx.GetArgument<int>("Id")));

            Field<DeveloperType>("DeveloperById",
                arguments: new QueryArguments
                {
                    new QueryArgument<NonNullGraphType<IdGraphType>>{
                        Name="Id",
                        Description="Id of developer"
                    }
                },
                resolve: ctx => _developersContext.GetDeveloperById(ctx.GetArgument<int>("Id")));

            Field<ListGraphType<DeveloperType>>("Developers", resolve: ctx => _developersContext.GetDevelopers());
        }
    }
}
