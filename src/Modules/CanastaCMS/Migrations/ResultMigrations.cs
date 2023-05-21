using CanastaCMS.Indexes;
using CanastaCMS.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;



namespace CanastaCMS.Migrations
{
    public class ResultMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;


        public ResultMigrations(IContentDefinitionManager contentDefinitionManager) =>
            _contentDefinitionManager = contentDefinitionManager;


        public int Create()
        {

            _contentDefinitionManager.AlterPartDefinition(nameof(ResultPart), part => part
                .Attachable()
                .Reusable()
                .WithField("TestField", field => field
                    .OfType("TextField")
                    .WithDisplayName("Test name")
                    .WithEditor("TextArea"))
                .WithField("ResultField", field => field
                    .OfType("TextField")
                    .WithDisplayName("Test result")
                    .WithEditor("TextArea"))
                .WithField("NotesField", field => field
                    .OfType("TextField")
                    .WithEditor("TextArea")
                    .WithDisplayName("NotesField"))
                .WithDescription("Result part experiment")
            );

            _contentDefinitionManager.AlterTypeDefinition("ResultGallery", type => type
                .WithPart("TitlePart")
                .WithPart("ListPart", part => part
                    .WithEditor("ListArea")
                )
                .Creatable()
                .Listable()
            );


            _contentDefinitionManager.AlterTypeDefinition("ResultWidget", type => type
                .WithPart(nameof(ResultPart))
                .Stereotype("Widget")
                .Listable()
                .Creatable()
            );

            return 1;
        }

    }
}
