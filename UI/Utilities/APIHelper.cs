using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UI.Utilities
{
    public class APIHelper
    {
        private readonly IConfiguration _configuration;

        public APIHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public HttpClient Cliente { get; set; }

        public void InicializarCliente()
        {
            Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_configuration["Private:Url"]);
            Cliente.DefaultRequestHeaders.Clear();
            Cliente.DefaultRequestHeaders.Add("accept", "application/json");
        }
    }
}
