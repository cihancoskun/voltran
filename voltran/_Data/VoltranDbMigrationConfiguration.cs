using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

using Voltran.Web.Helpers;
using Voltran.Web.Data.Entities;

namespace Voltran.Web.Services.Data
{
    public class VoltranDbMigrationConfiguration : DbMigrationsConfiguration<VoltranDbContext>
    {
        public VoltranDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VoltranDbContext context)
        {
            #region Users

            if (!context.Users.Any())
            {
                AddUser(context, "Administrator", "admin@test.com", ConstHelper.Admin);
            }

            #endregion

            #region ParentCompanies

            if (!context.ParentCompanies.Any())
            {
                AddParentCompany(context, "Burger King");
                AddParentCompany(context, "_Others");
            }

            #endregion

            #region Cities

            if (!context.Cities.Any())
            {
                AddCity(context, "34", "İstanbul", "Kadıköy", "Cinemaximum", "Tepe Nautilus 3.Kat", "Cinemaximum", 1);
                AddCity(context, "35", "İzmir", "Göztepe", "Cinemaximum", "Göztepe'de bir yer", "Cinemaximum", 1);
                AddCity(context, "06", "Ankara", "Kızılay", "Cinemaximum", "Kızılay'da bir yer", "Cinemaximum", 1);
            }

            #endregion

            #region Districts

            if (context.Districts.Count() < 4)
            {
                AddDistrict(context, "34", "Ümraniye");
                AddDistrict(context, "34", "Şişli");
                AddDistrict(context, "34", "Ataşehir");
                AddDistrict(context, "06", "Keçiören");
                AddDistrict(context, "06", "Çankaya");
                AddDistrict(context, "35", "Bornova");
                AddDistrict(context, "35", "Foça");
            }

            #endregion

            #region Companies

            if (context.Companies.Count() < 4)
            {
                AddCompany(context, "34", "Kadıköy", "Burger King", "Burger King", 2);
                AddCompany(context, "34", "Kadıköy", "Burger King", "Burger King", 3);
                AddCompany(context, "34", "Ümraniye", "Burger King", "Burger King", 5);
                AddCompany(context, "35", "Göztepe", "Burger King", "Burger King", 8);
                AddCompany(context, "35", "Foça", "Burger King", "Burger King", 14);
                AddCompany(context, "06", "Kızılay", "Burger King", "Burger King", 24);

                AddCompanyWithoutParent(context, 1, "Lal bar", 33);
            }

            #endregion

            #region Questions

            if (!context.Questions.Any())
            {
                var questionSetId = AddQuestionSet(context, "CinemaximumSoruSet1");

                AddQuestion(context, "Cinemaximum kaç senesinde kurulmuştur ?", "1985", "1990", "1995", "2000", "2000", questionSetId, 1);
                AddQuestion(context, "Cinemaximum kaç tane salona sahiptir ?", "10", "50", "150", "200", "150",questionSetId, 1);
                AddQuestion(context, "Cinemaximum'da şimdiye kadar kaç sinema gösterildi ?", "500", "750", "1000", "2000", "750",questionSetId, 1);  
            }

            #endregion

            #region MetaDatas

            /* 
                        #region Months

                        var monthPublicId = AddMetaDataType(context, "Months");
                        AddMetaData(context, "Months", monthPublicId, "January", "1");
                        AddMetaData(context, "Months", monthPublicId, "February", "2");
                        AddMetaData(context, "Months", monthPublicId, "March", "3");
                        AddMetaData(context, "Months", monthPublicId, "April", "4");
                        AddMetaData(context, "Months", monthPublicId, "May", "5");
                        AddMetaData(context, "Months", monthPublicId, "June", "6");
                        AddMetaData(context, "Months", monthPublicId, "July", "7");
                        AddMetaData(context, "Months", monthPublicId, "August", "8");
                        AddMetaData(context, "Months", monthPublicId, "September", "9");
                        AddMetaData(context, "Months", monthPublicId, "October", "10");
                        AddMetaData(context, "Months", monthPublicId, "November", "11");
                        AddMetaData(context, "Months", monthPublicId, "December", "12");

                        #endregion

                        #region Days

                        var dayPublicId = AddMetaDataType(context, "Days");
                        AddMetaData(context, "Days", dayPublicId, "Monday", "1");
                        AddMetaData(context, "Days", dayPublicId, "Tuesday", "2");
                        AddMetaData(context, "Days", dayPublicId, "Wednesday", "3");
                        AddMetaData(context, "Days", dayPublicId, "Thursday", "4");
                        AddMetaData(context, "Days", dayPublicId, "Friday", "5");
                        AddMetaData(context, "Days", dayPublicId, "Saturday", "6");
                        AddMetaData(context, "Days", dayPublicId, "Sunday", "7");

                        #endregion
  
                        #region JobTitles
                        var jobTitlesPublicId = AddMetaDataType(context, "JobTitles");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "General Manager", "general_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Software Developer", "software_developer");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Logo Support", "logo_support");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Department Chief", "department_chief");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Secretary", "secretary");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Administrative Manager", "administrative_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Service Manager", "service_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "IT Manager", "it_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Technical Service", "technical_service");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "It Specialist", "it_specialist");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Customer Representative", "customer_representative");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Accounting Personnel", "accounting_personnel");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Customer Services", "customer_services");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Project Manager", "project_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Sales Representative", "sales_representative");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Chief Executive Officer", "chief_executive_officer");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Call Center Operator", "call_center_operator");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Business Development Project Manager", "business_development_project_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Vice General Manager", "vice_general_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Purchasing Manager", "purchasing_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Manager", "manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Assistant Manager", "assistant_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Quality Management Specialist", "quality_management_specialist");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "System Manager", "system_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Accounting Manager", "accounting_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Quality Assurance Manager", "quality_assurance_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "IT Personnel", "it_personnel");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Quality System manager", "quality_system_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "General Secretary", "general_secretary");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Vice President Corporate Affairs", "vice_president_corporate_affairs");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "President Corporate Affairs", "president_corporate_affairs");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Rector", "rector");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Coordinator", "coordinator");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Operation Manager", "operation_manager");
                        AddMetaData(context, "JobTitles", jobTitlesPublicId, "Administrator", "administrator");

                        #endregion

                        #region Sectors

                        var sectorPublicId = AddMetaDataType(context, "Sectors");

                        AddMetaData(context, "Sectors", sectorPublicId, "Fuel Oil", "fuel_oil");
                        AddMetaData(context, "Sectors", sectorPublicId, "Packing", "Packing");
                        AddMetaData(context, "Sectors", sectorPublicId, "Banking", "banking");
                        AddMetaData(context, "Sectors", sectorPublicId, "Informatics", "informatics");
                        AddMetaData(context, "Sectors", sectorPublicId, "Cement", "cement");
                        AddMetaData(context, "Sectors", sectorPublicId, "Iron And Steel", "iron_and_steel");
                        AddMetaData(context, "Sectors", sectorPublicId, "Pharmacy", "pharmacy");
                        AddMetaData(context, "Sectors", sectorPublicId, "Electronics", "electronics");
                        AddMetaData(context, "Sectors", sectorPublicId, "Electricity", "electricity");
                        AddMetaData(context, "Sectors", sectorPublicId, "Food", "food");
                        AddMetaData(context, "Sectors", sectorPublicId, "General", "general");
                        AddMetaData(context, "Sectors", sectorPublicId, "Customs", "customs");
                        AddMetaData(context, "Sectors", sectorPublicId, "Service", "service");
                        AddMetaData(context, "Sectors", sectorPublicId, "Medicine", "medicine");
                        AddMetaData(context, "Sectors", sectorPublicId, "Construction", "construction");
                        AddMetaData(context, "Sectors", sectorPublicId, "Importation", "importation");
                        AddMetaData(context, "Sectors", sectorPublicId, "Chemistry", "chemistry");
                        AddMetaData(context, "Sectors", sectorPublicId, "Jeweler", "jeweler");
                        AddMetaData(context, "Sectors", sectorPublicId, "Machine", "machine");
                        AddMetaData(context, "Sectors", sectorPublicId, "Metal", "metal");
                        AddMetaData(context, "Sectors", sectorPublicId, "Transportation", "transportation");
                        AddMetaData(context, "Sectors", sectorPublicId, "Chambers", "chamber");
                        AddMetaData(context, "Sectors", sectorPublicId, "Automotive", "automotive");
                        AddMetaData(context, "Sectors", sectorPublicId, "Plastic", "plastic");
                        AddMetaData(context, "Sectors", sectorPublicId, "Health", "health");
                        AddMetaData(context, "Sectors", sectorPublicId, "Insurance", "insurance");
                        AddMetaData(context, "Sectors", sectorPublicId, "Indepentet Accountent", "indepentet_accountent");
                        AddMetaData(context, "Sectors", sectorPublicId, "Tourism", "tourism");
                        AddMetaData(context, "Sectors", sectorPublicId, "Shipping", "shipping");
                        AddMetaData(context, "Sectors", sectorPublicId, "Structure", "structure");

                        #endregion

                        #region Departments

                        var departmentPublicId = AddMetaDataType(context, "Deparments");

                        AddMetaData(context, "Departments", departmentPublicId, "General", "general");
                        AddMetaData(context, "Departments", departmentPublicId, "Management", "management");
                        AddMetaData(context, "Departments", departmentPublicId, "Technical Service", "technical_service");
                        AddMetaData(context, "Departments", departmentPublicId, "Accounting", "accounting");
                        AddMetaData(context, "Departments", departmentPublicId, "Software", "software");
                        AddMetaData(context, "Departments", departmentPublicId, "Hardware", "hardware");
                        AddMetaData(context, "Departments", departmentPublicId, "Logo Support", "logo_support");
                        AddMetaData(context, "Departments", departmentPublicId, "Consultant", "consultant");
                        AddMetaData(context, "Departments", departmentPublicId, "Sale", "sale");
                        AddMetaData(context, "Departments", departmentPublicId, "Purchase", "purchase");
                        AddMetaData(context, "Departments", departmentPublicId, "Information Technology", "information_technology");
                        AddMetaData(context, "Departments", departmentPublicId, "Personnel Directorate", "personnel_directorate");
                        AddMetaData(context, "Departments", departmentPublicId, "Account Executive", "account_executive");
                        AddMetaData(context, "Departments", departmentPublicId, "Organization Management", "organization_management");
                        AddMetaData(context, "Departments", departmentPublicId, "Shipment", "shipment");
                        AddMetaData(context, "Departments", departmentPublicId, "Customer Services", "customer_services");
                        AddMetaData(context, "Departments", departmentPublicId, "Insurance", "insurance");
                        AddMetaData(context, "Departments", departmentPublicId, "Chancellery", "chancellery");
                        AddMetaData(context, "Departments", departmentPublicId, "Marketing", "marketing");
                        AddMetaData(context, "Departments", departmentPublicId, "Transportation", "transportation");
                        AddMetaData(context, "Departments", departmentPublicId, "Human Resources", "human_resources");

                        #endregion
 
                        #region Universities

                        var universityPublicId = AddMetaDataType(context, "Universities");

                        AddMetaData(context, "Universities", universityPublicId, "Abant İzzet Baysal Üniversitesi", "ibu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Abdullah Gül Üniversitesi", "agu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Adana Bilim ve Teknoloji Üniversitesi", "adanabtu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Adnan Menderes Üniversitesi", "adu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Adıyaman Üniversitesi", "adiyaman.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Afyon Kocatepe Üniversitesi", "aku.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ahi Evran Üniversitesi", "ahievran.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Akdeniz Üniversitesi", "akdeniz.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Aksaray Üniversitesi", "aksaray.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Amasya Üniversitesi", "amasya.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Anadolu Üniversitesi", "anadolu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ankara Sosyal Bilimler Üniversitesi", "asbu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ankara Üniversitesi", "ankara.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ardahan Üniversitesi", "ardahan.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Artvin Çoruh Üniversitesi", "artvin.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Atatürk Üniversitesi", "atauni.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ağrı İbrahim Çeçen Üniversitesi", "agri.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Balıkesir Üniversitesi", "balikesir.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bartın Üniversitesi", "bartin.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Batman Üniversitesi", "batman.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bayburt Üniversitesi", "bayburt.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bilecik Şeyh Edebali Üniversitesi", "bilecik.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bingöl Üniversitesi", "bingol.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bitlis Eren Üniversitesi", "beu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bozok Üniversitesi", "bozok.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Boğaziçi Üniversitesi", "boun.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bursa Teknik Üniversitesi", "btu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bülent Ecevit Üniversitesi", "beun.edu.tr/");
                        AddMetaData(context, "Universities", universityPublicId, "Celal Bayar Üniversitesi", "bayar.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Cumhuriyet Üniversitesi", "cumhuriyet.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Deniz Harp Okulu", "dho.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Dicle Üniversitesi", "dicle.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Dokuz Eylül Üniversitesi", "deu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Dumlupınar Üniversitesi", "dpu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Düzce Üniversitesi", "duzce.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ege Üniversitesi", "ege.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Erciyes Üniversitesi", "erciyes.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Erzincan Üniversitesi", "erzincan.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Erzurum Teknik Üniversitesi", "erzurum.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Eskişehir Osmangazi Üniversitesi", "ogu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Fırat Üniversitesi", "firat.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Galatasaray Üniversitesi", "gsu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Gazi Üniversitesi", "gazi.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Gaziantep Üniversitesi", "gantep.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Gaziosmanpaşa Üniversitesi", "gop.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Gebze Yüksek Teknoloji Enstitüsü", "gyte.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Giresun Üniversitesi", "giresun.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Gülhane Askeri Tıp Akademisi", "gata.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Gümüşhane Üniversitesi", "gumushane.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Hacettepe Üniversitesi", "hacettepe.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Hakkari Üniversitesi", "hakkari.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Harran Üniversitesi", "harran.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Hitit Üniversitesi", "hitit.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İnönü Üniversitesi", "inonu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Medeniyet Üniversitesi", "medeniyet.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Teknik Üniversitesi", "itu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Üniversitesi", "istanbul.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İzmir Kâtip Çelebi Üniversitesi", "ikc.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İzmir Yüksek Teknoloji Enstitüsü", "iyte.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Iğdır Üniversitesi", "igdir.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kafkas Üniversitesi", "kafkas.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kahramanmaraş Sütçü İmam Üniversitesi", "ksu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kara Harp Okulu", "www.kho.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Karabük Üniversitesi", "karabuk.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Karadeniz Teknik Üniversitesi", "ktu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Karamanoğlu Mehmetbey Üniversitesi", "kmu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kastamonu Üniversitesi", "kastamonu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kilis 7 Aralık Üniversitesi", "kilis.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kocaeli Üniversitesi", "kocaeli.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kırklareli Üniversitesi", "kirklareli.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kırıkkale Üniversitesi", "kku.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Mardin Artuklu Üniversitesi", "artuklu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Marmara Üniversitesi", "marmara.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Mehmet Akif Ersoy Üniversitesi", "mehmetakif.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Mersin Üniversitesi", "mersin.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Mimar Sinan Güzel Sanatlar Üniversitesi", "msgsu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Mustafa Kemal Üniversitesi", "mku.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Muğla Üniversitesi", "mugla.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Muş Alparslan Üniversitesi", "alparslan.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Namık Kemal Üniversitesi", "nku.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Necmettin Erbakan Üniversitesi", "konya.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Nevşehir Üniversitesi", "nevsehir.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Niğde Üniversitesi", "nigde.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ondokuz Mayıs Üniversitesi", "omu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ordu Üniversitesi", "odu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Orta Doğu Teknik Üniversitesi", "odtu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Osmaniye Korkut Ata Üniversitesi", "osmaniye.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Pamukkale Üniversitesi", "pamukkale.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Polis Akademisi", "pa.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Recep Tayyip Erdoğan Üniversitesi", "rize.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Sakarya Üniversitesi", "sakarya.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Selçuk Üniversitesi", "selcuk.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Siirt Üniversitesi", "siirt.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Sinop Üniversitesi", "sinop.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Süleyman Demirel Üniversitesi", "sdu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Trakya Üniversitesi", "trakya.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Tunceli Üniversitesi", "tunceli.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Türk Alman Üniversitesi", "tau.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Uludağ Üniversitesi", "uludag.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Uşak Üniversitesi", "usak.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Yalova Üniversitesi", "yalova.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Yüzüncü Yıl Üniversitesi", "yyu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Yıldırım Beyazıt Üniversitesi", "ybu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Yıldız Teknik Üniversitesi", "yildiz.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Çanakkale Onsekiz Mart Üniversitesi", "comu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Çankırı Karatekin Üniversitesi", "karatekin.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Çukurova Üniversitesi", "cu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Şırnak Üniversitesi", "sirnak.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Acıbadem Üniversitesi", "acibadem.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Alanya Hamdullah Emin Paşa Üniversitesi", "");
                        AddMetaData(context, "Universities", universityPublicId, "Ankara Bilge Üniversitesi", "bilge.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Atılım Üniversitesi", "atilim.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Avrasya Üniversitesi", "avrasya.edu.tr/");
                        AddMetaData(context, "Universities", universityPublicId, "Bahçeşehir Üniversitesi", "bahcesehir.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Başkent Üniversitesi", "baskent.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Beykent Üniversitesi", "beykent.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bezmiâlem Vakıf Üniversitesi", "bezmialem.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bilkent Üniversitesi", "bilkent.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Bursa Orhangazi Üniversitesi", "bou.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Canik Başarı Üniversitesi", "basari.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Çankaya Üniversitesi", "cankaya.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Çağ Üniversitesi", "cag.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Doğuş Üniversitesi", "dogus.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Fatih Sultan Mehmet Üniversitesi", "fatihsultan.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Fatih Üniversitesi", "fatihun.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Gedik Üniversitesi", "gedik.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Gediz Üniversitesi", "gediz.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Haliç Üniversitesi", "halic.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Hasan Kalyoncu Üniversitesi", "hku.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Işık Üniversitesi", "isikun.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İpek Üniversitesi**", "altinkoza.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul 29 Mayıs Üniversitesi", "29mayis.edu.tr/");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Arel Üniversitesi", "arel.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Aydın Üniversitesi", "aydin.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Bilgi Üniversitesi", "bilgi.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Bilim Üniversitesi", "istanbulbilim.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Esenyurt Üniversitesi", "www.esenyurt.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Gelişim Üniversitesi", "gelisim.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Kemerburgaz Üniversitesi", "kemerburgaz.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Kültür Üniversitesi", "iku.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Medipol Üniversitesi", "medipol.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Mef Üniversitesi", "mef.k12.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Sabahattin Zaim Üniversitesi", "iszu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Şehir Üniversitesi", "sehir.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İstanbul Ticaret Üniversitesi", "iticu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İzmir Ekonomi Üniversitesi", "ieu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "İzmir Üniversitesi", "izmir.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kadir Has Üniversitesi", "khas.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Karatay Üniversitesi", "karatay.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Koç Üniversitesi", "ku.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Konya Gıda Tarım Üniversitesi", "");
                        AddMetaData(context, "Universities", universityPublicId, "Maltepe Üniversitesi", "maltepe.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Melikşah Üniversitesi", "meliksah.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Mevlana Üniversitesi", "mevlana.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Murat Hüdavendigar Üniversitesi", "");
                        AddMetaData(context, "Universities", universityPublicId, "Nişantaşı Üniversitesi", "nisantasi.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Nuh Naci Yazgan Üniversitesi", "nny.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Okan Üniversitesi", "okan.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Özyeğin Üniversitesi", "ozyegin.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Piri Reis Üniversitesi", "pirireis.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Sabancı Üniversitesi", "sabanciuniv.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Sanko Üniversitesi", "www.facebook.com/sankouni");
                        AddMetaData(context, "Universities", universityPublicId, "Selahattin Eyyubi Üniversitesi", "tr.wikipedia.org/wiki/Selahattin_Eyyubi_%C3%9Cniversitesi");
                        AddMetaData(context, "Universities", universityPublicId, "Süleyman Şah Üniversitesi", "ssu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Şifa Üniversitesi", "sifa.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "TED Üniversitesi", "tedu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "TOBB Ekonomi ve Teknoloji Üniversitesi", "etu.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Toros Üniversitesi", "toros.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Turgut Özal Üniversitesi", "turgutozal.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Türk Hava Kurumu Üniversitesi", "thk.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Ufuk Üniversitesi", "ufuk.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Uluslararası Antalya Üniversitesi", "antalya.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Üsküdar Üniversitesi", "uskudar.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Yaşar Üniversitesi", "yasar.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Yeditepe Üniversitesi", "yeditepe.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Yeni Yüzyıl Üniversitesi", "yeniyuzyil.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Zirve Üniversitesi", "zirve.edu.tr");
                        AddMetaData(context, "Universities", universityPublicId, "Kanuni Üniversitesi", "tr.wikipedia.org/wiki/Kanuni_%C3%9Cniversitesi");
                        AddMetaData(context, "Universities", universityPublicId, "MEF Üniversitesi", "mef.edu.tr");
                        #endregion
 
                        context.SaveChanges();
              */
            #endregion
        }

