using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Response.Model
{
    public class Error
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
