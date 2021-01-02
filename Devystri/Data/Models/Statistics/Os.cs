using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Statistics
{
    enum OS
    {
        IOS,
        MACOS,
        WINDOWS,
        LINUX,
        ANDROID,
        OTHER
    }
    public class OSStats
    {
        public int Id { get; set; }
        public int OsId { get; set; }
        public string OsName{ get; set; }
        public int Counts{ get; set; }
    }
}
