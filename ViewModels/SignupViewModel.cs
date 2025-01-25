using System;

namespace IdentityProject.Web.ViewModels;

public class SignupViewModel
{
    public SignupViewModel()
    {
    }
    public SignupViewModel( string userName, string email, string password, string confirmPassword , string phoneNumber)
    {
        UserName = userName;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
        PhoneNumber = phoneNumber;
    }
    public string UserName { get; set; } 
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string PhoneNumber { get; set; }
}
