using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Infrastructure
{
    public class EmptyResponse : IResponse
    {
        public ResponseCodes Code { get; set; }
        public string Message { get; set; } = String.Empty;
    }
}
