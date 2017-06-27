using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace timp_4
{
    class FloorIndexOutOfBoundsException : Exception
    {
        public FloorIndexOutOfBoundsException() { }
        public FloorIndexOutOfBoundsException(string message) : base(message) { }
        public FloorIndexOutOfBoundsException(string message, Exception inner) : base(message, inner) { }
        protected FloorIndexOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override string Message { get { return " Ошибка выхода за границы номеров этажей "; } }
    }
}

