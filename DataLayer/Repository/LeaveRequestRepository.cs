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
    public class LeaveRequestRepository : IRepository<LeaveRequest>
    {
        ApplicationDbContext _dbContext;

        public LeaveRequestRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<LeaveRequest> Create(LeaveRequest _object)
        {
            var obj = await _dbContext.LeaveRequests.AddAsync(_object);
            Save();
            return obj.Entity;
        }

        public void Delete(LeaveRequest _object)
        {
            _dbContext.Remove(_object);
            Save();
        }

        public IEnumerable<LeaveRequest> GetAll()
        {
            try
            {
                return _dbContext.LeaveRequests.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public LeaveRequest GetByEmpId(string Id)
        {
            return _dbContext.LeaveRequests.Where(x=>x.Employee_Id == Id).FirstOrDefault();
        }

        public LeaveRequest GetById(int Id)
        {
            return _dbContext.LeaveRequests.Where( x=>x.Id == Id).FirstOrDefault();
        }

        public LeaveRequest GetByName(string empName)
        {
            return _dbContext.LeaveRequests.Where(x => x.Employee_Name == empName).FirstOrDefault();

        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(LeaveRequest leaveRequest)
        {
            var request = _dbContext.LeaveRequests.FirstOrDefault(x => x.Employee_Id == leaveRequest.Employee_Id
                    && x.Approved == false);
            if (request != null)
            {
                              
                
                    request.LeaveType = leaveRequest.LeaveType;
                    request.Start_Date = leaveRequest.Start_Date;
                    request.End_Date = leaveRequest.End_Date;
                    request.Requested_Date = DateTime.Now;
                request.Approved = leaveRequest.Approved;
                request.ApprovedBy_Id = leaveRequest.ApprovedBy_Id;
                request.Cancelled = leaveRequest.Cancelled;
              
                
            }

            _dbContext.LeaveRequests.Update(request);
           
            Save();
        }

      


    }
}
