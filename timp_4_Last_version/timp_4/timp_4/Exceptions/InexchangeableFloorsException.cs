using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace timp_4.Exceptions
{
    class InexchangeableFloorsException : Exception
    {
        public InexchangeableFloorsException() { }
        public InexchangeableFloorsException(string message) : base(message) { }
        public InexchangeableFloorsException(string message, Exception inner) : base(message, inner) { }
        protected InexchangeableFloorsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override string Message { get { return " Ошибка: Этажи не соответвуют друг другу "; } }
    }
    
}
