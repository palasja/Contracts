using AutoMapper;
using PayrollBLL.ModelsDTO;
using PayrollBLL.Reader;
using PayrollDAL;
using PayrollDAL.ModelsDAL;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PayrollBLL.Interfaces;
using System;
using System.Data;
using BlazorInputFile;
using BLL.Services;

namespace PayrollBLL.Services
{
    public class PayrollService : IPayrollServices
    {
        public async Task AddPayrolsSaveToDB(IFileListEntry[] fileEntryArr)
        {
            List<PayrollDTO> payrollsDTO = new List<PayrollDTO>();
            var paymentTypes = await getTypesPayment();
            PayrollReader payrollReader = new PayrollReader(paymentTypes);
            for (int i = 0; i < fileEntryArr.Length; i++)
            {
                FileService fs = new FileService();

                IFileListEntry fileEntry = fileEntryArr[i];
                MemoryStream ms = await fs.GetMemoryStream(fileEntry);

                DataTable dt = fs.GetTableFromMemoryStream(ms, fileEntry.Name.Split('.').Last());
                
                
                PayrollDTO payrollDTO = payrollReader.ReadPayroll(dt);

                LoadedFileDTO loadedFileDTO = new LoadedFileDTO()
                {
                    LoadFile = ms.GetBuffer(),
                    FileName = fileEntry.Name,
                };
                payrollDTO.File = loadedFileDTO;
                payrollsDTO.Add(payrollDTO);
            }

            using (PayrollContext context = new PayrollContext())
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<PayrollDTO, Payroll>();
                    cfg.CreateMap<PaymentDTO, Payment>();
                    cfg.CreateMap<LoadedFileDTO, LoadedFile>();
                });
                var mapper = new Mapper(config);
                var payrols = mapper.Map<List<Payroll>>(payrollsDTO);
                context.Payrolls.AddRange(payrols);
                context.SaveChanges();
            }
        }
        public async Task AddPayrolsSaveToFile(IFileListEntry[] fileEntryArr)
        {
            var paymentTypes = await getTypesPayment();
            PayrollReader payrollReader = new PayrollReader(paymentTypes);

            for (int i = 0; i < fileEntryArr.Length; i++)
            {
                IFileListEntry fileEntry = fileEntryArr[i];
                FileService fs = new FileService();

                var path = await fs.SaveFile(fileEntry, fileEntry.Name);
                DataTable dt = await fs.GetTableFromFile(path);

                List<PayrollDTO> payrollsDTO = new List<PayrollDTO>();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<PayrollDTO, Payroll>();
                    cfg.CreateMap<PaymentDTO, Payment>();
                });
                var mapper = new Mapper(config);
                
                PayrollDTO payrollDTO = payrollReader.ReadPayroll(dt);
                payrollsDTO.Add(payrollDTO);

                using (PayrollContext context = new PayrollContext())
                {
                    var payrols = mapper.Map<List<Payroll>>(payrollsDTO);
                    context.Payrolls.AddRange(payrols);
                    context.SaveChanges();
                }
            }

        }
        public async Task<List<PayrollDTO> > GetPayrolsAsync()
        {
            List<PayrollDTO> payrolsDTO = new List<PayrollDTO>();
            List<Payroll> payrols;

            using (PayrollContext context = new PayrollContext())
            {
                payrols = await context.Payrolls.OrderByDescending(p => p.Period).Include(p => p.Payments).AsNoTracking().ToListAsync();
            }

            if (payrols.Count != 0)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Payroll, PayrollDTO>();
                    cfg.CreateMap<Payment, PaymentDTO>();
                });
                var mapper = new Mapper(config);
                payrolsDTO = mapper.Map<List<PayrollDTO>>(payrols);
            }
            
            return payrolsDTO;
        }

        public async Task<List<PayrollDTO>> FiltredonPeriodPayrolsAsync(DateTime start, DateTime end)
        {
            List<PayrollDTO> payrolsDTO = new List<PayrollDTO>();
            List<Payroll> payrols;

            using (PayrollContext context = new PayrollContext())
            {
                payrols = await context.Payrolls.OrderByDescending(p => p.Period).Include(p => p.Payments).Where(p => p.Period >= start && p.Period <= end).AsNoTracking().ToListAsync();
            }

            if (payrols.Count != 0)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Payroll, PayrollDTO>();
                    cfg.CreateMap<Payment, PaymentDTO>();
                });
                var mapper = new Mapper(config);
                payrolsDTO = mapper.Map<List<PayrollDTO>>(payrols);
            }

            return payrolsDTO;
        }
        /*        public async Task<List<PaymentTypeDTO>> GetTypesPaymentAsync()
                {
                    List<PaymentTypeDTO> typesDTO = new List<PaymentTypeDTO>();
                    List<PaymentType> types = new List<PaymentType> ();
                    using (PayrollContext context = new PayrollContext())
                    {
                        var q = context.PaymentType;
                        var s = await q.ToListAsync().ConfigureAwait(false);
                        Console.WriteLine(s.Count);
                    }

                    if (types.Count != 0)
                    {
                        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentType, PaymentTypeDTO>());
                        var mapper = new Mapper(config);
                        typesDTO = mapper.Map<List<PaymentTypeDTO>>(types);
                    }
                    return typesDTO;
                }*/

        public List<PaymentTypeDTO> GetTypesPayment()
        {
            List<PaymentTypeDTO> typesDTO = new List<PaymentTypeDTO>();
            List<PaymentType> types;
            using (PayrollContext context = new PayrollContext())
            {
                types = context.PaymentType.AsNoTracking().ToList();
            }

            if (types.Count != 0)
            {
                MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentType, PaymentTypeDTO>());
                var mapper = new Mapper(config);
                typesDTO = mapper.Map<List<PaymentTypeDTO>>(types);
            }
            return typesDTO;
        }

        private async Task<Dictionary<int, string>> getTypesPayment()
        {
            Dictionary<int, string> types = new Dictionary<int, string>();
            using (PayrollContext context = new PayrollContext())
            {
                types = await context.PaymentType.AsNoTracking().ToDictionaryAsync(pt => pt.Id, pt => pt.TypeName);
            }
            return types;
        }

        public LoadedFileDTO GetFileById(string payrollId)
        {
            LoadedFile loadedFile;
            using (PayrollContext context = new PayrollContext())
            {
                loadedFile = context.LoadedFile.Where(lf => lf.PayrollId == int.Parse(payrollId)).AsNoTracking().FirstOrDefault();
            }

            var config = new MapperConfiguration(cfg => 
                cfg.CreateMap<LoadedFile, LoadedFileDTO>()
            );
            var mapper = new Mapper(config);
            return mapper.Map<LoadedFileDTO>(loadedFile);
        }
    }
}
