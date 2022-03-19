alter procedure addEmployeeDetails
(
 @EmployeeName varchar(30),
 @ProfileImg varchar(40),
 @Gender varchar(10),
 @Department varchar(40),
 @Salary int,
 @StartDate datetime,
 @Notes varchar(200)
)
as
begin try
     insert into EmployeeDetails values(@EmployeeName,@ProfileImg,@Gender,@Department,@Salary,@StartDate,@Notes)
end try
begin catch
select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
End catch


alter procedure deleteEmployeeDetails	
(
 @EmployeeId int
)
as
begin try
     delete from EmployeeDetails where EmployeeId = @EmployeeId	 
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


alter procedure getEmployeeDetails
as
begin try
     select * from EmployeeDetails
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch


alter procedure updateEmployeeDetails	
(
 @EmployeeId int,
 @EmployeeName varchar(30),
 @ProfileImg varchar(40),
 @Gender varchar(10),
 @Department varchar(40),
 @Salary int,
 @StartDate datetime,
 @Notes varchar(200)
)
as
begin try
     update EmployeeDetails set EmployeeName=@EmployeeName,ProfileImg=@ProfileImg,Gender=@Gender,Department=@Department,Salary=@Salary,StartDate=@StartDate,Notes=@Notes where EmployeeId = @EmployeeId	 
end try
begin catch
  select
    ERROR_NUMBER() as ErrorNumber,
    ERROR_STATE() as ErrorState,
    ERROR_PROCEDURE() as ErrorProcedure,
    ERROR_LINE() as ErrorLine,
    ERROR_MESSAGE() as ErrorMessage;
end catch