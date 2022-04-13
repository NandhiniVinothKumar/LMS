using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class ErrorModel
    {
        public string Request_Id { get; set; }

        public bool ShowRequest_Id => !string.IsNullOrEmpty(Request_Id);
    }
}
