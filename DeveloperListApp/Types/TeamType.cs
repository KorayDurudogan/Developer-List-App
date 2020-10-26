using DeveloperListApp.Models;
using GraphQL.Types;

namespace DeveloperListApp.Types
{
    public class TeamType : ObjectGraphType<Team>
    {
        public TeamType()
        {
            Name = "Team";
            Field(p => p.Id).Description("Id of team.");
            Field(p => p.Name).Description("Name of the team");
            Field<ListGraphType<DeveloperType>>("Developers", resolve: _ => _.Source.Developers);
        }
    }
}
