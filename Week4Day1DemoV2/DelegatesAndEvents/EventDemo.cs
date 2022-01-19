using System;
using System.IO;

namespace Week4Day1DemoV2.DelegatesAndEvents
{
    /// <summary>
    /// From a given list of files, read each file and display the number of words inside the file.
    /// </summary>
    /// 

    internal class FileSearcher
    {
        internal long FindWordCount(string fileName)
        { 
            StreamReader sr = new StreamReader(fileName);

            long wordCount = 0;

            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                foreach (var ch in line)
                {
                    if(ch == ' ')
                        wordCount++;
                }

                //Add below if you want to slow down this function
                //Thread.Sleep(10);
            }

            sr.Close();

            return wordCount;
        }
    }

    internal class EventDemo
    {
        internal static void Demo()
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            var filePaths = new string[] {
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test1.txt",
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test2.txt",
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test3.txt"};

            FileSearcher fileSearcher = new FileSearcher();

            foreach (var filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                Console.WriteLine($"Reading file {fileInfo.Name} ({fileInfo.Length/1024/1024:n0} mb)");
                var wordCount = fileSearcher.FindWordCount(filePath);
                Console.WriteLine($"{wordCount:n0} words found!");
            }
        }
    }
}
