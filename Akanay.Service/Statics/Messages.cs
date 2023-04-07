using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Service.Statics
{
    public static class Messages
    {
        public static string ProductDeleted = "Ürün silindi";
        public static string CategoryDeleted = "Kategori silindi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string UserRegistered = "Kullanıcı kayıt edildi";

        public static string ProductUpdated ="güncellendi";

        public static string AuthorizationDenied = "Yetki Yok";
    }
}
