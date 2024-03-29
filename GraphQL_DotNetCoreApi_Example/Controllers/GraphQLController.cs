﻿using GraphQL;
using GraphQL.Types;
using GraphQL_DotNetCoreApi_Example.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GraphQL_DotNetCoreApi_Example.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query };
            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);
                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}