        #region MetaDataMethods

        //private void AddMetaData(SetMetaDbContext context, string type, string typePublicId, string name, string code, string value, string parentName, string parentPublicId = "")
        //{
        //    var metaData = new MetaData
        //    {
        //        PublicId = Guid.NewGuid().ToNoDashString(),
        //        IsActive = true,
        //        Name = name,
        //        Code = code,
        //        TypeName = type,
        //        TypeCode = type.ToUrlSlug(),
        //        TypePublicId = typePublicId,
        //        Value = value,
        //        ParentName = parentName,
        //        ParentCode = parentName.ToUrlSlug(),
        //        ParentPublicId = parentPublicId
        //    };

        //    context.MetaDatas.Add(metaData);
        //}

        //private string AddMetaData(SetMetaDbContext context, string type, string typePublicId, string name, string value)
        //{
        //    var publicId = Guid.NewGuid().ToNoDashString();
        //    var metaData = new MetaData
        //    {
        //        PublicId = publicId,
        //        IsActive = true,
        //        Name = name,
        //        Code = name.ToUrlSlug(),
        //        TypeName = type,
        //        TypeCode = type.ToUrlSlug(),
        //        TypePublicId = typePublicId,
        //        Value = value
        //    };

        //    context.MetaDatas.Add(metaData);

