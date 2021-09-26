using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StandAloneCSharpParser.model;
using Microsoft.CodeAnalysis;

namespace StandAloneCSharpParser
{
    class AstVisitor : CSharpSyntaxWalker
    {
        private readonly CsharpDbContext DbContext;
        private readonly SemanticModel Model;
        private readonly SyntaxTree Tree;

        public AstVisitor(CsharpDbContext context, SemanticModel model, SyntaxTree tree)
        {
            this.DbContext = context;
            this.Model = model;
            this.Tree = tree;
        }

        private void AstNode(SyntaxNode node)
        {
            CsharpAstNode astNode = new CsharpAstNode
            {
                AstValue = node.ToString(),
                RawKind = node.RawKind,
                EntityHash = node.GetHashCode()
            };
            astNode.Location(Tree.GetLineSpan(node.Span));

            DbContext.CsharpAstNodes.Add(astNode);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            WriteLine($"\n MethodDeclaration visited: {node.Identifier}");
            string qName = "";
            try
            {
                qName = Model.GetDeclaredSymbol(node).ToString();
            }
            catch (Exception)
            {
                WriteLine($"Can not get QualifiedName of this name: {node.Identifier}");
            }

            string qType = "";
            try
            {
                qType = Model.GetSymbolInfo(node.ReturnType).Symbol.ToString();
            }
            catch (Exception)
            {
                WriteLine($"Can not get QualifiedType of this Type: {node.ReturnType}");
            }           

            CsharpMethod method = new CsharpMethod
            {
                Name = node.Identifier.Text,
                QualifiedName = qName,
                QualifiedType = qType,
                DocumentationCommentXML = Model.GetDeclaredSymbol(node).GetDocumentationCommentXml(),
                TypeHash = qType.GetHashCode()
            };

            // WriteLine($"\t{node.Identifier.Text}.Parameters.Count: {node.ParameterList.Parameters.Count}");
            if (node.ParameterList.Parameters.Count >0 )
            {
                foreach (var param in node.ParameterList.Parameters)
                {
                    // WriteLine($"\t\t{param.Identifier} : {param.Type}");
                    string paramQType = "";
                    try
                    {
                        paramQType = Model.GetSymbolInfo(param.Type).Symbol.ToString();
                    }
                    catch (Exception)
                    {
                        WriteLine($"Can not get QualifiedType of this Type: {param.Type}");
                    }
                    CsharpVariable varibale = new CsharpVariable
                    {
                        Name = param.Identifier.Text,
                        QualifiedType = paramQType,
                        TypeHash = paramQType.GetHashCode()
                    };
                    method.AddParam(varibale);
                    AstNode(node);
                }
            }

            foreach(VariableDeclarationSyntax variableDeclaration in node.Ancestors().OfType<VariableDeclarationSyntax>())
            {
                foreach (var variable in variableDeclaration.Variables)
                {               
                    string varQType = "";
                    try
                    {
                        varQType = Model.GetSymbolInfo(variableDeclaration.Type).Symbol.ToString();
                    }
                    catch (Exception)
                    {
                        WriteLine($"Can not get QualifiedType of this Type: {variableDeclaration.Type}");
                    }
                    CsharpVariable varibale = new CsharpVariable
                    {
                        Name = variable.Identifier.Text,
                        QualifiedType = varQType,
                        TypeHash = varQType.GetHashCode()
                    };
                    method.AddLocal(varibale);
                    AstNode(node);
                }
            }
            DbContext.CsharpMethods.Add(method);
            AstNode(node);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            WriteLine($"\n ClassDeclaration visited: {node.Identifier.Text}");
            base.VisitClassDeclaration(node); //Needed to traverse recursively
        }

        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            WriteLine($"\nEnumDeclaration visited: {node.Identifier.Text}");
            WriteLine($"\t{node.Identifier.Text}.Members.Count: {node.Members.Count}");
            WriteLine($"\t{node.Identifier.Text}.Members:");
            foreach (var mem in node.Members)
            {
                WriteLine($"\t\t{mem.Identifier}");
            }
            AstNode(node);
        }

        public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            WriteLine($"\n VariableDeclaration visited:");
            foreach(var variable in node.Variables)
            {
              //  WriteLine($"\tType: {node.Type}\n\tName: {variable.Identifier.Text}\n\tInit:{variable.Initializer}\n");
            }
            AstNode(node);
        }

        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            WriteLine($"\n PropertyDeclaration visited: { node.Identifier}");
            AstNode(node);
        }
    }
}
