namespace proiectDAW.Models.DTO {
    public class ResponseDto<T> {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }

        public ResponseDto(T? data, bool success = true, string message = "Succes", int errorCode = 200) {
            Data = data;
            Success = success;
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
