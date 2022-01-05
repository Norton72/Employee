update
    users
set
    Name	= @Name,
    Surname = @Surname,
    PhoneNumber = @PhoneNumber,
    CompanyId = @CompanyId,
    PassportType = @PassportType,
    PassportNumber = @PassportNumber
where Id = @id;

select cast(scope_identity() as int);