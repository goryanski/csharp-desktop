using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3.Models
{
    [Serializable]
    public class Test
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public int Minutes { get; set; }

        public override string ToString() => $"{Name}";
    }
}
