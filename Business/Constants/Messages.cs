﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string EmailCouldNotSend = "E-posta gönderilemedi";
        public static string UserExistsWithSameGsm = "Bu telefon numarası ile zaten bir üyelik mevcut.";
        public static string DateOfBirthIsInvalid = "Doğum tarihi geçersiz.";
        public static string PleaseEnterGsmWithDialCode = "Telefon numarasının başında lütfen ülke kodu kullanınız.";
        public static string NameLengthMustBeGreaterThanTwo = "İsim 2 karakterden uzun olmalıdır.";
        public static string SurnameLengthMustBeGreaterThanTwo = "Soyisim 2 karakterden uzun olmalıdır";
        public static string PasswordsDoesNotMatch = "Şifreleriniz uyuşmuyor.";
        public static string PasswordShouldContainOneBigLetter = "Şifreniz en az bir adet büyük harf içermelidir";
        public static string PasswordShouldContainOneNumber = "Şifreniz en az bir adet numerik karakter içermelidir.";
        public static string EnterCorrectMail = "Lütfen düzgün bir e-posta adresi giriniz.";
        public static string RegisterSuccessfullWelcome = "Kayıt başarılı. Hoşgeldiniz {0}.";
        public static string MailLengthInvalid = "E-posta adresi {0} karakterden uzun olmalıdır.";
        public static string PasswordLengthInvalid = "Şifre {0} karakterden uzun olmalıdır.";
        public static string NoUserFoundWithThisMail = "Bu e-posta adresiyle ilişkili bir kullanıcı bulunamadı.";
        public static string PasswordInvalid = "Yanlış şifre.";
        public static string UserExistsWithSameMail = "Bu e-posta adresiyle ilişkili bir kullanıcı zaten var.";
        public static string NoUserFoundWithThisId = "Veritabanımızda böyle bir kullanıcı bulunamadı.";
        public static string ForgotPasswordMailSent = "Şifre sıfırlama maili başarıyla yollandı.";
        public static string ForgotPasswordTokenIsInvalid = "Bu şifre sıfırlama linki geçersiz veya süresi dolmuş.";
        public static string PasswordChangedSuccessfully = "Şifreniz başarıyla değiştirilmiştir.";
        public static string TokenIsRequired = "Token boş olamaz.";
        public static string EmailSent = "E-posta gönderildi.";
        public static string MailConfirmTokenIsInvalid = "E-posta doğrulama kodunun süresi geçmiş veya bu hesap daha önceden doğrulanmıştır.";
        public static string MailConfirmedSuccessfully = "Hesabınızı başarıyla doğruladınız";
        public static string YouCanNotLoginBeforeMailConfirm = "E-posta adresinizi doğrulamadan giriş yapamazsınız.";
        public static string UserAddressNotExists = "Kayıtlı adresiniz yok.";
        public static string UserAddressAdded = "Adresiniz başarıyla kaydedildi.";
        public static string UserAddressUpdated = "Adresiniz başarıyla güncellendi.";
        public static string UserAddressDeleted = "Adresiniz başarıyla silindi.";
        public static string TitleCanNotBeNullOrEmpty = "Başlık boş olamaz";
        public static string CityCanNotBeNullOrEmpty = "Şehir boş olamaz";
        public static string DistrictCanNotBeNullOrEmpty = "İlçe boş olamaz";
        public static string QuarterCanNotBeNullOrEmpty = "Mahalle boş olamaz";
        public static string AddressStringCanNotBeNullOrEmpty = "Adres tanımı boş olamaz";
        public static string NameCanNotBeNullOrEmpty = "Ad boş olamaz";
        public static string GsmCanNotBeNullOrEmpty = "Telefon numarası boş olamaz";
        public static string SurnameCanNotBeNullOrEmpty = "Telefon numarası boş olamaz";
        public static string AddressIdCanNotBeNullOrEmpty = "Adres idsi boş Veya 0 dan küçük olamaz.";
        public static string UserFavoritesNotFound = "Favorilerde ürün bulunamadı.";
        public static string FavoriteProductAdded = "Ürün favorilere eklendi.";
        public static string FavoriteProductNotFound = "Ürün bulunamadı.";
        public static string FavoriteProductDeleted = "Ürün favorilerden kaldırıldı.";
        public static string FavoriteAlreadyExists = "Bu ürün zaten favorilerde mevcut";
        public static string BrandAdded = "Markanız başarıyla eklendi.";
        public static string BrandUpdated = "Markanız başarıyla güncellendi.";
        public static string BrandNotFound = "Marka bulunamadı.";
        public static string BrandDeleted = "Markanız başarıyla silindi.";
        public static string BrandApproveSuccess = "Marka onaylama işleminiz başarılı.";
        public static string BrandNameCanNotBeNull = "Marka isminiz boş geçilemez.";
        public static string CreditCardDoesntExists = "Hesabınıza ait kredi kartı tanımlanmamış.";
        public static string CreditCardAdded = "Kredi kartı başarıyla eklendi.";
        public static string CreditCardAlreadyExists = "Kredi kartı zaten mevcut.";
        public static string CreditCardNotFound = "Kredi kartı bulunamadı.";
        public static string CreditCardDeleted = "Kredi kartı başarıyla silindi.";
        public static string CreditCardUpdated = "Kredi kartı başarıyla güncellendi.";
        public static string TitleCanNotBeNull = "Başlık 1 harften büyük olmalıdır.";
        public static string CreditCardInvalid = "Lütfen geçerli bir kredi kartı numarası giriniz.";
        public static string OwnersNameCanNotBeNull = "Lütfen kredi kartınızın üstündeki isim soyisimi giriniz.";
        public static string ExpireDateInvalid = "Kredi kartınızın son kullanma tarihi geçerli değil.";
        public static string CVVInvalid = "Kredi kartınızın CVV numarası geçerli değil.";
        public static string ProductAlreadyExistsInBasket = "Eklemek istediğiniz ürün zaten mevcut.";
        public static string UserBasketIsEmpty = "Sepetiniz boş.";
        public static string UserBasketCreated = "Kullanıcı sepeti oluşturuldu.";
        public static string UserBasketNotFound = "Kullanıcı sepeti bulunamadı.";
        public static string UserBasketDeleted = "Kullanıcı sepeti silindi.";
        public static string ProductAddedToBasket = "Ürün sepetinize eklendi.";
        public static string ProductNotFound = "Ürün bulunamadı.";
        public static string ProductHasNoStocksLeft = "Stok miktarı aşımı. Maksimum stok sayısı kadar sepete ekleyebilirsiniz.";
        public static string UserBasketProductCanNotDelete = "Sepetteki ürün silinemedi.";
        public static string UserBasketProductDeleted = "Sepetteki ürün başarıyla silindi.";
        public static string UserBasketProductUpdated = "Sepetteki ürün güncellendi.";
        public static string UserBasketProductNotFound = "Sepetteki ürün bulunamadı.";
        public static string ProductIdInvalid = "Ürün idsi geçersiz.";
        public static string QuantityInvalid = "Eklenilen stok miktarı geçersiz.";
        public static string BasketProductIdInvalid = "Ürün idsi geçersiz.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductUpdated = "Ürün güncellendi.";
        public static string ProductAdded = "Ürün eklendi.";
        public static string PasswordVerifyNotMatch = "Şifreleriniz uyuşmuyor.";

        public static string FavoriteProductUpdated { get; internal set; }
    }
}
