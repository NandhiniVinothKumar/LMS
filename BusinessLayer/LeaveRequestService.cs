using DataLayer.Interface;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class LeaveRequestService
    {
        private readonly IRepository<EmployeeLeave> _leaveRequest;
        private readonly ILoggerFactory loggerFactory;
       
        public LeaveRequestService()
        {

        }
        public LeaveRequestService(IRepository<EmployeeLeave> leaveRequest)
        {
            _leaveRequest = leaveRequest;
        }

        //Get Leave Request By  Id
        public EmployeeLeave GetRequeById(int Id)
        {
            try
            {

                return _leaveRequest.GetById(Id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        //Get Leave Details By employee Id
        public EmployeeLeave GetRequeByEmployeeId(int empId)
        {
            return 
                _leaveRequest.GetByEmpId(empId);
        }


        //GET All Request Details 
        public IEnumerable<EmployeeLeave> GetAllRequests()
        {
            try
            {
                return _leaveRequest.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Leave Request
        public async Task<EmployeeLeave> CreateLeaveRequest(EmployeeLeave leaveRequest)
        {
            return await _leaveRequest.Create(leaveRequest);
        }

        //Delete Leave Request 
        public bool DeleteRequest(int Id)
        {
            try
            {
                var DataList = _leaveRequest.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _leaveRequest.Delete(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                
                return false; ;
            }

        }

        //Update Request Details
        public bool UpdateRequest(EmployeeLeave leaveRequest)
        {
            try
            {
                if (_leaveRequest.GetAll().Any(x => x.EmployeeId == leaveRequest.EmployeeId 
                    && (x.IsApproved == false || x.IsApproved == null)))
                {
                    _leaveRequest.Update(leaveRequest);
                }
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
           
        }

    }
}
