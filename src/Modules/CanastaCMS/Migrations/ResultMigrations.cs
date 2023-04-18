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

            _contentDefinitionManager.AlterPartDefinition("ResultPartShema", part => part
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
                    .WithDescription("Result part shcema")
                );

            _contentDefinitionManager.AlterTypeDefinition("ResultGallerySchema", type => type
                .WithPart("ResultPartSchema")
                .WithPart("TitlePart")
                .WithPart("ListPart", part => part
                    .WithEditor("ListArea")
                )
                .Creatable()
            );

            _contentDefinitionManager.AlterTypeDefinition("ResultWidget", type => type
                .WithPart("ResultPartShema")
                .Stereotype("Widget")
                .Creatable()
            );

            return 1;
        }

    }
}
