﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp_4
{
    class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value
        {
            get;
            internal set;
        }
          
        public Node<T> Next
        {
            get;
            internal set;
        }

    }
}