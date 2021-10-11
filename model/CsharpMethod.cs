using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StandAloneCSharpParser.model
{
    class CsharpMethod : CsharpTypedEntity
    {
        [Column("MethodParam")] //Nem csinált semmit, a CsharpVariable osztálynál kéne jelölni
        public HashSet<CsharpVariable> CsharpMethodParams { get; set; } = new HashSet<CsharpVariable>();
        [Column("MethodLocal")]
        public HashSet<CsharpVariable> CsharpMethodLocals { get; set; } = new HashSet<CsharpVariable>();

        public void AddParam(CsharpVariable var)
        {
            CsharpMethodParams.Add(var);
        }
        public void AddParams(HashSet<CsharpVariable> vars)
        {
            CsharpMethodParams.UnionWith(vars);
        }
        public void AddLocal(CsharpVariable var)
        {
            CsharpMethodLocals.Add(var);
        }
        public void AddLocals(HashSet<CsharpVariable> vars)
        {
            CsharpMethodLocals.UnionWith(vars);
        }
    }
}
