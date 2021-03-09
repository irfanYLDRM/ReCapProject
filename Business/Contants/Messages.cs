using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Contants
{
    public class Messages
    {
        public static string Added = "Kayıt başarılı";
        public static string Updated = "Güncelleme yapıldı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string NameInvalid = "İsim geçersiz";
        public static string PriceInvalid = "Günlük ücret sıfırdan büyük olmalıdır";
        public static string MaintanenceTime = "Sistem Bakımda";
        public static string Listed = "Listelendi";
        public static string DescriptionInvalid = "Açıklama yetersiz";
        public static string RentalAddedError = "Araç zaten kirada";
        public static string RentalAdded = "Kiralama kaydı başarılı";
        public static string CarImageLimitExceeded = "Resim sınırına ulaşıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla oluşturuldu";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
