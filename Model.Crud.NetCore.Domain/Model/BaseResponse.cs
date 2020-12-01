using Newtonsoft.Json;

namespace Model.Crud.NetCore.Domain.Model
{
    public class BaseResponse
    {
        [JsonIgnore]
        public int StatusCode { get; set; }  
         
        public string Mensagem { get; set; }

        public dynamic Conteudo { get; set; }
    }
}