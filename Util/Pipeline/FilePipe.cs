using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecureMedMail.Util.Pipeline
{
    class FilePipe : BasicPipe, Pipe
    {
        private FileStream fileStream = null;
        private String filepath = null;
        byte[] dataBuffer = new byte[128 * 1024];

        public FilePipe(String filepath)
        {
            this.input = input;
            this.output = output;
            this.filepath = filepath;

            fileStream = new FileStream(this.filepath, FileMode.Open);
        }

        public void SetupPipeline(Pipe input, Pipe output)
        {
            this.input = input;
            this.output = output;
        }


        public int Read(byte[] buffer, int numBytesToRead)
        {

            lock (dataBuffer)
            {
                int numBytesRead = fileStream.Read(dataBuffer, 0, numBytesToRead);
                Array.Copy(dataBuffer, buffer, numBytesRead);
                return numBytesRead;
            }
        }


        public void Process()
        {

            if ( input == null )
            {
                return;
            }
        }
    }
}
