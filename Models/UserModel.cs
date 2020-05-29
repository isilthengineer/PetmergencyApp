using Parse;

namespace Petmergency.Models
{
    public class UserModel
    {
        public ParseUser User { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}