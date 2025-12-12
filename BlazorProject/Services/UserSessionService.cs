namespace BlazorProject.Services
{
    public interface IUserSessionService
    {
        string? CurrentUserId { get; set; }
        string? CurrentUserEmail { get; set; }
    }

    public class UserSessionService : IUserSessionService
    {
        public string? CurrentUserId { get; set; }
        public string? CurrentUserEmail { get; set; }
    }
}