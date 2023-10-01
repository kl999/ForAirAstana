using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Infrastructure
{
    public interface IResponse
    {
        ResponseCodes Code { get; set; }
        string Message { get; set; }
    }

    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
    }
}
