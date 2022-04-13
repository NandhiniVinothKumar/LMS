using DataLayer.Interface;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class LeaveRequestService
    {
        private readonly IRepository<LeaveRequest> _leaveRequest;
       
        public LeaveRequestService()
        {

        }
        public LeaveRequestService(IRepository<LeaveRequest> leaveRequest)
        {
            _leaveRequest = leaveRequest;
        }

        //Get Leave Request By  Id
        public LeaveRequest GetRequeById(int Id)
        {
            return
                _leaveRequest.GetById(Id);
        }

        //Get Leave Details By employee Id
        public LeaveRequest GetRequeByEmployeeId(string empId)
        {
            return 
                _leaveRequest.GetByEmpId(empId);
        }


        //GET All Request Details 
        public IEnumerable<LeaveRequest> GetAllRequests()
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
        public async Task<LeaveRequest> CreateLeaveRequest(LeaveRequest leaveRequest)
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
            catch (Exception)
            {
                return true;
            }

        }

        //Update Request Details
        public bool UpdateRequest(LeaveRequest leaveRequest)
        {
            try
            {
                if (_leaveRequest.GetAll().Any(x => x.Employee_Id == leaveRequest.Employee_Id 
                    && x.Approved==false))
                {
                    _leaveRequest.Update(leaveRequest);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

       

    }
}
