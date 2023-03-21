namespace Security.Application.Models.RegisterDtos
{
    public class ErrorRegister
    {
        public Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();


        public void AddError(string Code, string Error)
        {
            Errors.Add(Code, Error);
        }
    }
}