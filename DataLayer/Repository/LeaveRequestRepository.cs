using DataLayer.Interface;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class LeaveRequestRepository : IRepository<EmployeeLeave>
    {
        EmployeeLoginContext _dbContext;

        public LeaveRequestRepository(EmployeeLoginContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<EmployeeLeave> Create(EmployeeLeave _object)
        {
            var obj = await _dbContext.EmployeeLeaves.AddAsync(_object);
            Save();
            return obj.Entity;
        }

        public void Delete(EmployeeLeave _object)
        {
            _dbContext.Remove(_object);
            Save();
        }

        public IEnumerable<EmployeeLeave> GetAll()
        {
            try
            {
                return _dbContext.EmployeeLeaves.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public EmployeeLeave GetByEmpId(int Id)
        {
            return _dbContext.EmployeeLeaves.Where(x=>x.EmployeeId == Id).FirstOrDefault();
        }

        public EmployeeLeave GetById(int Id)
        {
            return _dbContext.EmployeeLeaves.Where( x=>x.Id == Id).FirstOrDefault();
        }

        public EmployeeLeave GetByName(string empName)
        {
            return _dbContext.EmployeeLeaves.Where(x => x.EmployeeName == empName).FirstOrDefault();

        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(EmployeeLeave leaveRequest)
        {
            var request = _dbContext.EmployeeLeaves.FirstOrDefault(x => x.EmployeeId == leaveRequest.EmployeeId
                    && x.IsApproved == false);
            if (request != null)
            {
                
                    request.LeaveType = leaveRequest.LeaveType;
                    request.StartDate = leaveRequest.StartDate;
                    request.EndDate = leaveRequest.EndDate;
                    request.RequestDate = DateTime.Now;
                    request.IsApproved = leaveRequest.IsApproved;
                    request.ApprovedBy = leaveRequest.ApprovedBy;
                    request.IsCancelled = leaveRequest.IsCancelled;
                   request.Comments = leaveRequest.Comments;
            }
            _dbContext.EmployeeLeaves.Update(request);
            Save();
        }

      


    }
}
