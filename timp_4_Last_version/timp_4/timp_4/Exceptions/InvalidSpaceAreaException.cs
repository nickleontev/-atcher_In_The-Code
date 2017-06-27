using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace timp_4
{
    class InvalidSpaceAreaException : Exception
    {
        public InvalidSpaceAreaException() { }
        public InvalidSpaceAreaException(string message) : base(message) { }
        public InvalidSpaceAreaException(string message, Exception inner) : base(message, inner) { }
        protected InvalidSpaceAreaException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override string Message { get { return " Ошибка некорретной площади помещения "; } }
    }
}
