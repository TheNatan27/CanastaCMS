using CanastaCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanastaCMS.Controllers
{
    public class ResultController : Controller
    {
        public List<ResultPart> ResultList { get; }
        private readonly IContentManager _contentManager;
        public ResultController(IContentManager contentManager)
        {
            this.ResultList = new List<ResultPart>();
            _contentManager = contentManager;

        }
        private async Task<List<ResultPart>> FillResults()
        {
            string path = "..\\Modules\\StudyProject03.Core\\Files\\mockresults.json";
            StreamReader streamReader = new StreamReader(path); string json = await streamReader.ReadToEndAsync();
            List<ResultPart> resultList = JsonConvert.DeserializeObject<List<ResultPart>>(json);
            return resultList;
        }

        [Route("ResultList")]
        public async Task<string> List()
        {
            List<ResultPart> resultList = await FillResults();

            foreach (var resultPage in resultList)
            {
                ContentItem resultItem = resultPage.ContentItem;
                await _contentManager.LoadAsync(resultItem);
            }
            return "hello";
        }
    }
}
