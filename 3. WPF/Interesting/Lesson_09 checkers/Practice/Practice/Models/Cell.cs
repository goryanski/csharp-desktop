using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practice.Models
{
    public class Cell : Label
    {
        public int Row { get; set; }
        public int Column { get; set; }

        // создадим возможность для хранения другой клетки в этой 
        public Cell EnemyCell { get; set; }
        public bool IsQueen { get; set; }
    }
}
