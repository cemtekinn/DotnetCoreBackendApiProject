using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductListed = "Ürünler listelendi";
        public static string ProductBroughtByCategory = "Ürünler kategoriye göre getirildi";
        public static string ProductBroughtBySubCategory = "Ürünler alt kategoriye göre getirildi";
        public static string ProductNameExists = "Bu isimde ürün olduğu için ekleme yapamazsınız";
        public static string AuthorizationDenied = "Yetkiniz bulunmamaktadır";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kullanıcı sisteme kaydedildi";
        public static string PasswordError = "Şifre hatalı";
        public static string UserAlreadyExists = "Zaten kullanıcı sisteme daha önceden kayıt edilmiş";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string UsersListed="Kullanıcılar listelendi";
        public static string UserAdded="Kullanıcı eklendi";
        public static string UserGetByEmail="Kullanıcı eposta adresine göre getirildi";
        public static string ProductDeleteSuccessfully="Ürün başarıyla silindi";
        public static string ProductUpdateSuccessfully="Ürün başarıyla güncellendi";



        public static string CategoryAddedSuccessfully="Kategori başarıyla eklendi";
        public static string CategoryListed= "Kategoriler listelendi";
        public static string CategoryRemovedSuccessfully = "Kategori başarıyla silindi";
        public static string CategoryUpdatedSuccessfully="Kategori başarıyla güncellendi";

        public static string CategoryIsNotEmpty = "Bu kategoriye ait ürünler var.Bu kategoriyi silmek için ilk olarak o ürünleri silmelisiniz";
        public static string CategoryNameAlreadyExists="Bu kategoriyi daha önce eklediniz.Aynı isimde bir kategori ekleyebilirsiniz";
        public static string CategoryNameNotFound="Aradığınız kategori bulunamadı";
        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerDeletedSuccessfully="Müşteri başarıyla silindi";
        public static string CustomersListed="Müşteriler listelendi";
        public static string CustomerUpdatedSuccessfully="Müşteri bilgileri başarıyla güncellendi";
    }
}
