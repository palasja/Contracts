using DAL.ModelsDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TestRepository
{
    static class OrganizationRepository
    {
        static public List<Organization> GetOrganizations()
        {
            var organizations = new List<Organization>();

            organizations.Add(new Organization()
            {
                Id = 1,
                FullName = "Областное финансовое упрвление",
                Name = "Обл ФУ",
                Address = "ул Ленина 18",
                Smdo = "Org1235",
                Email = "GomelOblFu@gomel.by",
                AreaId = 1
            });
            organizations.Add(new Organization()
            {
                Id = 2,
                FullName = "Мозырский нефтеперерабатывающий завод",
                Name = "НПЗ",
                Address = "д. Лесовики 3",
                Smdo = "Org48693",
                Email = "NPZ@npz.by",
                AreaId = 2
            });
            organizations.Add(new Organization()
            {
                Id = 3,
                FullName = "ОАО Красный Мозырянин",
                Name = "Красный мозырянин",
                Address = "ул фабричная 1",
                Email = "Korovka@korovka.by",
                AreaId = 3
            });
            organizations.Add(new Organization()
            {
                Id = 4,
                FullName = "Районный отдел образования",
                Name = "Роо",
                Address = "ул Коммунистическая 4",
                Email = "Narovlya@roo.gomel.by",
                AreaId = 3
            });
            organizations.Add(new Organization()
            {
                Id = 5,
                FullName = "ЗАО Керамин",
                Name = "Керамин",
                Address = "ул Заводская 85/4",
                Email = "Keramin@keramin.by",
                AreaId = 4
            });
            return organizations;
        }
    }
}
