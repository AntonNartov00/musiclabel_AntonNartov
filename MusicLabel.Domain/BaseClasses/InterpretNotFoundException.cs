using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLabel.Domain.BaseClasses
{
    public class InterpretNotFoundException : Exception
    {
        public InterpretNotFoundException()
        {

        }

        public InterpretNotFoundException(string message)
            : base(message)
        {
            
        }
    }
}
