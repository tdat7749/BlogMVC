using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModel.Custom
{
    public class CustomIdentityErrrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError()
            {
                Description = "Mật khẩu cũ không đúng",
                Code = nameof(PasswordMismatch),
            };
        }
    }
}
