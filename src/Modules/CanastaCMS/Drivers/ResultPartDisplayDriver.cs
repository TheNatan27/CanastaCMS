using CanastaCMS.Models;
using CanastaCMS.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanastaCMS.Drivers
{
    public class ResultPartDisplayDriver : ContentPartDisplayDriver<ResultPart>
    {
        public override IDisplayResult Display(ResultPart part, BuildPartDisplayContext context) =>
            Initialize<ResultPartViewModel>(
                GetDisplayShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:5")
            .Location("Summary", "Content:5");

        private static void PopulateViewModel(ResultPart part, ResultPartViewModel viewModel)
        {
            viewModel.Name = part.Name;
            viewModel.Result = part.Result;
        }
    }
}
