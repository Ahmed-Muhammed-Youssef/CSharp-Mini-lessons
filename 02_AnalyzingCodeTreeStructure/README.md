# Dissecting C# Code with Roslyn Compiler

## Overview

This mini-lesson demonstrates how to use the Roslyn compiler platform to break down a string of C# code into distinct entities such as namespaces, classes, interfaces, and structs. By leveraging the Roslyn compiler, we can parse C# code into a syntax tree, navigate through its structure, and extract useful information.

## Prerequisites

Before starting, ensure you have the following:

- **Visual Studio** or any C# code editor installed.
- Basic knowledge of C# syntax and structure.

## Lesson Structure

### 1. Parsing C# Code into a Syntax Tree

The core functionality involves parsing a string of C# code into a syntax tree using Roslyn. Here's an example snippet:

```csharp
SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
```

This code snippet initializes a syntax tree by parsing the provided C# code.

### 2. Extracting Using Directives and Namespaces

The lesson proceeds by extracting using directives and namespaces from the syntax tree. Here's an example snippet:

```csharp
IEnumerable<UsingDirectiveSyntax> usingDirectives = root.DescendantNodes().OfType<UsingDirectiveSyntax>();
IEnumerable<NamespaceDeclarationSyntax> namespaceDeclarations = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>();
```

These snippets show how to retrieve using directives and namespace declarations from the parsed code.

### 3. Retrieving Classes, Interfaces, and Structs

The lesson then demonstrates how to navigate deeper into the syntax tree to find class, interface, and struct declarations. Here's an example:

```csharp
IEnumerable<ClassDeclarationSyntax> classDeclarations = namespaceDeclaration.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>();
IEnumerable<InterfaceDeclarationSyntax> interfaceDeclarations = namespaceDeclaration.DescendantNodes().OfType<InterfaceDeclarationSyntax>();
IEnumerable<StructDeclarationSyntax> structDeclarations = namespaceDeclaration.DescendantNodes().OfType<StructDeclarationSyntax>();
```

These snippets showcase how to identify and retrieve classes, interfaces, and structs within a specific namespace.

### 4. Writing Extracted Entities into Files

Finally, the lesson illustrates how to write the extracted entities into separate files for further use:

```csharp
File.WriteAllText($"{classDeclaration.Identifier.Text}.cs", $"{usings}\nnamespace {namespaceDeclaration.Name} {{ {classDeclaration.ToFullString()} }}");
// Similar code for interfaces and structs
```

## Usage

Clone this repository and open the solution in Visual Studio. Follow along with the code and comments to understand how Roslyn is used to dissect C# code into its constituent entities.

Experiment by adding your C# code strings and observe how Roslyn dissects them.

Enjoy dissecting C# code with Roslyn!
