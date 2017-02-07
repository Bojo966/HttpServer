using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.Models
{
    public class ResponceBuilder
    {
        public static HttpResponce InternalServerError()
        {
            HttpResponce responce = new HttpResponce();
            string fileContent = File.ReadAllText("./StaticResources/InternalSeverError.html");
            responce.ContentAsUtf8 = fileContent;
            responce.StatusCode = Enums.ResponseStatusCode.Internal_Server_Error;

            return responce;
        }

        public static HttpResponce NotFount()
        {
            HttpResponce responce = new HttpResponce();
            string fileContent = File.ReadAllText("./StaticResources/ResouceNotFound.html");
            responce.ContentAsUtf8 = fileContent;
            responce.StatusCode = Enums.ResponseStatusCode.Not_Found;

            return responce;
        }
    }
}
