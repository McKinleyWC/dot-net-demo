using System.Collections.Generic;

namespace DAL
{
    public class AnnualProdReport
    {
        public string resource_id { get; set; }
        public List<Field> fields { get; set; }
        public List<Record> records { get; set; }
        public _Links _links { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class _Links
    {
        public string start { get; set; }
        public string next { get; set; }
    }

    public class Field
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Record
    {
        public string _5Bills { get; set; }
        public string _50Bills { get; set; }
        public string _10Bills { get; set; }
        public string FiscalYear { get; set; }
        public string _1Bills { get; set; }
        public string _20Bills { get; set; }
        public int _id { get; set; }
        public string _2Bills { get; set; }
        public string _100Bills { get; set; }
    }
}