using System.ComponentModel.DataAnnotations;

namespace TwoFactorAuthProject.ViewModels
{
    public class VerifyCodeViewModel
    {
        [Required]
        public string  Code { get; set; }
        public string Provider { get; set; }//Email or Authenticator
        public bool RememberMe { get; set; }
        public bool RememberMachine { get; set; }
    }
}
