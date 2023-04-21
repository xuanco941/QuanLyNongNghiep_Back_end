namespace QuanLyNongNghiepAPI.DataTransferObject
{
    public class APIResponse<T>
    {
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public APIResponse(T? data, string message, bool isOk)
        {
            if(isOk == true)
            {
                Status = "success";
            }
            else
            {
                Status = "error";
            }
            Message = message;
            Data = data;

        }
    }
}
