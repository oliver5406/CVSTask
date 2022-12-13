using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CVSTask.CSVAction
{
    internal class CSVFunctions
    {
        internal static void CSVModifier(string oldFilePath, string newFilePath, string gradeToChange, string newGrade)
        {
            var reader = new StreamReader(oldFilePath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<CSVConfig.Map>();
            var records = csv.GetRecords<CSVConfig.Headers>();

            using (var streamWriter = new StreamWriter(newFilePath))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                foreach (var record in records)
                {
                    if (record.Grade == gradeToChange)
                    {
                        record.Grade = newGrade;
                        csvWriter.WriteRecord(record);
                        Console.WriteLine($"{record.Grade} changed");
                    }
                    else
                    {
                        csvWriter.WriteRecord(record);
                        Console.WriteLine($"{record.Grade} unchanged");
                    }
                    csvWriter.NextRecord();
                }
            }

        }

        internal static void CSVWordCounter(string path, string gradeToCount)
        {
            var reader = new StreamReader(path);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<CSVConfig.Map>();
            var records = csv.GetRecords<CSVConfig.Headers>();

            int gradeCounter = 0;

            foreach (var record in records)
            {
                if (record.Grade == gradeToCount)
                    gradeCounter++;
                //Console.WriteLine($"{record.FirstName} {record.LastName} scored {record.Final}" +
                //    $" which is a grade {record.Grade}");
            }
            Console.WriteLine();
            Console.WriteLine($"There are a total of {gradeCounter} {gradeToCount}'s");
        }
    }
}

