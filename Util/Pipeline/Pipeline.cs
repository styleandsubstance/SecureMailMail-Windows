using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SecureMedMail.Util.Pipeline
{
    class Pipeline
    {

        private List<Pipe> pipes = new List<Pipe>();
        private List<Thread> threads = new List<Thread>();


        public void AddPipeToPipeline(Pipe pipe)
        {
            this.pipes.Add(pipe);
        }


        public Pipeline(List<Pipe> pipes)
        {
            this.pipes = pipes;
        }

        public void Start()
        {
            //set up the valves on each end of the pipe
            for (int i = 0; i < pipes.Count; i++)
            {
                Pipe input = null;
                Pipe output = null;
                if (i > 0)
                {
                    input = pipes[i - 1];
                }

                if (i != pipes.Count - 1)
                {
                    output = pipes[i + 1];
                }

                pipes[i].SetupPipeline(input, output);
            }

            //Launch a thread for every stage of the pipeline
            foreach (Pipe pipe in pipes)
            {
                Thread thread = new Thread(new ThreadStart(pipe.Process));
                thread.Start();
                threads.Add(thread);
            }


        }

        public void Stop()
        {
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }


        public int GetData(byte[] buffer, int buf_len)
        {
            Pipe endPoint = this.pipes[pipes.Count - 1];
            return endPoint.Read(buffer, buf_len);
        }
    }
}
