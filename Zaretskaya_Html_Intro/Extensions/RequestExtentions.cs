using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zaretskaya_Html_Intro.Extensions
{
    public static class RequestExtentions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request
                .Headers["x-requested-with"]
                .Equals("XMLHttpRequest");
        }
    }
}