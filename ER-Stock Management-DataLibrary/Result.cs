using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ER_Stock_Management_DataLibrary
{
    [method: SetsRequiredMembers]
    public class Result(Result.Status statusCode, object? data = null)
    {
        public enum Status
        {
            OK,
            NotFound,
            BadRequest,
            ServerError
        }

        public required Status StatusCode { get; set; } = statusCode;
        public object? Data { get; set; } = data;
    }
}
