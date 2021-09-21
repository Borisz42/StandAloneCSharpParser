using static System.Console;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;

namespace StandAloneCSharpParser
{
    class Program
    {

        static void Main(string[] args)
        {
            String programPath = @"C:\Users\Borisz\Desktop\parser\filesToParse\CentroidBasedClustering.cs";
            String programText = File.ReadAllText(programPath);
            SyntaxTree tree = CSharpSyntaxTree.ParseText(programText);
            CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
            SyntaxNode node = root;

            var visitor = new AstVisitor();
            visitor.Visit(root);

        }
    }
}
