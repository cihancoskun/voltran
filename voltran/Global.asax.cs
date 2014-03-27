using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Castle.Windsor;
using Castle.Windsor.Installer;

using Voltran.Web.Configurations;
using Voltran.Web.Helpers;
using Voltran.Web.Services.Data;

namespace Voltran
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            MvcHandler.DisableMvcResponseHeader = true;

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            PrepareIocContainer();
            PrepareLocalizationStrings();
        }

        private void PrepareLocalizationStrings()
        {
            var enTexts = new Dictionary<string, string>();
            var trTexts = new Dictionary<string, string>();

            #region EN

            #region Menu

            enTexts.Add("site_name", "Voltran");

            enTexts.Add("menu_administration", "Admin");
            enTexts.Add("menu_signup", "Sign Up");
            enTexts.Add("menu_login", "Login");
            enTexts.Add("menu_words_new_word", "New Word");
            enTexts.Add("menu_words_not_translated", "Not Translated");

            enTexts.Add("menu_apps", "Applications");
            enTexts.Add("menu_apps_apps", "My Applications");
            enTexts.Add("menu_apps_new_app", "New App");

            enTexts.Add("menu_settings", "Administrator");
            enTexts.Add("menu_settings_apps", "All Applications");
            enTexts.Add("menu_settings_users", "All Users");
            enTexts.Add("menu_settings_feed_backs", "Feed Backs");
            enTexts.Add("menu_settings_import", "Data Import");

            enTexts.Add("menu_user_login", "Login");
            enTexts.Add("menu_user_logout", "Logout");
            enTexts.Add("menu_user_sign_up", "Sign Up");
            enTexts.Add("menu_user_reset", "Reset Password");

            enTexts.Add("menu_search", "Search");

            #endregion

            #region Titles

            enTexts.Add("home_title", "Localization as a service");
            enTexts.Add("words_key_listing_title", "Name Listing");
            enTexts.Add("login_view_title", "Login to System");
            enTexts.Add("new_user_title", "New User");
            enTexts.Add("password_reset_title", "Reset Password");
            enTexts.Add("user_apps_title", "My Applications");
            enTexts.Add("all_apps_title", "All Applications");
            enTexts.Add("all_users_title", "All Users");
            enTexts.Add("word_new_key_title", "New Name");
            enTexts.Add("words_my_key_listing_title", "My Keys Listing");
            enTexts.Add("words_not_translated_key_listing_title", "Not Translated Keys Listing");
            enTexts.Add("new_app_title", "New Application");
            enTexts.Add("new_translator_title", "New Translator");
            enTexts.Add("tag_keys_title", "Keys Listing Tagged With ");
            enTexts.Add("import_excel_title", "Import Excel File");
            enTexts.Add("district_view_title", "Districts");
            enTexts.Add("modal_title_apps", "App Status");
            enTexts.Add("modal_title_delete_token", "Token Delete");
            enTexts.Add("home_screen_title", "Home Screen");
            

            #endregion

            enTexts.Add("name", "Name");
            enTexts.Add("email", "E-mail");
            enTexts.Add("app_owner_email", "Owner E-mail");
            enTexts.Add("password", "Password");
            enTexts.Add("app_name", "Application Name");
            enTexts.Add("description", "Description");
            enTexts.Add("usage_count", "Usage Count");
            enTexts.Add("url", "Url");
            enTexts.Add("token", "Token");
            enTexts.Add("creation_date", "Creation Date");
            enTexts.Add("user_role", "User Role");
            enTexts.Add("word_key", "Name");
            enTexts.Add("tag", "Tag");
            enTexts.Add("translated_language", "Translated Language");
            enTexts.Add("translation", "Translation");
            enTexts.Add("language", "Language");
            enTexts.Add("forgot_your_password", "Forgot your password?");
            enTexts.Add("total_page_count", "Total Page Count");
            enTexts.Add("translator_name", "Translator Name");
            enTexts.Add("excel_file", "Excel File");
            enTexts.Add("explanation_excel_file", "can be downloaded");
            enTexts.Add("sample_excel", "Sample excel");
            enTexts.Add("overwrite_existing_data", "Overwrite existing data");
            enTexts.Add("btn_upload", "Upload");
            enTexts.Add("please_select_file", "Please Select File");
            enTexts.Add("please_select_excel_file", "Please Select Excel File");
            enTexts.Add("import_successful", "Excel Import Successful");

            enTexts.Add("btn_login", "Login");
            enTexts.Add("btn_sign_up", "Sign Up");
            enTexts.Add("btn_password_reset", "Send Reset Password Link");
            enTexts.Add("btn_create_new_token", "Create New Token");
            enTexts.Add("btn_new_word", "Add New Translation");
            enTexts.Add("btn_deactivate", "Deactivate");
            enTexts.Add("btn_activate", "Activate");
            enTexts.Add("btn_delete", "Delete");
            enTexts.Add("btn_save", "Save");
            enTexts.Add("btn_edit", "Edit");
            enTexts.Add("btn_cancel", "Cancel");
            enTexts.Add("btn_ok", "Ok");
            enTexts.Add("btn_export_to_excel", "Export to Excel");
            enTexts.Add("column_header_translation_en", "English");
            enTexts.Add("column_header_translation_az", "Azerbaijan");
            enTexts.Add("column_header_translation_cn", "Chinese");
            enTexts.Add("column_header_translation_fr", "Français");
            enTexts.Add("column_header_translation_gr", "Greek");
            enTexts.Add("column_header_translation_it", "İtaliano");
            enTexts.Add("column_header_translation_kz", "Kazakh");
            enTexts.Add("column_header_translation_ru", "Russian");
            enTexts.Add("column_header_translation_sp", "Espanol");
            enTexts.Add("column_header_translation_tk", "Turkic");
             
            enTexts.Add("modal_body_apps", "Are you sure want to change the application's status?");
            enTexts.Add("modal_body_delete_token", "Are you sure want to delete the token?");
            enTexts.Add("modal_title_users", "User Status");
            enTexts.Add("modal_body_users", "Are you sure want to change the user's status?");

            #endregion

            #region TR

            #region Menu

            trTexts.Add("site_name", "Voltran");

            trTexts.Add("menu_administration", "Admin");
            trTexts.Add("menu_signup", "Üye Ol");
            trTexts.Add("menu_login", "Giriş");
            trTexts.Add("menu_words_new_word", "Yeni Kelime");
            trTexts.Add("menu_words_not_translated", "Çevrilmeyen Kelimeler");

            trTexts.Add("menu_apps", "Uygulamalar");
            trTexts.Add("menu_apps_apps", "Uygulamalarım");
            trTexts.Add("menu_apps_new_app", "Yeni Uygulama");

            trTexts.Add("menu_settings", "Yönetim");
            trTexts.Add("menu_settings_apps", "Tüm Uygulamalar");
            trTexts.Add("menu_settings_users", "Tüm Kullanıcılar");
            trTexts.Add("menu_settings_feed_backs", "Bildirimler");

            trTexts.Add("menu_user_login", "Giriş");
            trTexts.Add("menu_user_logout", "Çıkış");
            trTexts.Add("menu_user_sign_up", "Kayıt Ol");
            trTexts.Add("menu_user_reset", "Şifre Sıfırla");

            trTexts.Add("menu_search", "Ara");

            #endregion

            #region Başlıklar

            trTexts.Add("home_title", "Set-locale Servisine Hoş Geldiniz");
            trTexts.Add("words_key_listing_title", "Anahtar Listesi");
            trTexts.Add("login_view_title", "Sisteme Giriş");
            trTexts.Add("new_user_title", "Yeni Kullanıcı");
            trTexts.Add("password_reset_title", "Şifre Sıfırla");
            trTexts.Add("user_apps_title", "Uygulamalarım");
            trTexts.Add("all_apps_title", "Tüm Uygulamalar");
            trTexts.Add("all_users_title", "Tüm Kullanıcılar");
            trTexts.Add("word_new_key_title", "Yeni Anahtar");
            trTexts.Add("words_my_key_listing_title", "Anahtar Listesi");
            trTexts.Add("words_not_translated_key_listing_title", "Anahtar Listesi");
            trTexts.Add("new_app_title", "Yeni Uygulama");
            trTexts.Add("new_translator_title", "Yeni Çevirmen");
            trTexts.Add("tag_keys_title", "Tag Anahtar Listesi ");
            trTexts.Add("import_excel_title", "Excel'den Veri Yükle");
            trTexts.Add("district_view_title", "Districts");
            trTexts.Add("modal_title_users", "Kullanıcı Durumu");
            trTexts.Add("modal_title_delete_token", "Token Sil");
            trTexts.Add("modal_title_apps", "Uygulama Durumu");
            trTexts.Add("home_screen_title", "Ana Sayfa");

            #endregion

            trTexts.Add("name", "İsim");
            trTexts.Add("email", "E-posta");
            trTexts.Add("app_owner_email", "Uygulama Sahibinin E-postası");
            trTexts.Add("password", "Şifre");
            trTexts.Add("app_name", "Uygulama İsmi");
            trTexts.Add("description", "Açıklama");
            trTexts.Add("usage_count", "Kullanım Sayısı");
            trTexts.Add("url", "Url");
            trTexts.Add("token", "Token");
            trTexts.Add("creation_date", "Oluşturma Tarihi");
            trTexts.Add("user_role", "Yetki Grubu");
            trTexts.Add("word_key", "Anahtar");
            trTexts.Add("tag", "Etiket");
            trTexts.Add("translated_language", "Çevrilmiş Dil");
            trTexts.Add("translation", "Çeviri");
            trTexts.Add("language", "Dil");
            trTexts.Add("forgot_your_password", "Şifremi Unuttum");
            trTexts.Add("total_page_count", "Toplam Sayfa Sayısı");
            trTexts.Add("translator_name", "İsmi");
            trTexts.Add("excel_file", "Excel Dosyası");
            trTexts.Add("explanation_excel_file", "dosyasını indirebilirsiniz");
            trTexts.Add("sample_excel", "Örnek excel");
            trTexts.Add("overwrite_existing_data", "Var olan verinin üzerine yaz");
            trTexts.Add("btn_upload", "Yükle");
            trTexts.Add("please_select_file", "Lütfen Dosya Seçiniz...");
            trTexts.Add("please_select_excel_file", "Seçtiğiniz Dosya Excel Dosyası Değildir.");
            trTexts.Add("import_successful_operation", "Excel'den Veri Ekleme Başarılı.");
             
            trTexts.Add("btn_login", "Giriş");
            trTexts.Add("btn_sign_up", "Kayıt Ol");
            trTexts.Add("btn_password_reset", "Şifre Sıfırlama Linki Gönder");
            trTexts.Add("btn_create_new_token", "Yeni Token Oluştur");
            trTexts.Add("btn_new_word", "Yeni Çeviri Ekle");
            trTexts.Add("btn_deactivate", "Pasif");
            trTexts.Add("btn_activate", "Aktif");
            trTexts.Add("btn_delete", "Sil");
            trTexts.Add("btn_save", "Kaydet");
            trTexts.Add("btn_edit", "Düzenle");
            trTexts.Add("btn_cancel", "İptal");
            trTexts.Add("btn_ok", "Tamam");
            trTexts.Add("btn_export_to_excel", "Excel'e Çıkar");
            trTexts.Add("column_header_translation_tr", "Türkçe");
            trTexts.Add("column_header_translation_az", "Azerbaycan");
            trTexts.Add("column_header_translation_cn", "Çince");
            trTexts.Add("column_header_translation_fr", "Fransızca");
            trTexts.Add("column_header_translation_gr", "Yunanca");
            trTexts.Add("column_header_translation_it", "İtalyanca");
            trTexts.Add("column_header_translation_kz", "Kazakça");
            trTexts.Add("column_header_translation_ru", "Rusça");
            trTexts.Add("column_header_translation_sp", "İspanyolca");
            trTexts.Add("column_header_translation_tk", "Türkmençe");
             
            trTexts.Add("modal_body_apps", "Değiştirmek İstediğinize Emin misiniz?");
            trTexts.Add("modal_body_delete_token", "Bu Anahtarı Silmek İstediğinize Emin misiniz?");
            trTexts.Add("modal_body_users", "Durumu Değiştirmek İstediğinize Emin misiniz?");

            #endregion

            Application.Add(ConstHelper.CultureNameEN, enTexts);
            Application.Add(ConstHelper.CultureNameTR, trTexts);
        }
         
        private static void PrepareIocContainer()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
        }

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");

            HttpContext.Current.Response.Headers.Set("Server", string.Format("Web Server ({0}) ", Environment.MachineName));
        } 
    }
}