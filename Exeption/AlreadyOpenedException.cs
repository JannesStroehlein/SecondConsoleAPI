using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondConsoleAPI.Exeption
{
    [Serializable]
    public class AlreadyOpenedException : Exception
    {
        public AlreadyOpenedException() : base() { }
        public AlreadyOpenedException(string message) : base(message) { }
        public AlreadyOpenedException(string message, System.Exception inner) : base(message, inner) { }
        protected AlreadyOpenedException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
