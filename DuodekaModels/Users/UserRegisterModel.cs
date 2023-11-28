using System.Text.RegularExpressions;

namespace DuodekaModels.Users
{
    public class UserRegisterModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public UserRole Role { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }

        public bool ValidatePassword() 
        {
            if (this.Password == this.ConfirmPassword)
            {
                return true;
            }
            return false;
        }

        public bool ValidateRequiredFields()
        {
            if (string.IsNullOrEmpty(this.FirstName) || string.IsNullOrEmpty(this.LastName) || string.IsNullOrEmpty(this.Email) || string.IsNullOrEmpty(this.Password) || this.Role == null) {
                return false;
            }
            return true;
        }

        public bool validateEmail()
        {
            string theEmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                  + "@"
                                  + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

            if (Regex.IsMatch(this.Password, theEmailPattern)) {
                return true; 
            }
            return false;
        }
    }
}