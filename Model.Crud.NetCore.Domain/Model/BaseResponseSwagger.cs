namespace Model.Crud.NetCore.Domain.Model
{
    public class BaseResponseSwagger<T>: BaseResponse
    {
        public BaseResponseSwagger(T t) => Conteudo = t;

        public T Conteudo { get; set; }
    }
}