using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondConsoleAPI.Exeption
{
    [Serializable]
    public class NotInitializedExeption : Exception
    {
        public NotInitializedExeption() : base() { }
        public NotInitializedExeption(string message) : base(message) { }
        public NotInitializedExeption(string message, System.Exception inner) : base(message, inner) { }
        protected NotInitializedExeption(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
