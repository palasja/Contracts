using DAL.ModelsDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TestRepository
{
    static class PersonRepository
    {
        static public List<Person> GetPeople()
        {
            var people = new List<Person>();

            people.Add(new Person() 
            {
                Id =1,
                FirstName = "Алёна",
                MiddleName = "Витальевна",
                LastName = "Ковальчук",
                Position = "Главный экономист",
                Phone = "80232-23-56-84",
                Email = "KovalchukAV@gomel.by",
                OrganizationId = 1
            });
            people.Add(new Person()
            {
                Id = 2,
                FirstName = "Валерий",
                MiddleName = "Игнатьевич",
                LastName = "Песоков",
                Position = "Главный специалист",
                Phone = "80236-34-52-68",
                Email = "PesokovVI@npz.by",
                OrganizationId = 2
            });
            people.Add(new Person()
            {
                Id = 3,
                FirstName = "Василий",
                MiddleName = "Иванович",
                LastName = "Фонрос",
                Phone = "802355-4-58-22",
                OrganizationId = 3
            });
            people.Add(new Person()
            {
                Id = 4,
                FirstName = "Анастасия",
                MiddleName = "Васильвна",
                LastName = "Катонова",
                Position = "Главный бухгалтер",
                Phone = "802355-4-26-84",
                OrganizationId = 4
            });
            people.Add(new Person()
            {
                Id = 5,
                FirstName = "Ирина",
                MiddleName = "Игнатьевна",
                LastName = "Бульба",
                Phone = "8017-45-78-32",
                Email = "BulbaII@keramin.by",
                OrganizationId = 5
            });
            people.Add(new Person()
            {
                Id = 6,
                FirstName = "Наталья",
                MiddleName = "Викторовна",
                LastName = "Фаргое",
                Phone = "8017-23-43-89",
                Email = "Fargoe@keramin.by",
                OrganizationId = 5,
                IsMain = true
            });
            return people;
        }
    }
}
