# Developer-List-App

A GraphQL API that adds and fetchs developers. 
API uses GraphiQL for interacting with user and it runs on /ui/graphiql.

Dummy request for fetching all teams and developers:

*Query:*
{
  Teams {
    Name
    Developers {
      Name
    }
  }
}

Dummy request for adding a developer to second team:

*Query:*
mutation ($developer: DeveloperInput) {
  CreateDeveloper(Developer: $developer) {
    Id
    Name
  }
}

*Query variable:*
{
  "developer":{
  	"Id": 99,
  	"Name": "Feride Duman"      
  } 
}


