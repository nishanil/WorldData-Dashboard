using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorldData.Repository
{
    public static class DataProvider
    {
        private static Assembly assembly;

        static DataProvider()
        {
            assembly = typeof(DataProvider).GetTypeInfo().Assembly;
        }
        /// <summary>
        /// Gets stream of embedded resource file in specified assembly or already added assemblies
        /// </summary> 
        public static Stream GetResourceStream(string fileName)
        {
            return  assembly.GetManifestResourceStream(fileName);
        }

        /// <summary>
        /// Gets content of text file as list of strings
        /// </summary> 
        public static List<string> GetResourceTextFile(string fileName)
        {
            var result = new List<string>();
            var stream = GetResourceStream(fileName);

            using (var sr = new StreamReader(stream))
            {
                do
                {
                    var line = sr.ReadLine();
                    if (line != null)
                    {
                        result.Add(line);
                    }
                } while (sr.Peek() != -1);
            }
            return result;
        }

     
        /// <summary>
        /// Gets content of csv file as list of list of strings
        /// </summary> 
        public static List<List<string>> GetResourceCsvFile(string fileName,
                                                             char fileSeperator = ',')
        {
            var textFileLines = GetResourceTextFile(fileName);
            if (textFileLines.Count == 0)
            {
                Debug.WriteLine("Found no csv lines in file: " + fileName);
            }

            return textFileLines.Select(line => line.Split(fileSeperator).ToList()).ToList();
        }

        /// <summary>
        /// Gets content of csv file as <see cref="CsvDataTable"/>
        /// </summary> 
        public static CsvDataTable GetResourceCsvFileData(string fileName)
        {
            var csvStrings = GetResourceCsvFile(fileName);
            return new CsvDataTable(csvStrings);
        }
    }
}
