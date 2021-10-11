using System.Collections.Generic;

namespace StandAloneCSharpParser.model
{
    class CsharpClass : CsharpEntity
    {
        public CsharpNamespace CsharpNamespace { get; set; }
        public HashSet<CsharpVariable> CsharpClassLocals { get; set; } = new HashSet<CsharpVariable>();
        public HashSet<CsharpMethod> CsharpClassMethods { get; set; } = new HashSet<CsharpMethod>();
        public void AddVariable(CsharpVariable var)
        {
            CsharpClassLocals.Add(var);
        }
        public void AddVariables(HashSet<CsharpVariable> vars)
        {
            CsharpClassLocals.UnionWith(vars);
        }
        public void AddMethod(CsharpMethod method)
        {
            CsharpClassMethods.Add(method);
        }
    }

    class CsharpStruct : CsharpEntity
    {
        public CsharpNamespace CsharpNamespace { get; set; }
        public HashSet<CsharpVariable> CsharpStructLocals { get; set; } = new HashSet<CsharpVariable>();
        public HashSet<CsharpMethod> CsharpStructMethods { get; set; } = new HashSet<CsharpMethod>();
        public void AddVariable(CsharpVariable var)
        {
            CsharpStructLocals.Add(var);
        }
        public void AddVariables(HashSet<CsharpVariable> vars)
        {
            CsharpStructLocals.UnionWith(vars);
        }
        public void AddMethod(CsharpMethod method)
        {
            CsharpStructMethods.Add(method);
        }
    }
}
