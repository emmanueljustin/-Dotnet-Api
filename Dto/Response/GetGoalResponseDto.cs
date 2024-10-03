namespace BaseApi.Dto.Response
{
    public class GetGoalResponseDto<T>
    {
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
