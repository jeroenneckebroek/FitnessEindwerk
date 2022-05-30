using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Domain
{
    public class FitnessException : Exception
    {
        public FitnessException()
        {
        }

        public FitnessException(string message) : base(message)
        {
        }

        public FitnessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FitnessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
