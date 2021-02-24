using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {   

        public Result(bool success, string message) : this(success)  // Bu blok çalışsın ama aynı zamanda bu class success parametresi ile tekrar çalışsın.
        {              
            Message = message;  // hani getter'lar set edilemezdi. Bu yanlıştır.
                                // getter'lar readonly'dir. ve readonly'ler constructor içinde set edilebilir.
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
