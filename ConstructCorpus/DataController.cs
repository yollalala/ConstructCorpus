using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructCorpus
{
    class DataController
    {
        public static void addToFile(string outputFile, string text)
        {
            // add text to outputFile
            File.AppendAllText(outputFile, text + Environment.NewLine);
            //File.AppendAllText(outputFile, text);

        }

        public static string readFile(string directory)
        {
            string content = File.ReadAllText(directory);

            return content;
        }

        public static string[] readFileToArray(string directory)
        {
            string[] content = File.ReadAllLines(directory);

            return content;
        }
    }
}
