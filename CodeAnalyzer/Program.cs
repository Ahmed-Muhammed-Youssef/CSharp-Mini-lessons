using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string code = "using text; \nnamespace amad \n {/*comment*/ public partial class heelo {" +
                "int pp;" +
                "} \n}"; // Your code here

            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

            // Get all using directives
            IEnumerable<UsingDirectiveSyntax> usingDirectives = root.DescendantNodes().OfType<UsingDirectiveSyntax>();

            string usings = string.Join("\n", usingDirectives.Select(u => u.ToFullString()));

            // Get all namespace declarations
            IEnumerable<NamespaceDeclarationSyntax> namespaceDeclarations = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>();

            foreach (var namespaceDeclaration in namespaceDeclarations)
            {
                // Get all class declarations
                IEnumerable<ClassDeclarationSyntax> classDeclarations = namespaceDeclaration.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>();
                foreach (var classDeclaration in classDeclarations)
                {
                    File.WriteAllText($"{classDeclaration.Identifier.Text}.cs", $"{usings}\nnamespace {namespaceDeclaration.Name} {{ {classDeclaration.ToFullString()} }}");
                }

                // Get all interface declarations
                IEnumerable<InterfaceDeclarationSyntax> interfaceDeclarations = namespaceDeclaration.DescendantNodes().OfType<InterfaceDeclarationSyntax>();
                foreach (var interfaceDeclaration in interfaceDeclarations)
                {
                    File.WriteAllText($"{interfaceDeclaration.Identifier.Text}.cs", $"{usings}\nnamespace {namespaceDeclaration.Name} {{ {interfaceDeclaration.ToFullString()} }}");
                }

                // Get all struct declarations
                IEnumerable<StructDeclarationSyntax> structDeclarations = namespaceDeclaration.DescendantNodes().OfType<StructDeclarationSyntax>();
                foreach (var structDeclaration in structDeclarations)
                {
                    File.WriteAllText($"{structDeclaration.Identifier.Text}.cs", $"{usings}\nnamespace {namespaceDeclaration.Name} {{ {structDeclaration.ToFullString()} }}");
                }
                Console.WriteLine("Done!");
            }
        }
    }
}
