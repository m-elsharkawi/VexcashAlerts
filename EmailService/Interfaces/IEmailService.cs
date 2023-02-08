﻿using EmailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Interfaces
{
    public interface IEmailService
    {
        Task<EmailResponse> SendEmailAsync(EmailMessage emailMessage);
    }
}
