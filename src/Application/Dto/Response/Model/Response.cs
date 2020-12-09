using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Response.Model
{
    public class Response<T> : BaseResponse
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
