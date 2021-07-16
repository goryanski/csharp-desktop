using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public enum State 
    { 
        Found,
        Edited
    };

    public class SelectedFile
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public long Size { get; set; }
        public State State { get; set; }
        public int ForbiddenWordsCount { get; set; } = 0;

        public override string ToString()
        {
            if (State == State.Edited)
            {
                return $"{Name} (Edited forbidden words: {ForbiddenWordsCount})";
            }
            return $"{FullPath}";
        }
    }
}
