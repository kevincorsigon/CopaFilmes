using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Models
{
    public class ResponseWrapper<T> where T: class
    {
        public T Result { get; set; }

        public int Status { get; set; }

        public string Error { get; set; }
    }
}

