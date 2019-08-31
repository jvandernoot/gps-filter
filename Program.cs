using System;
using System.IO;
using System.Text;

namespace jvandernoot.GpsFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var cla = ValidateInput(args);

            if (cla == null) return;

            var rawSource = File.ReadAllText(cla.SourceFilePath);
            var sourceRecords = rawSource.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            string previousDate = "";
            bool headerHandled = false;
            int counter = 0;
            StringBuilder output = new StringBuilder();

            foreach (var unsplit in sourceRecords)
            {
                if (!headerHandled)
                {
                    output.AppendLine(unsplit);
                    headerHandled = true;
                    continue;
                }

                var fields = unsplit.Split(',');
                var currentDate = fields[1];

                if (previousDate != currentDate)
                {
                    previousDate = currentDate;
                    output.AppendLine(unsplit);
                    counter++;
                }
            }

            var fileInfo = new FileInfo(cla.SourceFilePath);
            var outputPath = fileInfo.FullName.Replace(fileInfo.Extension, "_output" + fileInfo.Extension);
            File.WriteAllText(outputPath, output.ToString());
            Console.WriteLine($"Consolidated {sourceRecords.Length} to {counter}.");
        }

        private class CommandLineArgs
        {
            public string SourceFilePath { get; set; }
        }

        private static CommandLineArgs ValidateInput(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Must provide a path to the source file.");
                return null;
            }

            var cla = new CommandLineArgs { SourceFilePath = args[0] };

            if (cla.SourceFilePath == null || !File.Exists(cla.SourceFilePath))
            {
                Console.WriteLine("The file path provided does not exist.");
                return null;
            }

            return cla;
        }
    }
}
