namespace BaseApi.Dto.Response
{
    public class GetPostResponseDto
    {
        public string Status {  get; set; }
        public string Message { get; set; }
        public List<PostDto> Data {  get; set; }
    }
}
