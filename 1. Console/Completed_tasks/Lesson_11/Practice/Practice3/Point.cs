﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Point<T> where T : struct
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $@"{{{X}, {Y}}}";
        }
    }
}
