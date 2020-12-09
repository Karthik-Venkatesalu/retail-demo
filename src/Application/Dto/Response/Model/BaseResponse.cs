using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Response.Model
{
    public abstract class BaseResponse
    {
        [JsonProperty("meta")]
        public Dictionary<string, object> Meta { get; set; }

        [JsonProperty("links")]
        public Link Link { get; set; }
    }
}
