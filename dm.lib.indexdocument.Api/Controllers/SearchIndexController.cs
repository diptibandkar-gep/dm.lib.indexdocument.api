using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dm.lib.core.nuget;
using dm.lib.indexdocument.core.Entity;
using dm.lib.indexdocument.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace dm.lib.indexdocument.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class SearchIndexController : BaseController
    {
        IIndexService _bomSearchService;

        public SearchIndexController(IGepService gepservice, IIndexService bomSearchService) : base(gepservice)
        {
            _bomSearchService = bomSearchService;
        }

        [HttpPost("IngestESData", Name = "IngestESData")]
        public JObject IngestESData(SearchDocument document)
        {
            string token = Request.Headers["Authorization"];
            dynamic returnValue;
            try
            {
                returnValue = _bomSearchService.IngestESData(document, token);
            }
            catch (Exception ex)
            {

                returnValue = ex;
            }
            return new JObject(returnValue);
        }
    }
}