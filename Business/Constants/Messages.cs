using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Success Message
        public static string Added = " Sisteme Eklendi";
        public static string Deleted = " Sistemden Silindi";
        public static string Updated = " Sistemde Güncellendi";
        public static string Listed = "  Listelendi";
        public static string GetById = " Id numarsına göre bulunmuştur";
        public static string GetByListId = " Id numarsına göre listenmiştir";
        public static string RentalAdded = " Başarıyla Kiralanmıştır";
        public static string UserAdded = "Kullanıcı Kaydınız Oluşturuldu";


        //Error Message
        public static string NotAdded = "  Eklenemedi";
        public static string NotDeleted = " Silme işlemi başarısız";
        public static string NotUpdated = " Güncellenemedi";
        public static string NotListed = "  Listelenemiyor";
        public static string NotGetById = " Id numarsına göre bulunamamıştır";
        public static string NotGetByListId = " Id numarsına göre listenememiştir";
        public static string NotRentalAdded = " Kiralanamaz";
        public static string NotUserEmail = "Bu E-Mail Sistemde Kayıtlı ";

        //Objects
        public static string Cars = "Aracınız ";
        public static string Color = "Renk ";
        public static string Brand = "Marka ";
        public static string Customer = "Müşteri ";
        public static string User = "Kullanıcı ";
        public static string Rental = "Kiralanan  ";

        public static string ImageUploadSuccessful = "Resim Başarıyla Yüklendi";

        public static string ImageNotUpload = "Resim Yükleme Başarısız";

        public static string FailAddedImageLimit = "Resim Yükleme Limitine Ulaştınız";

        public static string AddedPhoto = "Aracın Fotoğrafı Başarıyla Yüklendi";

        public static string NotPhotoLimit = "Fotoğraf Limitinizi Doldurdunuz";

        public static string GetByIdPhoto = "Resim Id Numarasına Göre Bulundu";

        public static string Successful = "Default Resim";

        public static string PhotoDeleted = "Fotoğraflar Silindi";
    }
}
