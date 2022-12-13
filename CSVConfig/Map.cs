using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVSTask.CSVConfig
{
    public sealed class Map : ClassMap<Headers>
    {
        public Map()
        {
            Map(m => m.LastName).Name("Last name");
            Map(m => m.FirstName).Name("First name");
            Map(m => m.SSN);
            Map(m => m.Test1);
            Map(m => m.Test2);
            Map(m => m.Test3);
            Map(m => m.Test4);
            Map(m => m.Final);
            Map(m => m.Grade);

        }
    }
}
