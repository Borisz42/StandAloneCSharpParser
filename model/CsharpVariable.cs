using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StandAloneCSharpParser.model
{
    class CsharpVariable : CsharpTypedEntity
    {
        public bool IsProperty { get; set; } = false;
    }
}
