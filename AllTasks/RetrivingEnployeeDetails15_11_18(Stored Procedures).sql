create table Employee(
EmpID int IDENTITY(1,1) primary key,
EmpName nvarchar(500),
EmpAddress nvarchar(1000),
Salary Dec(7,2),
Designation nvarchar(500),
Active bit
)

create table Project(
ProjectID int IDENTITY(1,1),
EmployeID int foreign key references Employee(EmpID) on delete cascade,
ProjectName nvarchar(500),
Projectstarting datetime,
Projectending datetime
)


create or ALTER procedure USP_UploadEmployeeDetails(
	@name nvarchar(500),
	@address nvarchar(1000),
    @salary dec(7,2),
    @designation nvarchar(1000),  
    @active bit,
    @projectname nvarchar(500),
	@starting datetime,
	@ending datetime)
as
DECLARE @EmpId int; 
begin 
	insert into Employee(EmpName,EmpAddress,Salary,Designation,Active)values(@name,@address,@salary,@designation,@active);
	set @EmpId=SCOPE_IDENTITY();
	insert into Project(EmployeID,ProjectName,Projectstarting,Projectending)values(@EmpId,@projectname,@starting,@ending);
end
-----------------------------------------------------------------------------------------------------------------------
create or ALTER procedure USP_EmployeeDetails(
	@name nvarchar(500)
	)
as
DECLARE @EmpId int; 
begin 
	select e.EmpID,e.EmpName,e.Designation,e.Salary,e.EmpAddress,e.Active,p.ProjectName,p.Projectstarting,p.Projectending from Employee e 
	Inner join Project p on p.EmployeID = e.EmpID
	where e.EmpName=@name
end
----------------------------------------------------------------------------------------------------------------------
Exec Proc_UploadEmployeeDetails 'sai','HYd',12414.25,'Developer','true','bajaj','12/12/12','2014-11-10'

select *from Employee
select *from Project

insert into Employee(EmpName,EmpAddress,Salary,Designation,Active)values('fghgf','dfsjsdgjks',151.14,'dfkhsdk','true')

drop table Employee
drop table Project
insert into Project(EmployeID,ProjectName,Projectstarting,Projectending)values(1,'Operactions',12-12-12,12-12-12)