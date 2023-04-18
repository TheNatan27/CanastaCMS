using CanastaCMS.Models;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql.Indexes;

namespace CanastaCMS.Indexes
{
    public class ResultPartIndex : MapIndex
    {
        public string Name { get; set; }
        public string Result { get; set; } 
    }

    public class ResultPartIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context) =>
            context.For<ResultPartIndex>().Map(contentItem =>
            {
                var resultPart = contentItem.As<ResultPart>();
                return resultPart == null
                    ? null
                    : new ResultPartIndex
                    {
                        Id = contentItem.Id,
                        Name = resultPart.Name,
                        Result = resultPart.Result,
                    };
            });
    }
}
