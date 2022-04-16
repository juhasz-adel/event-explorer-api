namespace EventExplorer.Api.Controllers.Resources.Responses
{
    public class AttendanceResponseResource
    {
        public EventResponseResource Event { get; set; }
        public UserResponseResource User { get; set; }
    }
}
