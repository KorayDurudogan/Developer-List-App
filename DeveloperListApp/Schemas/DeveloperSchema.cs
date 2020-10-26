using DeveloperListApp.Fields;
using Fields.DeveloperListApp;
using GraphQL;
using GraphQL.Types;

namespace DeveloperListApp
{
    public class DeveloperSchema : Schema
    {
        public DeveloperSchema(IDependencyResolver resolver)
        {
            Query = resolver.Resolve<DevelopersQuery>();
            Mutation = resolver.Resolve<DevelopersMutation>();
        }
    }
}
