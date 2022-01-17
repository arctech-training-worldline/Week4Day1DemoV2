using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Day1Demo.DelegatesAndEvents
{
    /// <summary>
    /// From a given list of files, read each file and display the number of words inside the file.
    /// </summary>
    ///  

    // Step 1: No need to create own delegate
    //internal delegate void NotifyDelegate(FileNotifyInfo fileNotifyInfo);

    internal class FileSearcherWithInBuiltEvent
    {
        // Step 2: Use the inbuild EventHandler delegate to declare the event
        //public event NotifyDelegate Notify;
        public event EventHandler<FileNotifyInfo> Notify;

        internal long FindWordCount(string fileName)
        { 
            FileInfo fileInfo = new FileInfo(fileName);
            long totalFileSize = fileInfo.Length;
            long readFileSize = 0;

            StreamReader sr = new StreamReader(fileName);

            long wordCount = 0;
            long lineNo = 0;
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                readFileSize += line.Length;
                lineNo++;

                foreach (var ch in line)
                {
                    if(ch == ' ')
                        wordCount++;
                }

                if (lineNo % 10000 == 0)    // If lineNo is divisible by 10000 i.e. every 10,000 lines, invoke the event
                {
                    // Step 3: Invoke the event where required.
                    if (Notify != null)
                        Notify.Invoke(this, new FileNotifyInfo(lineNo, wordCount, (int)((readFileSize * 100)/totalFileSize)));
                }
            }

            sr.Close();

            return wordCount;
        }
    }

    internal class EventDemoFinalFinal
    {
        internal static void Demo()
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            var filePaths = new string[] {
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test1.txt",
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test2.txt",
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test3.txt"};

            var fileSearcherWithInBuiltEvent = new FileSearcherWithInBuiltEvent();
            fileSearcherWithInBuiltEvent.Notify += FileSearcherWithInBuiltEvent_Notify;

            foreach (var filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                Console.WriteLine($"Reading file {fileInfo.Name} ({fileInfo.Length/1024/1024:n0} mb)");
                var wordCount = fileSearcherWithInBuiltEvent.FindWordCount(filePath);
                Console.WriteLine($"{wordCount:n0} words found!");
            }
        }

        private static void FileSearcherWithInBuiltEvent_Notify(object sender, FileNotifyInfo fileNotifyInfo)
        {
            Console.Write($"\r [{fileNotifyInfo.PercentCompleted}%]. Processing Line: {fileNotifyInfo.LineNo:n0} and found {fileNotifyInfo.WordCount:n0} words till now.");
        }

        // Event notification fires by calling this method

    }
}
