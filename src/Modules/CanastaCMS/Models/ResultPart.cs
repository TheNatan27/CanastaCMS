using Microsoft.VisualBasic.FileIO;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanastaCMS.Models
{
    public class ResultPart : ContentPart
    {
        public string Name { get; set; }
        public string Result { get; set; }  
        public TextField Notes { get; set; }
    }

    public class ResultGalleryExperiment : ContentPart
    {
        public string Title { get; set; }
    }
}
