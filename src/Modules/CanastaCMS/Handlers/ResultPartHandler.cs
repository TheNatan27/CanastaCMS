using CanastaCMS.Models;
using OrchardCore.ContentManagement.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanastaCMS.Handlers
{
    public class ResultPartHandler : ContentPartHandler<ResultPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, ResultPart instance)
        {
            context.ContentItem.DisplayText = instance.Name;
            return Task.CompletedTask;
        }
    }
}
