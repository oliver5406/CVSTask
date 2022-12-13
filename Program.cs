using CsvHelper;
using CsvHelper.Configuration;
using CVSTask.CSVAction;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;

namespace CVSTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string parentPath = assemblyFolderPath.Remove(assemblyFolderPath.IndexOf("CVSTask"));
            string pathToCSV = @$"{parentPath}CVSTask\grades.csv";
            string newPathCSV = @$"{parentPath}CVSTask\gradesChanged.csv";

            Console.WriteLine("Which operation would you like to perform: " +
                "\n1.Count the number grades achived. " +
                "\n2.Modify a specific word in the CSV file.");
            int optionSelected = Int32.Parse(Console.ReadLine());

            switch (optionSelected)
            {
                case 1:
                    Console.WriteLine("Please enter a grade you would like to count. The options are A, B, C, D: ");
                    string userGradeChoice = Console.ReadLine();
                    CSVFunctions.CSVWordCounter(path: pathToCSV,
                                   gradeToCount: userGradeChoice);
                    break;
                case 2:
                    Console.WriteLine("What grade would you like to change?");
                    string gradeChosen = Console.ReadLine();
                    Console.WriteLine("What would you like to change the grade to?");
                    string newGrade = Console.ReadLine();
                    CSVFunctions.CSVModifier(oldFilePath: pathToCSV,
                                newFilePath: newPathCSV,
                                gradeToChange: gradeChosen,
                                newGrade: newGrade);
                    break;
                default:
                    Console.WriteLine("Option not available");
                    break;
            }
            Console.ReadLine();
        }

    }

}