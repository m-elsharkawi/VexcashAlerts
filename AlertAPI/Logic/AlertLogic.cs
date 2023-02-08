using AlertAPI.Models;
using DataAccess;
using DataAccess.Controllers;
using DataAccess.Interfaces;
using EmailService.Controllers;
using EmailService.Interfaces;
using EmailService.Models;

namespace AlertAPI.Logic
{
    public class AlertLogic
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomerDataAccess _customerDataAccess;
        private readonly IAlertTemplateDataAccess _alertTemplateDataAccess;
        private readonly IAlertLogDataAccess _alertLogDataAccess;
        private readonly IEmailService _emailService;

        public AlertLogic (IConfiguration configuration)
        {
            _configuration = configuration;
            _customerDataAccess = new CustomerDataController(configuration);
            _alertTemplateDataAccess = new AlertTemplateDataController(configuration);
            _alertLogDataAccess = new AlertLogDataController(configuration);
            _emailService = new SendGridEmailService(configuration);
        }
        public async Task<Customer> GetCustomerData(string creditNumber)
        {
            Customer customer = new Customer();
            DataAccess.Models.Customer customerData = new DataAccess.Models.Customer();
            customerData = await _customerDataAccess.GetCustomer(creditNumber);
            if(customerData != null)
            {
                customer.CustomerId = customerData.CustomerId;
                customer.CustomerName = customerData.CustomerName;
                customer.CreditNumber= customerData.CreditNumber;
                customer.PhoneNumber= customerData.PhoneNumber;
                customer.Email= customerData.Email;
                customer.Amount= customerData.Amount;
                customer.DueDate = customerData.DueDate;

                return customer;
            }
            return null;
        }

        public async Task<AlertTemplate> GetAlertTemplateData(int id)
        {
            AlertTemplate alertTemplate = new AlertTemplate();
            DataAccess.Models.AlertTemplate alertTemplateData = new DataAccess.Models.AlertTemplate();
            alertTemplateData = await _alertTemplateDataAccess.GetAlertTemplate(id);
            if(alertTemplateData != null)
            {
                alertTemplate.AlertTemplateId = id;
                alertTemplate.AlertTemplateName = alertTemplateData.AlertTemplateName;
                alertTemplate.AlertTypeId = alertTemplateData.AlertTypeId;
                alertTemplate.AlertSubject = alertTemplateData.AlertSubject;
                alertTemplate.AlertText = alertTemplateData.AlertText;

                return alertTemplate;
            }

            return null;
        }

        public async Task<EmailResponse> SendAlert(Alert alert)
        {
            EmailMessage emailMessage = new EmailMessage();
            Customer customer = await GetCustomerData(alert.CreditNumber);
            AlertTemplate alertTemplate = await GetAlertTemplateData(alert.AlertTemplateId);
            emailMessage.Subject = alertTemplate.AlertSubject;
            emailMessage.FromName = "Vexcash Notifications";
            emailMessage.FromEmail = "mohamed.m.sharkawy@gmail.com";
            emailMessage.ToEmail = customer.Email;
            string message = alertTemplate.AlertText;
            message = message.Replace("{CreditNumber}", customer.CreditNumber);
            message = message.Replace("{CustomerName}", customer.CustomerName);
            message = message.Replace("{DueDate}", customer.DueDate.ToShortDateString());
            message = message.Replace("{Amount}", customer.Amount.ToString());
            message = message.Replace("\\n", "</br>");
            emailMessage.Message = message;

            var response = await _emailService.SendEmailAsync(emailMessage);
            if (response.Success)
            {
                DataAccess.Models.AlertLog alertLog = new DataAccess.Models.AlertLog();
                alertLog.AlertText = message;
                alertLog.CustomerId = customer.CustomerId;
                await _alertLogDataAccess.InsertAlertLog(alertLog);
                return response;
            }
            return response;
        }
    }


}
