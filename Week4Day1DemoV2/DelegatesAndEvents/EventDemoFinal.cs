using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Day1Demo.DelegatesAndEvents
{
    // Step 1: Declare a delegate
    internal delegate void NotifyDelegate(FileNotifyInfo fileNotifyInfo);

    internal class FileSearcherWithEvent
    {
        // Step 2: Declare a delegate variable with the event keyword
        public event NotifyDelegate Notify;

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
                        Notify.Invoke(new FileNotifyInfo(lineNo, wordCount, (int)((readFileSize * 100)/totalFileSize)));
                }
            }

            sr.Close();

            return wordCount;
        }
    }

    internal class EventDemoFinal
    {
        internal static void Demo()
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            var filePaths = new string[] {
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test1.txt",
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test2.txt",
            @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\17-Jan-2021\Week4Day1Demo\Week4Day1Demo\DelegatesAndEvents\files\test3.txt"};

            var fileSearcherWithEvent = new FileSearcherWithEvent();
            fileSearcherWithEvent.Notify += FileSearcherWithEvent_Notify;

            foreach (var filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                Console.WriteLine($"Reading file {fileInfo.Name} ({fileInfo.Length/1024/1024:n0} mb)");
                var wordCount = fileSearcherWithEvent.FindWordCount(filePath);
                Console.WriteLine($"{wordCount:n0} words found!");
            }
        }

        private static void FileSearcherWithEvent_Notify(FileNotifyInfo fileNotifyInfo)
        {
            Console.Write($"\r [{fileNotifyInfo.PercentCompleted}%]. Processing Line: {fileNotifyInfo.LineNo:n0} and found {fileNotifyInfo.WordCount:n0} words till now.");
        }

        // Event notification fires by calling this method

    }
}
