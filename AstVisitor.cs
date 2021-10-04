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
        private readonly List<CsharpNamespace> CsharpNamespaces = new List<CsharpNamespace>();

        public AstVisitor(CsharpDbContext context, SemanticModel model, SyntaxTree tree)
        {
            this.DbContext = context;
            this.Model = model;
            this.Tree = tree;
        }

        private CsharpAstNode AstNode(SyntaxNode node)
        {
            CsharpAstNode astNode = new CsharpAstNode
            {
                AstValue = node.ToString(),
                RawKind = node.RawKind,
                EntityHash = node. GetHashCode()
            };
            astNode.SetLocation(Tree.GetLineSpan(node.Span));
           // if (AstNodeHashCodes.Contains(node.GetHashCode())) WriteLine($"Kétszer szerepelt: {node}");
            DbContext.CsharpAstNodes.Add(astNode);
            return astNode;
        }

        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            //base.VisitUsingDirective(node);
            WriteLine($" UsingDirective name: {node.Name}");
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            CsharpAstNode astNode = AstNode(node);
            WriteLine($"\n NamespaceDeclaration visited: {node.Name}");
            string qName = "";
            try
            {
                qName = Model.GetDeclaredSymbol(node).ToString();
            }
            catch (Exception)
            {
                WriteLine($"Can not get QualifiedName of this name: {node.Name}");
            }

            CsharpNamespace csharpNamespace = new CsharpNamespace
            {
                AstNode = astNode,
                Name = node.Name.ToString(),
                QualifiedName = qName,
                DocumentationCommentXML = Model.GetDeclaredSymbol(node).GetDocumentationCommentXml(),
                EntityHash = astNode.EntityHash
            };

            CsharpNamespaces.Add(csharpNamespace);
            DbContext.CsharpNamespaces.Add(csharpNamespace);
            base.VisitNamespaceDeclaration(node);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            CsharpAstNode astNode = AstNode(node);
            base.VisitClassDeclaration(node);
            WriteLine($"\n ClassDeclaration visited: {node.Identifier.Text}");
            string qName = "";
            try
            {
                qName = Model.GetDeclaredSymbol(node).ToString();
            }
            catch (Exception)
            {
                WriteLine($"Can not get QualifiedName of this name: {node.Identifier}");
            }

            var nameSpaces = CsharpNamespaces.Where(n => qName.Contains(n.Name)).ToList();
            CsharpNamespace csharpNamespace = null;
            if (nameSpaces.Count == 1)
            {
                csharpNamespace = nameSpaces.First();
            }

            CsharpClass csharpClass = new CsharpClass
            {
                CsharpNamespace = csharpNamespace,
                AstNode = astNode,
                Name = node.Identifier.Text,
                QualifiedName = qName,
                DocumentationCommentXML = Model.GetDeclaredSymbol(node).GetDocumentationCommentXml(),
                EntityHash = astNode.EntityHash
            };

            foreach (VariableDeclarationSyntax variableDeclaration in node.Members.OfType<VariableDeclarationSyntax>())
            {
                WriteLine($"Variable name: {variableDeclaration.Variables.First().Identifier}");
                csharpClass.AddVariables(VisitVariableDecl(variableDeclaration));
            }

            foreach (PropertyDeclarationSyntax propertyDeclaration in node.Members.OfType<PropertyDeclarationSyntax>())
            {
                csharpClass.AddVariable(VisitPropertyDecl(propertyDeclaration));
            }

            foreach (MethodDeclarationSyntax methodDeclaration in node.Members.OfType<MethodDeclarationSyntax>())
            {
                csharpClass.AddMethod(VisitMethodDecl(methodDeclaration));
            }

            DbContext.CsharpClasses.Add(csharpClass);
        }

        private CsharpMethod VisitMethodDecl(MethodDeclarationSyntax node)
        {
            CsharpAstNode astNode = AstNode(node);
           // WriteLine($"\n MethodDeclaration visited: {node.Identifier}");
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
                AstNode = astNode,
                Name = node.Identifier.Text,
                QualifiedName = qName,
                QualifiedType = qType,
                DocumentationCommentXML = Model.GetDeclaredSymbol(node).GetDocumentationCommentXml(),
                TypeHash = qType.GetHashCode(),
                EntityHash = astNode.EntityHash
            };

            // WriteLine($"\t{node.Identifier.Text}.Parameters.Count: {node.ParameterList.Parameters.Count}");
            if (node.ParameterList.Parameters.Count > 0)
            {
                method.AddParams(VisitMethodParameters(node.ParameterList.Parameters));
            }
            
            foreach (VariableDeclarationSyntax variableDeclaration in node.DescendantNodes().OfType<VariableDeclarationSyntax>())
            {
                method.AddLocals(VisitVariableDecl(variableDeclaration));
            }         

            return method;
        }

        private HashSet<CsharpVariable> VisitMethodParameters(SeparatedSyntaxList<ParameterSyntax> parameters)
        {
            HashSet<CsharpVariable> ret = new HashSet<CsharpVariable>();
            foreach (var param in parameters)
            {
                // WriteLine($"\t\t{param.Identifier} : {param.Type}");
                CsharpAstNode astNode = AstNode(param);
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
                    AstNode = astNode,
                    Name = param.Identifier.Text,
                    QualifiedType = paramQType,
                    TypeHash = paramQType.GetHashCode(),
                    EntityHash = astNode.EntityHash
                };
                ret.Add(varibale);
            }
            return ret;
        }

        private HashSet<CsharpVariable> VisitVariableDecl(VariableDeclarationSyntax node)
        {
            HashSet<CsharpVariable> variables = new HashSet<CsharpVariable>();

                foreach (var variable in node.Variables)
                {
                    CsharpAstNode astNode = AstNode(variable);
                    string varQType = "";
                    try
                    {
                        varQType = Model.GetSymbolInfo(node.Type).Symbol.ToString();
                    }
                    catch (Exception)
                    {
                        WriteLine($"Can not get QualifiedType of this Type: {node.Type}");
                    }
                    CsharpVariable csharpVariable = new CsharpVariable
                    {
                        AstNode = astNode,
                        Name = variable.Identifier.Text,
                        QualifiedType = varQType,
                        TypeHash = varQType.GetHashCode(),
                        DocumentationCommentXML = Model.GetDeclaredSymbol(variable).GetDocumentationCommentXml(),
                        EntityHash = astNode.EntityHash
                    };
                variables.Add(csharpVariable);
                }
            return variables;
        }

        private CsharpVariable VisitPropertyDecl(PropertyDeclarationSyntax node)
        {
            CsharpAstNode astNode = AstNode(node);
            string varQType = "";
            try
            {
                varQType = Model.GetSymbolInfo(node.Type).Symbol.ToString();
            }
            catch (Exception)
            {
                WriteLine($"Can not get QualifiedType of this Type: {node.Type}");
            }
            CsharpVariable variable = new CsharpVariable
            {
                AstNode = astNode,
                Name = node.Identifier.Text,
                QualifiedType = varQType,
                TypeHash = varQType.GetHashCode(),
                IsProperty = true,
                DocumentationCommentXML = Model.GetDeclaredSymbol(node).GetDocumentationCommentXml(),
                EntityHash = astNode.EntityHash
            };
            return variable;
        }

        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            WriteLine($"\n EnumDeclaration visited: {node.Identifier.Text}");
            CsharpAstNode astNode = AstNode(node);
            string qName = "";
            try
            {
                qName = Model.GetDeclaredSymbol(node).ToString();
            }
            catch (Exception)
            {
                WriteLine($"Can not get QualifiedName of this name: {node.Identifier}");
            }

            var nameSpaces = CsharpNamespaces.Where(n => qName.Contains(n.Name)).ToList();
            CsharpNamespace csharpNamespace = null;
            if (nameSpaces.Count == 1)
            {
                csharpNamespace = nameSpaces.First();
            }

            CsharpEnum csharpEnum = new CsharpEnum
            {
                CsharpNamespace = csharpNamespace,
                AstNode = astNode,
                Name = node.Identifier.Text,
                QualifiedName = qName,
                DocumentationCommentXML = Model.GetDeclaredSymbol(node).GetDocumentationCommentXml(),
                EntityHash = astNode.EntityHash
            };

            foreach (EnumMemberDeclarationSyntax enumMemberDeclarationSyntax in node.Members)
            {
                csharpEnum.AddMember(VisitEnumMemberDecl(enumMemberDeclarationSyntax));
            }
            DbContext.CsharpEnums.Add(csharpEnum);
        }

        private CsharpEnumMember VisitEnumMemberDecl(EnumMemberDeclarationSyntax node)
        {
            CsharpAstNode astNode = AstNode(node);
            string qName = "";
            try
            {
                qName = Model.GetDeclaredSymbol(node).ToString();
            }
            catch (Exception)
            {
                WriteLine($"Can not get QualifiedName of this name: {node.Identifier}");
            }
            CsharpEnumMember csharpEnumMember = new CsharpEnumMember
            {
                AstNode = astNode,
                Name = node.Identifier.Text,
                QualifiedName = qName,
                EntityHash = astNode.EntityHash
            };
            if (node.EqualsValue != null)
            {
                try
                {
                    csharpEnumMember.EqualsValue = int.Parse(node.EqualsValue.Value.ToString());
                }
                catch (FormatException)
                {
                    WriteLine($"Unable to parse '{node.EqualsValue.Value}'");
                }
            }
            return csharpEnumMember;
        }
    }
}
