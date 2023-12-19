using Newtonsoft.Json;

namespace ToDo.CrossCutting.Utils
{
    public class ResultApi<T>
    {
        public ResultApi()
        {
            Success = true;
            Message = string.Empty;
            InternalError = 0;
        }

        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("InternalError")]
        public long InternalError { get; set; }

        [JsonProperty("Result")]
        public T Result { get; set; }
    }
}
