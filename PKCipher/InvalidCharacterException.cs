using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Crypto
{ 
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException()
        {
            // Add implementation.
        }
        public InvalidCharacterException(string message)
        {
            // Add implementation.
        }
        public InvalidCharacterException(string message, Exception inner)
        {
            // Add implementation.
        }

        // This constructor is needed for serialization.
        protected InvalidCharacterException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }

    }
}