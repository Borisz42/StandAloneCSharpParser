using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StandAloneCSharpParser
{
    class AstVisitor : CSharpSyntaxWalker
    {
        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            WriteLine($"MethodDeclaration visited: {node.Identifier.Text}");
            WriteLine($"\t{node.Identifier.Text}.ReturnType: {node.ReturnType}");
            WriteLine($"\t{node.Identifier.Text}.Parameters.Count: {node.ParameterList.Parameters.Count}");
            if (node.ParameterList.Parameters.Count >0 )
            {
                WriteLine($"\t{node.Identifier.Text}.Parameters:");
                foreach (var param in node.ParameterList.Parameters)
                {
                    WriteLine($"\t\t{param.Identifier} : {param.Type}");
                }
            }
            /*
            if (node.HasLeadingTrivia)
            {
                WriteLine("\tLeading trivias:");
                foreach (var triv in node.GetLeadingTrivia())
                {
                    WriteLine($"\t\t{triv} ");
                }
            }
            */
            //WriteLine(node.ToFullString());
            WriteLine();
        }


        public override void VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node)
        {
            WriteLine($"VisitDocumentationCommentTrivia find: {node.Content}");
        }

        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            WriteLine($"EnumDeclaration visited: {node.Identifier.Text}");
            WriteLine($"\t{node.Identifier.Text}.Members.Count: {node.Members.Count}");
            WriteLine($"\t{node.Identifier.Text}.Members:");
            foreach (var mem in node.Members)
            {
                WriteLine($"\t\t{mem.Identifier}");
            }

            WriteLine();
        }

        public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            WriteLine($"VariableDeclaration visited:");
            foreach(var variable in node.Variables)
            {
                WriteLine($"\tType: {node.Type}\n\tName: {variable.Identifier.Text}\n\tInit:{variable.Initializer}\n");
            }

            WriteLine();
        }
    }
}
