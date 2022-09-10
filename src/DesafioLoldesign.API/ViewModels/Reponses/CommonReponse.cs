using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioLoldesign.API.ViewModels.Reponses
{
    public class CommonReponse
    {
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public int StatusCode { get; set; }

    }
}