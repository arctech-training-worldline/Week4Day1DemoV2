namespace Week4Day1DemoV2.DelegatesAndEvents
{
    /// <summary>
    /// From a given list of files, read each file and display the number of words inside the file.
    /// </summary>
    /// 

    struct FileNotifyInfo
    {
        public long LineNo { get; set; }
        public long WordCount { get; set; }
        public int PercentCompleted { get; set; }

        public FileNotifyInfo(long lineNo, long wordCount, int percentCompleted)
        {
            LineNo = lineNo;
            WordCount = wordCount;
            PercentCompleted = percentCompleted;
        }
    }
}
