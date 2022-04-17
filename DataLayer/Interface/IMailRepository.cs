using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{

    public interface IMailRepository
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
