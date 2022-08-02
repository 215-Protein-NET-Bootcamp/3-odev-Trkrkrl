using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    
    
        public interface IAuthService//Bu servis sayesinde sisteme giriş yapıcam veya  kayıt olucam
        {
            DataResult<Account> Register(AccountForRegisterDto accountForRegisterDto); //Kayıt operasyonu
            DataResult<Account> LoginWithEmail(AccountMailLoginDto accountMailLoginDto);//mail ile Giriş operasyonu
            DataResult<Account> LoginWithUserName(AccountNameLoginDto accountNameLoginDto);//username ile Giriş operasyonu


            Result UserExists(string email);//Kullanıcı var mı
            DataResult<AccessToken> CreateAccessToken(Account account);
        }
    
}
