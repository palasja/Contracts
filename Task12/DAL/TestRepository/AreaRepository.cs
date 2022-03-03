using DAL.ModelsDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TestRepository
{
    static class AreaRepository
    {
        public static List<Area> getAreas()
        {
            var areas = new List<Area>();

            areas.Add(new Area() { Id = 1, FullName = "Гомельская область", SimpleName = "Гомель обл"});
            areas.Add(new Area() { Id = 2, FullName = "Мозырский район", SimpleName = "Мозырь" });
            areas.Add(new Area() { Id = 3, FullName = "Наровлянский район", SimpleName = "Наровля" });
            areas.Add(new Area() { Id = 4, FullName = "город Минск", SimpleName = "Минск" });

            return areas;
        }
        
    }
}