        //    return publicId;
        //}

        //private string AddMetaDataType(SetMetaDbContext context, string name)
        //{
        //    var publicId = Guid.NewGuid().ToNoDashString();
        //    var metaDataType = new MetaDataType
        //    {
        //        PublicId = publicId,
        //        IsActive = true,
        //        Name = name,
        //        Code = name.ToUrlSlug()
        //    };

        //    context.MetaDataTypes.Add(metaDataType);

        //    return publicId;
        //}

        #endregion

        private static void AddUser(VoltranDbContext context, string name, string email, string role)
        {
            var user = new User
            {
                Email = email,
                Name = name,
                RoleId = ConstHelper.BasicRoles[role],
                RoleName = role,
                ImageUrl = "imgUrl",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                LastLoginAt = DateTime.Now,
                IsActive = true
            };
            context.Users.Add(user);

            context.SaveChanges();
        }

        private long AddParentCompany(VoltranDbContext context, string name, string logoUrl, string address)
        {
            var parentCompany = new ParentCompany
            {
                Name = name,
                LogoUrl = logoUrl,
                Address = address,
                IsActive = true
            };

            context.ParentCompanies.Add(parentCompany);

            context.SaveChanges();

            return parentCompany.Id;
        }

        private void AddCity(VoltranDbContext context, string licensePlate, string name, string districtName, string companyName, string companyAddress, string parentCompanyName, int boxNumber)
        {
            if (parentCompanyName == "")
            {
                parentCompanyName = "_Others";
            }

            var parentCompany = context.ParentCompanies.FirstOrDefault(x => x.Name == parentCompanyName);

            if (parentCompany == null)
            {
                var parentCompanyId = AddParentCompany(context, parentCompanyName, "", "");
                parentCompany = context.ParentCompanies.FirstOrDefault(x => x.Id == parentCompanyId);
            }

            if (parentCompany != null)
            {
                var city = new City
                {
                    LicensePlate = licensePlate,
                    Name = name,
                    IsActive = true,
                    Districts = new List<District>
                    {
                        new District
                        {
                            Name = districtName,
                            CityLicensePlate = licensePlate,
                            IsActive = true,
                            Companies = new List<Company>
                            {
                                new Company
                                {
                                    Name = companyName,
                                    Address = companyAddress,
                                    BoxNumber = boxNumber,
                                    ParentCompanyId = parentCompany.Id,
                                    ParentCompanyName = parentCompany.Name,
                                    CityLicensePlate = licensePlate,
                                    DistrictName = districtName,
                                    IsActive = true
                                }
                            }
                        }
                    }
                };

                context.Cities.Add(city);
            }

            context.SaveChanges();
        }

