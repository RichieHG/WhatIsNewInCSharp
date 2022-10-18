using Microsoft.CodeAnalysis;

namespace Generator
{
    [Generator]
    public class Generator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var source = @"class Foo { public string Bar =""bar""; }";
            context.AddSource("Gen.cs", source);
        }

        public void Initialize(GeneratorInitializationContext context)
        {

        }
    }
}