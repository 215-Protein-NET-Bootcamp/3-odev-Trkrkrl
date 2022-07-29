using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        public interface IAuthService//Bu servis sayesinde sisteme giriş yapıcam veya  kayıt olucam
        {
            IDataResult<Account> Register(AccountForRegisterDto accountForRegisterDto, string password); //Kayıt operasyonu
            IDataResult<Account> LoginWithEmail(AccountMailLoginDto accountMailLoginDto);//mail ile Giriş operasyonu
            IDataResult<Account> LoginWithUserName(AccountNameLoginDto accountNameLoginDto);//username ile Giriş operasyonu


            IResult UserExists(string email);//Kullanıcı var mı
            IDataResult<AccessToken> CreateAccessToken(Account account);
        }
    }
}
