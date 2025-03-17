using API.Model.DB;
using API.Model.Request;
using API.Model.Response;
using API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Service
{
    public class EmployeeService(DataContext dataContext) : IEmployeeService
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<DefaultResponse<List<EmployeeGetResponseModel>>> GetEmployee()
        {
            var result = from c in _dataContext.Employee select new EmployeeGetResponseModel 
            {
                EmpNum = c.EmpNum,
                EmpName = c.EmpName,
                HireDate = c.HireDate,
                Salary = c.Salary,
                PositionNo = c.PositionNo,
                DepNo = c.DepNo,
                HeadNo = c.HeadNo
            };

            var obj = await result.AsNoTracking().ToListAsync();

            return new DefaultResponse<List<EmployeeGetResponseModel>> { Result = true, Message = "", Data = obj };
        }

        public async Task<DefaultResponse<object>> AddEmployee(EmployeeAddRequestModel payload)
        {
            await EmployeeValadateData(payload);
            await _dataContext.Employee.AddAsync(new Employee { 
                EmpNum = payload.EmpNum,
                EmpName = payload.EmpName,
                HireDate = payload.HireDate,
                Salary = payload.Salary,
                PositionNo = payload.PositionNo,
                DepNo = payload.DepNo,
                HeadNo = payload.HeadNo
            });

            _dataContext.SaveChanges();
            return new DefaultResponse<object> { Result = true, Message = "บันทึกข้อมูลสำเร็จ", Data = null };
        }

        public async Task<DefaultResponse<object>> UpdateEmployee(EmployeeUpdateRequestModel payload)
        {
            await EmployeeUpdateValadateData(payload);
            var employee = await _dataContext.Employee.FirstOrDefaultAsync(o => o.EmpNum == payload.EmpNum);
            employee!.EmpNum = payload.EmpNum;
            employee!.EmpName = payload.EmpName;
            employee!.HireDate = payload.HireDate;
            employee!.Salary = payload.Salary;
            employee!.PositionNo = payload.PositionNo;
            employee!.DepNo = payload.DepNo;
            employee!.HeadNo = payload.HeadNo;

            _dataContext.Employee.Update(employee);
            _dataContext.SaveChanges();
            return new DefaultResponse<object> { Result = true, Message = "แก้ไขข้อมูลสำเร็จ", Data = null };
        }

        public async Task<DefaultResponse<object>> DeleteEmployee(EmployeeDeleteRequestModel payload)
        {
            var data = await _dataContext.Employee.FirstOrDefaultAsync(o => o.EmpNum == payload.EmpNum) ?? throw new Exception("ไม่พบรหัสพนักงานที่ต้องการลบข้อมูลกรุณาตรวจสอบ");
            _dataContext.Employee.Remove(data);
            _dataContext.SaveChanges();
            return new DefaultResponse<object> { Result = true, Message = "บันทึกข้อมูลสำเร็จ", Data = null };
        }

        private async Task EmployeeValadateData(EmployeeAddRequestModel payload)
        {
            if (string.IsNullOrWhiteSpace(payload.EmpNum) || string.IsNullOrEmpty(payload.EmpNum))
                throw new Exception("คุณยังไม่ได้กรอกรหัสพนักงาน");

            if (string.IsNullOrWhiteSpace(payload.EmpName) || string.IsNullOrEmpty(payload.EmpName))
                throw new Exception("คุณยังไม่ได้กรอกชื่อพนักงาน");

            if (string.IsNullOrWhiteSpace(payload.PositionNo) || string.IsNullOrEmpty(payload.PositionNo))
                throw new Exception("คุณยังไม่ได้เลือกตำแหน่ง");

            if (string.IsNullOrWhiteSpace(payload.DepNo) || string.IsNullOrEmpty(payload.DepNo))
                throw new Exception("คุณยังไม่ได้เลือกแผนก");

            var employee = await _dataContext.Employee.AsNoTracking().FirstOrDefaultAsync(o => o.EmpNum == payload.EmpNum);
            if (employee != null)
                throw new Exception("รหัสพนักงานนี้ถูกใช้แล้วกรุณาระบุรหัสใหม่");

            _ = await _dataContext.Position.AsNoTracking().FirstOrDefaultAsync(o=>o.PositionNo == payload.PositionNo) ??
                throw new Exception("ไม่พบรหัสตำแหน่งที่เลือกกรุณาตรวจสอบอีกครั้ง");

            _ = await _dataContext.Department.AsNoTracking().FirstOrDefaultAsync(o => o.DepNo == payload.DepNo) ??
                throw new Exception("ไม่พบรหัสแผนกที่เลือกกรุณาตรวจสอบอีกครั้ง");

            if (payload.EmpNum.Length > 20)
                throw new Exception("รหัสพนักงานต้องมีความยาวไม่เกิน 20 ตัวอักษร");

            if (payload.EmpName.Length > 255)
                throw new Exception("ชื่อพนักงานต้องมีความยาวไม่เกิน 255 ตัวอักษร");

            if(!string.IsNullOrWhiteSpace(payload.HeadNo) && !string.IsNullOrEmpty(payload.HeadNo))
            {
                if (payload.HeadNo.Length > 20)
                    throw new Exception("รหัสหัวหน้างานต้องมีความยาวไม่เกิน 20 ตัวอักษร");

                _ = await _dataContext.Employee.AsNoTracking().FirstOrDefaultAsync(o => o.EmpNum == payload.HeadNo) ??
                    throw new Exception("ไม่พบรหัสหัวหน้างานกรุณาตรวจสอบอีกครั้ง");
            }
        }

        private async Task EmployeeUpdateValadateData(EmployeeUpdateRequestModel payload)
        {
            if (string.IsNullOrWhiteSpace(payload.EmpNum) || string.IsNullOrEmpty(payload.EmpNum))
                throw new Exception("คุณยังไม่ได้กรอกรหัสพนักงาน");

            if (string.IsNullOrWhiteSpace(payload.EmpName) || string.IsNullOrEmpty(payload.EmpName))
                throw new Exception("คุณยังไม่ได้กรอกชื่อพนักงาน");

            if (string.IsNullOrWhiteSpace(payload.PositionNo) || string.IsNullOrEmpty(payload.PositionNo))
                throw new Exception("คุณยังไม่ได้เลือกตำแหน่ง");

            if (string.IsNullOrWhiteSpace(payload.DepNo) || string.IsNullOrEmpty(payload.DepNo))
                throw new Exception("คุณยังไม่ได้เลือกแผนก");

            _ = await _dataContext.Employee.AsNoTracking().FirstOrDefaultAsync(o => o.EmpNum == payload.EmpNum) ?? 
                throw new Exception("ไม่พบรหัสพนักงานที่ต้องการแก้ไขกรุณาตรวจสอบอีกครั้ง");

            _ = await _dataContext.Position.AsNoTracking().FirstOrDefaultAsync(o => o.PositionNo == payload.PositionNo) ??
                throw new Exception("ไม่พบรหัสตำแหน่งที่เลือกกรุณาตรวจสอบอีกครั้ง");

            _ = await _dataContext.Department.AsNoTracking().FirstOrDefaultAsync(o => o.DepNo == payload.DepNo) ??
                throw new Exception("ไม่พบรหัสแผนกที่เลือกกรุณาตรวจสอบอีกครั้ง");

            if (payload.EmpNum.Length > 20)
                throw new Exception("รหัสพนักงานต้องมีความยาวไม่เกิน 20 ตัวอักษร");

            if (payload.EmpName.Length > 255)
                throw new Exception("ชื่อพนักงานต้องมีความยาวไม่เกิน 255 ตัวอักษร");

            if (!string.IsNullOrWhiteSpace(payload.HeadNo) && !string.IsNullOrEmpty(payload.HeadNo))
            {
                if (payload.HeadNo.Length > 20)
                    throw new Exception("รหัสหัวหน้างานต้องมีความยาวไม่เกิน 20 ตัวอักษร");

                _ = await _dataContext.Employee.AsNoTracking().FirstOrDefaultAsync(o => o.EmpNum == payload.HeadNo) ??
                    throw new Exception("ไม่พบรหัสหัวหน้างานกรุณาตรวจสอบอีกครั้ง");
            }
        }
    }
}
