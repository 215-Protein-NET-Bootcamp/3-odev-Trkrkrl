using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //token içeriisne hangi claimleri yetkileri koyalım , bunlarda claim listesinden gelecek

        //api siteminde kullanıcı adı şifresi girildi
        //burada eğer doğruysa ilgili veritabanına gidicek ve bu kullanıcının
        //claimlerini bulucak,jwt üreticek
        AccessToken CreateToken(Account account);//bu account normal entities değil- coredan özel geliyor
    }
}
