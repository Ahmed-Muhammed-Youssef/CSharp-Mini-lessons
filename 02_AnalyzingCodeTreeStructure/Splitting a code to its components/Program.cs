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
                "} \n}"; // Code Sample
            ProcessCSharpCode(code);

        }
        /// <summary>
        /// Parses the provided C# code into a syntax tree and extracts various elements.
        /// </summary>
        /// <param name="code">The C# code to be parsed.</param>
        public static void ProcessCSharpCode(string code)
        {
            // Parse the code into a syntax tree
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

            // Get all using directives within the code
            IEnumerable<UsingDirectiveSyntax> usingDirectives = root.DescendantNodes().OfType<UsingDirectiveSyntax>();

            // Combine all using directives into a single string
            string usings = string.Join("\n", usingDirectives.Select(u => u.ToFullString()));

            /// Get all namespace declarations within the code
            IEnumerable<NamespaceDeclarationSyntax> namespaceDeclarations = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>();

            foreach (var namespaceDeclaration in namespaceDeclarations)
            {
                // Get all class declarations within each namespace
                IEnumerable<ClassDeclarationSyntax> classDeclarations = namespaceDeclaration.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>();
                foreach (var classDeclaration in classDeclarations)
                {
                    // Write the class content to a file named after the class
                    File.WriteAllText($"{classDeclaration.Identifier.Text}.cs", $"{usings}\nnamespace {namespaceDeclaration.Name} {{ {classDeclaration.ToFullString()} }}");
                }

                // Get all interface declarations within each namespace
                IEnumerable<InterfaceDeclarationSyntax> interfaceDeclarations = namespaceDeclaration.DescendantNodes().OfType<InterfaceDeclarationSyntax>();
                foreach (var interfaceDeclaration in interfaceDeclarations)
                {
                    // Write the interface content to a file named after the interface
                    File.WriteAllText($"{interfaceDeclaration.Identifier.Text}.cs", $"{usings}\nnamespace {namespaceDeclaration.Name} {{ {interfaceDeclaration.ToFullString()} }}");
                }

                // Get all struct declarations within each namespace
                IEnumerable<StructDeclarationSyntax> structDeclarations = namespaceDeclaration.DescendantNodes().OfType<StructDeclarationSyntax>();
                foreach (var structDeclaration in structDeclarations)
                {
                    // Write the struct content to a file named after the struct
                    File.WriteAllText($"{structDeclaration.Identifier.Text}.cs", $"{usings}\nnamespace {namespaceDeclaration.Name} {{ {structDeclaration.ToFullString()} }}");
                }

                Console.WriteLine("Done!");
            }
        }
    }
}