        private void AddDistrict(VoltranDbContext context, string licensePlate, string name)
        {
            var city = context.Cities.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (city == null) return;

            var distict = new District
            {
                Name = name,
                CityId = city.Id,
                CityLicensePlate = licensePlate,
                IsActive = true
            };

            city.Districts.Add(distict);

            context.SaveChanges();
        }

        private void AddParentCompany(VoltranDbContext context, string name)
        {
            var parentCompany = new ParentCompany
            {
                Name = name,
                IsActive = true
            };

            context.ParentCompanies.Add(parentCompany);

            context.SaveChanges();
        }

        private void AddCompany(VoltranDbContext context, string licensePlate, string districtName, string parentCompanyName, string name, int boxNumber)
        {
            var district = context.Districts.FirstOrDefault(x => x.CityLicensePlate == licensePlate
                                                            && x.Name == districtName);

            if (district == null) return;

            var parentCompany = context.ParentCompanies.FirstOrDefault(x => x.Name == parentCompanyName);

            if (parentCompany == null) return;

            var company = new Company
            {
                Name = name,
                ParentCompanyId = parentCompany.Id,
                ParentCompanyName = parentCompany.Name,
                DistrictId = district.Id,
                DistrictName = district.Name,
                CityLicensePlate = district.CityLicensePlate,
                BoxNumber = boxNumber,
                IsActive = true
            };

            context.Companies.Add(company);

            context.SaveChanges();
        }

