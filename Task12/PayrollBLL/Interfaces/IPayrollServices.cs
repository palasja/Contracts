using BlazorInputFile;
using PayrollBLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PayrollBLL.Interfaces
{
    public interface IPayrollServices
    {
        public Task<List<PayrollDTO>> GetPayrolsAsync();
/*        public Task<List<PaymentTypeDTO>> GetTypesPaymentAsync();*/
        public List<PaymentTypeDTO> GetTypesPayment();
        public Task<List<PayrollDTO>> FiltredonPeriodPayrolsAsync(DateTime start, DateTime end);
        public Task AddPayrolsSaveToFile(IFileListEntry[] fileEntryArr);
        public Task AddPayrolsSaveToDB(IFileListEntry[] fileEntryArr);
    }
}
