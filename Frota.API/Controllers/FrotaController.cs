using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Frota.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrotaController : ControllerBase
    {
        private readonly ILogger<FrotaController> _logger;

        public FrotaController(ILogger<FrotaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            String version = "v1";
            String machineName = Environment.MachineName;
            return String
                .Format("Frota endpoint - versão do aplicativo: {0} - nome da maquina: {1}",
                version,
                machineName);
        }
    }
}
