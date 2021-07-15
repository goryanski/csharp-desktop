using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Models
{
    [Serializable]
    public class Question
    {
        public string Text { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();

        public override string ToString() => $"{Text}";
    }
}
