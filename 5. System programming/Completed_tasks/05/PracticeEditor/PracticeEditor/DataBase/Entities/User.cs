using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEditor.DataBase.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public override string ToString() => $"{FullName}, age: {Age}";
        
    }
}
