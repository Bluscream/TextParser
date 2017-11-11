using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionParser {
    class Program {
        private static string inputFile = "input.txt";
        private static string outputFile = "output.txt";
        private static string[] input;
        private static List<string> output = new List<string>();
        static void Main(string[] args) {
            if (!File.Exists(inputFile)) {
                using (File.Create(inputFile)) { }
            }
            if (!File.Exists(outputFile)) {
                using (File.Create(outputFile)) { }
            }
            input = File.ReadAllLines(inputFile);
            output = File.ReadAllLines(outputFile).ToList();
            var changed = 0;
            foreach (var line in input) {
                var _line = line.Split(',');
                //var result = _line[0] + " [Build: " + _line[2] + "]," + _line[5] + "," + _line[4];
                var result = _line[0] + "," + _line[2] + "," + _line[3];
                Console.WriteLine(result.ToString());
                if (!output.Where(o => string.Equals(result, o, StringComparison.OrdinalIgnoreCase)).Any())
                    changed++;
                    output.Add(result);
                    //File.AppendAllText(outputFile, result + "\r\n");
            }
            if (changed > 0)
                File.Delete(outputFile);
                File.WriteAllLines(outputFile, output);
                Console.WriteLine("New Entries: " + changed);
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
