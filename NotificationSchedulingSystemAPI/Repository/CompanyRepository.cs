using NotificationSchedulingSystemAPI.Data;
using NotificationSchedulingSystemAPI.Models;
using NotificationSchedulingSystemAPI.Repository.IRepository;
using NotificationSchedulingSystemAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSchedulingSystemAPI.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateCompany(Company company)
        {
            
            switch (company.Market)
            {
                case SD.MarketDenmark:

                    var days = new string[SD.NotificationDaysDenmark.Length];

                    for (int i = 0; i < SD.NotificationDaysDenmark.Length; i++)
                    {
                        var _day = DateTime.Now.AddDays(SD.NotificationDaysDenmark[i]).ToString("dd/MM/yyyy");
                        days[i] = _day;
                    }
                    company.Notifications = days;
                    break;

                case SD.MarketNorway:

                    days = new string[SD.NotificationDaysNorway.Length];
                    for (int i = 0; i < SD.NotificationDaysNorway.Length; i++)
                    {
                        var _day = DateTime.Now.AddDays(SD.NotificationDaysNorway[i]).ToString("dd/MM/yyyy");
                        days[i] = _day;
                    }
                    company.Notifications = days;
                    break;

                case SD.MarketSweden:
                    if (company.Type == SD.CompanyTypeSmall || company.Type == SD.CompanyTypeMedium)
                    {
                        days = new string[SD.NotificationDaysSweden.Length];
                        for (int i = 0; i < SD.NotificationDaysSweden.Length; i++)
                        {
                            var _day = DateTime.Now.AddDays(SD.NotificationDaysSweden[i]).ToString("dd/MM/yyyy");
                            days[i] = _day;
                        }
                        company.Notifications = days;
                    }else
                    {
                        company.Notifications = new string[] { "Empty" };
                    }
                    break;
                case SD.MarketFinland:
                    if (company.Type == SD.CompanyTypeLarge)
                    {
                        days = new string[SD.NotificationDaysFinland.Length];
                        for (int i = 0; i < SD.NotificationDaysFinland.Length; i++)
                        {
                            var _day = DateTime.Now.AddDays(SD.NotificationDaysFinland[i]).ToString("dd/MM/yyyy");
                            days[i] = _day;
                        }
                        company.Notifications = days;
                    }
                    else
                    {
                        company.Notifications = new string[] { "Empty" };
                    }
                    break;

                default:
                    company.Notifications = new string[] { "Empty" };
                    break;
            }

            _db.Companies.Add(company);
            return Save();
        }
        public bool DeleteCompany(Company company)
        {
            _db.Companies.Remove(company);
            return Save();
        }

        public Company GetCompany(string companyId)
        {
            return _db.Companies.FirstOrDefault(a => a.Id == companyId);
        }

        public ICollection<Company> GetCompanies()
        {
            return _db.Companies.OrderBy(a => a.Name).ToList();
        }
        public bool CompanyExistsByName(string name)
        {
            bool value = _db.Companies.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }
        public bool CompanyExistsById(string id)
        {
            return _db.Companies.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCompany(Company company)
        {
            _db.Companies.Update(company);
            return Save();
        }

    }
}
