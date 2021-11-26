using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Feedback
    {
        public enum Type
        {
            Success,
            Warning,
            Error
        }
        public Type MessageType { get; private set; }
        public string Message { get; private set; }
        public Feedback(Type type, string message)
        {
            this.MessageType = type;
            this.Message = message;
        }
    }
}
