create database EmployeePayrollMVC

use EmployeePayrollMVC

create table EmployeeDetails(EmployeeId int identity (1,1) primary key, EmployeeName varchar(30) not null, ProfileImg varchar(40) not null, Gender varchar(10) not null, Department varchar(40) not null,Salary int not null, StartDate datetime not null, Notes varchar(200) not null);
select * from EmployeeDetails