/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Willyt Lecky', '8034871494', 1285.18, '474-266-7046', 'mohamed.m.sharkawy@gmail.com', '5/16/2022');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Carleton Sutherley', '9400838522', 139.18, '348-926-5944', 'mohamed.m.sharkawy@gmail.com', '3/4/2022');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Jeanna Chinnick', '1325321222', 2601.34, '241-279-2518', 'mohamed.m.sharkawy@gmail.com', '10/15/2022');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Benni Wharlton', '3652268903', 1013.15, '946-730-0988', 'mohamed.m.sharkawy@gmail.com', '11/18/2022');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Sigismund Rambaut', '7570364430', 571.3, '771-338-6643', 'mohamed.m.sharkawy@gmail.com', '1/14/2023');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Marc Driffill', '6335664445', 2170.15, '512-307-0021', 'mohamed.m.sharkawy@gmail.com', '12/2/2022');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Efren Avrahamy', '3881482539', 1866.48, '651-462-4200', 'mohamed.m.sharkawy@gmail.com', '4/7/2022');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Hendrik Dumbellow', '7142565950', 1764.16, '690-487-9246', 'mohamed.m.sharkawy@gmail.com', '8/18/2022');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Carroll Fuster', '1969716932', 448.64, '998-219-6558', 'mohamed.m.sharkawy@gmail.com', '3/14/2022');
insert into Customer (CustomerName, CreditNumber, Amount, PhoneNumber, Email, DueDate) values ('Anselm MacKimmie', '6001609829', 1747.47, '807-354-0033', 'mohamed.m.sharkawy@gmail.com', '9/18/2022');


insert into AlertType (AlertTypeName) values ('Reminder');
insert into AlertType (AlertTypeName) values ('Warning');
insert into AlertType (AlertTypeName) values ('Confirmation');

insert into AlertTemplate (AlertTemplateName, AlertTypeId, AlertSubject, AlertText) values ('Payment Reminder', 1, 'Payment Reminder', 'CreditNumber:{CreditNumber}\n Dear {CustomerName},\nPlease pay by {DueDate} the amount {Amount}\n Greetings Vexcash');
insert into AlertTemplate (AlertTemplateName, AlertTypeId, AlertSubject, AlertText) values ('Late Payment Warning', 2, 'Late Payment!', 'CreditNumber:{CreditNumber}\n Dear {CustomerName},\n the amount {Amount} was not paid by {DueDate}. The following charges will be applied.\n Greetings Vexcash');
insert into AlertTemplate (AlertTemplateName, AlertTypeId, AlertSubject, AlertText) values ('Payment Confirmation', 3, 'Payment Confirmation', 'CreditNumber:{CreditNumber}\n Dear {CustomerName},\n the amount {Amount} was paid in your account.\n Greetings Vexcash');
