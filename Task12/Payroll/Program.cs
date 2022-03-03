using PayrollBLL.Services;
using PayrollBLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayrollBLL.Interfaces;
using System.IO;
using PayrollDAL;
using PayrollDAL.ModelsDAL;
using System.Linq;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            // путь к файлу для загрузки
            string filename = @"D:\Test.xls";
            // заголовок файла
            string title = "Коты";
            // получаем короткое имя файла для сохранения в бд
            string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                                                                                       // массив для хранения бинарных данных файла
            byte[] imageData;
            /*            using (FileStream fs = new FileStream(filename, FileMode.Open))
                        {
                            imageData = new byte[fs.Length];
                            fs.Read(imageData, 0, imageData.Length);
                        }
                        LoadedFile f = new LoadedFile()
                        {
                            LoadFile = imageData,
                            PayrollId = 3
                        };
                        using (PayrollContext context = new PayrollContext())
                        {
                            context.LoadedFile.Add(f);
                            context.SaveChanges();
                        }*/

            using (PayrollContext context = new PayrollContext())
            {
                imageData = context.LoadedFile.FirstOrDefault().LoadFile;
            }

            using (FileStream fs = new FileStream(@"D:\TestDownload.xls", FileMode.Create, FileAccess.Write))
            {
                fs.Write(imageData);
            }

        }
    }

}