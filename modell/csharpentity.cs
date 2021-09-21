using System;

namespace StandAloneCSharpParser.modell
{
    class CsharpEntity
    {
        public long id { get; set; }
        public long astNodeId { get; set; }
        public long entityHash { get; set; }
        public String name { get; set; }
        public String qualifiedName { get; set; }
    }

    class CsharpTypedEntity : CsharpEntity
    {
        public long typeHash { get; set; }
        public String qualifiedType { get; set; }
    }
}
