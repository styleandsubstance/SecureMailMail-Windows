using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.Util.Pipeline
{
    interface Pipe
    {
        void SetupPipeline(Pipe input, Pipe output);

        void Process();

        int Read(byte[] buffer, int numBytesToRead);
    }
}
