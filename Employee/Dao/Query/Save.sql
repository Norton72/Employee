insert into Users (CompanyId, Surname, Name, PhoneNumber, PassportType, PassportNumber)
values 
(@CompanyId, @Surname, @Name, @PhoneNumber, @PassportType, @PassportNumber);

select cast(scope_identity() as int);