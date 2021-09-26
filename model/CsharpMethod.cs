using System.Collections.Generic;

namespace StandAloneCSharpParser.model
{
    class CsharpMethod : CsharpTypedEntity
    {
        public HashSet<CsharpVariable> CsharpMethodParams { get; set; } = new HashSet<CsharpVariable>();
        public HashSet<CsharpVariable> CsharpMethodLocals { get; set; } = new HashSet<CsharpVariable>();
        public string DocumentationCommentXML { get; set; }

        public void AddParam(CsharpVariable var)
        {
            CsharpMethodParams.Add(var);
        }
        public void AddLocal(CsharpVariable var)
        {
            CsharpMethodLocals.Add(var);
        }
    }
}
