using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {//aşağıdaki mesaj türleri : 
      

        public static string PersonAdded = "Person eklendi";
        public static string PersonListed = "Person Listelendi";
        public static string PersonDeleted = "Person silindi";

        


        public static string MaintenanceTime = "Şu an bakım aşamasındayız";
        public static string AuthorizationDenied = "Yetkilendirme Reddedildi";

        public static string SuccessfulLogin = "Başarılı Giriş";

        public static string AccountAlreadyExists = "Bu Account Zaten Mevcut";

        public static string AccountNotFound = "Account Bulunamadı";
        public static string AccountRegistered = "Account kaydedildi";
        public static string AccessTokenCreated = "AccessToken Oluşturuldu";

        public static string PasswordError = "Hatalı şifre";
    }
}
