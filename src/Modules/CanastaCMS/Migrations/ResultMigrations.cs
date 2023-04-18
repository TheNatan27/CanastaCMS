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
                .
 );

            //        .WithField(nameof(ResultPart.Name), field => field
            //.OfType(nameof(TextField))
            //.WithDisplayName("Notes")
            //.WithSettings(new TextFieldSettings
            //{
            //    Hint = "Note for evaulation."
            //})
            //.WithEditor("TextArea"))

            SchemaBuilder.CreateTable(nameof(ResultPartIndex), table => table
                .Column<string>(nameof(ResultPartIndex.Name))
                .Column<string>(nameof(ResultPartIndex.Result))
            );

            _contentDefinitionManager.AlterTypeDefinition("ResultGallery", type => type
                .Creatable()
                .Listable()
                .WithPart("ListPart", part => part
                    .WithEditor("ListEditor")
                )
            );

            _contentDefinitionManager.AlterTypeDefinition("ResultWidget", type => type
                .WithPart(nameof(ResultPart))
                .Stereotype("Widget")
            );

            return 1;
        }

    }
}
