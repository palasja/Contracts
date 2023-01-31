using BlazorInputFile;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FileService
    {
        public async Task<MemoryStream> GetMemoryStream(IFileListEntry fileEntry)
        {
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            return ms;
        }

        public DataTable GetTableFromMemoryStream(MemoryStream ms, string type)
        {
            //Установить кодировку таблицы
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            IExcelDataReader excelReader;
            if (type.ToUpper() == "XLS")
            {
                //1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateReader(ms);
            }
            else
            {
                //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(ms);
            }
            //2. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();
            DataTable dt = result.Tables[0];
            return dt;
        }

        const string path = @"D:\Upload";
        public async Task<string> SaveFile(IFileListEntry fileEntry, string fileName)
        {
            string fullPath = Path.Combine(path, fileName);
            if (Directory.Exists(path))
            {
                var ms = new MemoryStream();
                await fileEntry.Data.CopyToAsync(ms);
                using (FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    ms.WriteTo(file);
                }
            }
            return fullPath;
        }

        public async Task<DataTable> GetTableFromFile(string path)
        {
            //Установить кодировку таблицы
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            DataTable dt;
            return await Task.Run<DataTable>(() => {
                using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader excelReader;

                    //1. Reading Excel file
                    if (Path.GetExtension(path).ToUpper() == ".XLS")
                    {
                        //1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
                        excelReader = ExcelReaderFactory.CreateReader(stream);
                    }
                    else
                    {
                        //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    //2. DataSet - The result of each spreadsheet will be created in the result.Tables
                    DataSet result = excelReader.AsDataSet();
                    dt = result.Tables[0];
                }
                return dt;
            });
            
        }

    }
}
