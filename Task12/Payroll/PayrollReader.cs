using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    class PayrollReader
    {
        public Payroll ReadPayroll(DataTable dt)
        {
            PayrollReader payrollReader = new PayrollReader();
            Payroll payroll = payrollReader.ReadPayrollPayment(dt);
            payroll.Period = payrollReader.ReadPeriod(dt.Rows[0][0]);
            payroll.Worker = payrollReader.ReadFullName(dt.Rows[2][0]);

            return payroll;
        }
        public async Task<Payroll> ReadPayrollAsync(DataTable dt)
        {
            PayrollReader payrollReader = new PayrollReader();
            Payroll payroll = await Task.Run(() => payrollReader.ReadPayrollPayment(dt));
            payroll.Period = payrollReader.ReadPeriod(dt.Rows[0][0]);
            payroll.Worker = payrollReader.ReadFullName(dt.Rows[2][0]);

            return payroll;
        }

        public DataTable ReadFile(String path)
        {
            //Установить кодировку таблицы
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
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

            DataTable dt = result.Tables[0];
            return dt;
        }
        /// <summary>
        /// Получить дату за которую расчётный лист из строки таблицы
        /// </summary>
        /// <param name="period"></param>
        /// <returns>DateTime из таблице</returns>
        private DateTime ReadPeriod(object period)
        {
            const int NUM_MONTH = 3;
            const int NUM_YEAR = 4;
            var periodArr = period.ToString().Split(" ");
            int month = DateTime.ParseExact(periodArr[NUM_MONTH], "MMMM", new CultureInfo("ru-RU", false)).Month;
            DateTime date = DateTime.Parse($"{month}.{periodArr[NUM_YEAR]}");
            return date;
        }
        /// <summary>
        /// Получить ФИО работника из таблицы
        /// </summary>
        /// <param name="celVal"></param>
        /// <returns></returns>
        private string ReadFullName(object celVal)
        {
            const int NUM_FULLNAME = 1;
            return celVal.ToString().Split(":")[NUM_FULLNAME];
        }
        /// <summary>
        /// Получить данные о платежах в расчётнике
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Расчётный лист со всеми платежами из xls</returns>
        private Payroll ReadPayrollPayment(DataTable dt)
        {
            PayrollReader payrollReader = new PayrollReader();
            Payroll payroll = new Payroll();
            PaymentInfo paymentInfo1 = new PaymentInfo();
            PaymentInfo paymentInfo2 = new PaymentInfo();
            /// <value>Маркер конца платежей:
            /// После платежей есть поля "Долг за организацией на начало месяца:" в платежах они не нужны.
            ///  Для определения что дошли до конца платежей используется маркер</value>
            bool hasNextPayment = false;
            int startPaymentInfo = GetStartPaymentInfo(dt);

            for (int i = startPaymentInfo; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                //В начале платежа 1 строка не пустая, а сумма отсутствует. В итоговых полях с "Всего" сумма тоже может отсутствовать
                if (!String.IsNullOrEmpty(row[0].ToString()) && String.IsNullOrEmpty(row[6].ToString()) && !row[0].ToString().Contains("Всего"))
                {
                    hasNextPayment = false;
                    paymentInfo1 = new PaymentInfo();
                    paymentInfo2 = new PaymentInfo();

                    paymentInfo1.Type = row[0].ToString();
                    paymentInfo2.Type = row[8].ToString();

                    continue;
                }
                //Если в 1 ячейке есть всего то это итоговая строка платежа
                if (row[0].ToString().Contains("Всего"))
                {
                    paymentInfo1.ResultName = row[0].ToString();
                    paymentInfo2.ResultName = row[8].ToString();

                    if (!String.IsNullOrEmpty(row[6].ToString()))
                    {
                        paymentInfo1.ResultSumm = Convert.ToDouble(row[6].ToString());
                    }

                    if (!String.IsNullOrEmpty(row[14].ToString()))
                    {
                        paymentInfo2.ResultSumm = Convert.ToDouble(row[14].ToString());
                    }

                    payroll.PaymentsType.Add(paymentInfo1);
                    payroll.PaymentsType.Add(paymentInfo2);
                    hasNextPayment = true;
                }
                else
                {
                    if (hasNextPayment) break;
                    if (!String.IsNullOrEmpty(row[0].ToString()))
                    {
                        Payment payment1 = payrollReader.ReadPayment(row.ItemArray);
                        paymentInfo1.Payments.Add(payment1);
                    }
                    if (!String.IsNullOrEmpty(row[8].ToString()))
                    {
                        Payment payment2 = payrollReader.ReadPayment1(row.ItemArray);
                        paymentInfo2.Payments.Add(payment2);
                    }
                }
            }
            return payroll;
        }

        /// <summary>
        /// Получить ячейки из первых платежей строки
        /// </summary>
        /// <param name="cels"></param>
        /// <returns></returns>
        private Payment ReadPayment(object[] cels)
        {
            Payment payment1 = new Payment();
            const int COL_NUM_TYPE = 0;
            const int COL_NUM_PERIOD = 1;
            const int COL_NUM_Percent = 3;
            const int COL_NUM_DAYS = 4;
            const int COL_NUM_HOURS = 5;
            const int COL_NUM_SUMM = 6;

            if (!String.IsNullOrEmpty(cels[0].ToString()))
            {
                payment1.Type = cels[COL_NUM_TYPE].ToString();
                payment1.Period = cels[COL_NUM_PERIOD].ToString();
                payment1.SP = cels[COL_NUM_Percent].ToString();
                if (!String.IsNullOrEmpty(cels[COL_NUM_DAYS].ToString())) payment1.Days = Convert.ToInt32(cels[COL_NUM_DAYS].ToString());
                if (!String.IsNullOrEmpty(cels[COL_NUM_HOURS].ToString())) payment1.Hours = Convert.ToInt32(cels[COL_NUM_HOURS].ToString());

                if (!String.IsNullOrEmpty(cels[6].ToString()))
                {
                    payment1.Summ = Convert.ToDouble(cels[COL_NUM_SUMM].ToString());
                }
            }
            return payment1;
        }
        /// <summary>
        /// Получить ячейки из вторых платежей строки
        /// </summary>
        /// <param name="cels"></param>
        /// <returns></returns>
        private Payment ReadPayment1(object[] cels)
        {
            Payment payment1 = new Payment();
            const int COL_NUM_TYPE = 8;
            const int COL_NUM_PERIOD = 11;
            const int COL_NUM_Percent = 13;
            const int COL_NUM_SUMM = 14;

            if (!String.IsNullOrEmpty(cels[8].ToString()))
            {
                payment1.Type = cels[COL_NUM_TYPE].ToString();
                payment1.Period = cels[COL_NUM_PERIOD].ToString();
                if (!String.IsNullOrEmpty(cels[COL_NUM_Percent].ToString())) payment1.SP = cels[COL_NUM_Percent].ToString();

                if (!String.IsNullOrEmpty(cels[COL_NUM_SUMM].ToString()))
                {
                    payment1.Summ = Convert.ToDouble(cels[COL_NUM_SUMM].ToString());
                }
            }
            return payment1;
        }
        /// <summary>
        /// Найти шапку таблицы с данными расчётного
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Номер строки с началом данных</returns>
        private int GetStartPaymentInfo(DataTable dt)
        {
            int NumStringColemnName = 0;
            DataRowCollection rows = dt.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i][0].ToString().Contains("Вид"))
                {
                    NumStringColemnName = i + 1;
                    break;
                }
            }
            return NumStringColemnName;
        }
    }
}
