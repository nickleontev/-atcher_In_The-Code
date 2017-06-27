using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Programming_4_semestr_3_lab
{
    [System.Serializable]
    class SpaceIndexOutOfBoundsException : Exception
    {
        public SpaceIndexOutOfBoundsException() { }
        public SpaceIndexOutOfBoundsException(string message) : base(message) { }
        public SpaceIndexOutOfBoundsException(string message, Exception inner) : base(message, inner) { }
        protected SpaceIndexOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public override string Message { get { return " Ошибка выхода за границы номеров помещений "; } }
    }
}
