using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace timp_4.Exceptions
{
    class InexchangeableSpacesException : Exception
    {
        public InexchangeableSpacesException() { }
        public InexchangeableSpacesException(string message) : base(message) { }
        public InexchangeableSpacesException(string message, Exception inner) : base(message, inner) { }
        protected InexchangeableSpacesException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override string Message { get { return " Ошибка: Помещения не соответвуют друг другу "; } }
    }
}
