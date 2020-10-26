using GraphQL.Types;

namespace DeveloperListApp.Types.Inputs
{
    public class DeveloperInputType : InputObjectGraphType
    {
        public DeveloperInputType()
        {
            Name = "DeveloperInput";
            Field<NonNullGraphType<IdGraphType>>("Id");
            Field<StringGraphType>("Name");
        }
    }
}