        private void AddCompanyWithoutParent(VoltranDbContext context, long districtId, string name, int boxNumber)
        {

            var district = context.Districts.FirstOrDefault(x => x.Id == districtId);

            if (district == null) return;

            var parentCompany = context.ParentCompanies.FirstOrDefault(x => x.Id == 1);

            if (parentCompany == null) return;

            var company = new Company
            {
                Name = name,
                ParentCompanyId = parentCompany.Id,
                ParentCompanyName = parentCompany.Name,
                DistrictId = district.Id,
                DistrictName = district.Name,
                CityLicensePlate = district.CityLicensePlate,
                BoxNumber = boxNumber,
                IsActive = true
            };

            context.Companies.Add(company);
            context.SaveChanges();
        }

        private long AddQuestionSet(VoltranDbContext context, string name)
        {
            var questionSet = new QuestionSet
            {
                Name = name,
                IsActive = true 
            };

            context.QuestionSets.Add(questionSet);

            context.SaveChanges();

            return questionSet.Id;
        }

        private void AddQuestion(VoltranDbContext context, string questionText, string answer1, string answer2, string answer3, string answer4, string rightAnswer,long questionSetId, long companyId)
        {
            var company = context.Companies.FirstOrDefault(x => x.Id == companyId);

            if (company == null) return;
             
            var question = new Question
            {
                QuestionText = questionText,
                Answer1 = answer1,
                Answer2 = answer2,
                Answer3 = answer3,
                Answer4 = answer4,
                RightAnswer = rightAnswer,
                QuestionSetId = questionSetId,
                CompanyId = companyId,
                IsActive = true
            };

            context.Questions.Add(question);

            context.SaveChanges();
        }
    }
}