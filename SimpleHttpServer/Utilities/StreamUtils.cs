namespace SimpleHttpServer.Utilities
{
    using System.IO;
    using System.Text;
    using System.Threading;
    using SimpleHttpServer.Models;

	public class StreamUtils
    {
		public static string ReadLine(Stream stream)
        {
            StringBuilder builder = new StringBuilder();
            int currentByte;
            while (true)
            {
                currentByte = stream.ReadByte();
                if (currentByte == '\n') break;
                if (currentByte == '\r') continue;
				if (currentByte == -1) { Thread.Sleep(1); continue; }
                builder.Append((char)currentByte);
            }

            return builder.ToString();
        }

		public static void WriteResponce(Stream stream, HttpResponce responce)
        {
            byte[] responceHeader = Encoding.UTF8.GetBytes(responce.Header.ToString());
            stream.Write(responceHeader, 0, responceHeader.Length);
            stream.Write(responce.Content, 0, responce.Content.Length);
        }
    }
}