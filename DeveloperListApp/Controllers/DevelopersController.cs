using GraphQL;
using GraphQL.Conversion;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeveloperListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public DevelopersController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphqlQueryParameter query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables?.ToInputs(),
                FieldNameConverter = new PascalCaseFieldNameConverter()
            };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions);

                if (result.Errors?.Count > 0)
                    return BadRequest(result);

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
