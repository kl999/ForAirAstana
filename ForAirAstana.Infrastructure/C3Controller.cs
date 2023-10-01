using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Infrastructure
{
    public class C3Controller<T> 
    {
        private readonly ILogger<C3Controller<T>> _logger;
        private readonly T _controller;

        public C3Controller(ILogger<C3Controller<T>> logger, T controller)
        {
            _logger = logger;
            _controller = controller;
        }

        public IResponse Invoke(Action<T> action)
        {
            try
            {
                _logger.LogTrace($"Invoking {nameof(T)}");

                action(_controller);

                return new EmptyResponse() 
                { 
                    Code = ResponseCodes.Success,
                    Message = nameof(ResponseCodes.Success),
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error invoking {nameof(T)}");

                return new EmptyResponse() 
                {
                    Code = ResponseCodes.UnknownError,
                    Message = nameof(ResponseCodes.UnknownError),
                };
            }
        }

        public IResponse Invoke<Result>(Func<T, IResponse<Result>> funcion)
        {
            try
            {
                _logger.LogTrace($"Invoking {nameof(T)}");

                return funcion(_controller);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error invoking {nameof(T)}");

                return new EmptyResponse()
                {
                    Code = ResponseCodes.UnknownError,
                    Message = nameof(ResponseCodes.UnknownError),
                };
            }
        }
    }
}
