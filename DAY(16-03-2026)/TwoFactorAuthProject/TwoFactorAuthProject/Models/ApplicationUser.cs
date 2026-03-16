using Microsoft.AspNetCore.Identity;

namespace TwoFactorAuthProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        //it will automatically includes the 
        //email , passwordhash, twoFactorenabled
        //PhoneNumber,AccessFailedCount,LockoutEnd

    }
}
