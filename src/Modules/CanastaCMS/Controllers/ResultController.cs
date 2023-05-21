using CanastaCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql;

namespace CanastaCMS.Controllers
{
    public class ResultController : Controller
    {
        public List<ResultPart> ResultList { get; }
        private readonly IContentManager _contentManager;
        private readonly ISession _session;
        public ResultController(IContentManager contentManager, ISession session)
        {
            this.ResultList = new List<ResultPart>();
            _contentManager = contentManager;
            _session = session;
        }
       
        public async Task<string> List()
        {
           // List<ResultPart> resultList = await FillResults();

            var resultParts = await _session
                .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "ResultGallery")
                .ListAsync();


            foreach (var resultPart in resultParts)
            {
                await _contentManager.LoadAsync(resultPart);
            }
            return string.Join(", ", resultParts);
        }
    }
}
