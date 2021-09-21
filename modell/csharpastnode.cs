namespace StandAloneCSharpParser.modell
{
    class CsharpAstNode
    {
        public int id { get; set; }
        public string astValue { get; set; }
        public long location_range_start_line { get; set; }
        public long location_range_start_column { get; set; }
        public long location_range_end_line { get; set; }
        public long location_range_end_column { get; set; }
        public long location_file { get; set; }
        public long entityHash { get; set; }
        public int rawKind { get; set; } //SyntaxKind Enum
        public int symbolType { get; set; } 
        public int astType { get; set; } 
        public bool visibleInSourceCode { get; set; }
    }
}
