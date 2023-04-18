using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "CanastaCMS",
    Author = "The Orchard Core Team",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "CanastaCMS",
    Category = "Content Management",
    Dependencies = new[] { "OrchardCore.ContentFields", "OrchardCore.Media"}
)]
