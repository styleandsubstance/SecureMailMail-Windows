using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace SecureMedMail.Util.Pipeline
{
    class EncryptionPipe : BasicPipe, Pipe
    {
        private String filepath;
        private String encryptionPassword;
        byte[] encryptedData = new byte[128 * 1024];
        int currentEncryptedDataPosition = 0;
        int currenEncryptedDataEnd = 0;

        public EncryptionPipe(String encryptionPassword)
        {
            //this.filepath = filepath;
            this.encryptionPassword = encryptionPassword;


            //inputStream = new FileStream(filepath, FileAccess.Read);
        }

        public void SetupPipeline(Pipe input, Pipe output)
        {
            this.input = input;
            this.output = output;
        }


        public int Read(byte[] buffer, int numBytesToRead)
        {
            //if ( this.Done == true )
            //{
            //    return -1;
            //}

            lock(encryptedData)
            {

                if (currenEncryptedDataEnd - currentEncryptedDataPosition == 0)
                {
                    Monitor.Wait(encryptedData);
                }


                int numBytesToCopy = Math.Max(currenEncryptedDataEnd - currentEncryptedDataPosition, numBytesToRead);
                Array.Copy(encryptedData, currentEncryptedDataPosition, buffer, 0, numBytesToCopy);

                currentEncryptedDataPosition += numBytesToCopy;

                Monitor.Pulse(encryptedData);

                return numBytesToCopy;
            }
        }



        public void Process()
        {
            /*
            if ( input == null )
            {
                return;
            }


            byte[] readBuffer = new byte[128 * 1024];
            int numBytesRead = 0;


            UnicodeEncoding ue = new UnicodeEncoding();

            byte[] key = ue.GetBytes(password);
            string cryptFile = outputFile;
            using (FileStream fileCrypt = new FileStream(cryptFile, FileMode.Create))
            {
                using (RijndaelManaged encrypt = new RijndaelManaged())
                {
                    using (CryptoStream cs = new CryptoStream(fileCrypt, encrypt.CreateEncryptor(key, key), CryptoStreamMode.Write))
                    {
                        using (FileStream fileInput = new FileStream(inputFile, FileMode.Open))
                        {
                            encrypt.KeySize = 256;
                            encrypt.BlockSize = 128;
                            int data;
                            while ((data = fileInput.ReadByte()) != -1)
                                cs.WriteByte((byte)data);
                        }
                    }
                }
            }






            while ((numBytesRead = input.Read(readBuffer, readBuffer.Length)) != -1)
            {

                
                lock(encryptedData)
                {
                    //wait till we can fullfil this request
                    while (currenEncryptedDataEnd - currentEncryptedDataPosition < numBytesRead)
                    {
                        Monitor.Wait(encryptedData);
                    }

                    //encrypt the data here










                    //currenEncryptedDataEnd +
                    Monitor.Pulse(encryptedData);

                }
            }

            Done = true;
            */

        }
    }
}
