using static System.Console;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;
using StandAloneCSharpParser.model;

namespace StandAloneCSharpParser
{
    class Program
    {

        static void Main(string[] args)
        {
            string programPath = @"C:\Users\Borisz\Desktop\parser\filesToParse\CentroidBasedClustering.cs";
            string programText = File.ReadAllText(programPath);
            SyntaxTree tree = CSharpSyntaxTree.ParseText(programText);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            CSharpCompilation compilation = CSharpCompilation.Create("CSharpCompilation")
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddSyntaxTrees(tree);

            SemanticModel model = compilation.GetSemanticModel(tree);
            CsharpDbContext dbContext = new CsharpDbContext();
            

            var visitor = new AstVisitor(dbContext, model, tree);
            visitor.Visit(root);

        }
    }
}
