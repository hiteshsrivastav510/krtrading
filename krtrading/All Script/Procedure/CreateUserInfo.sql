
create or alter proc CreateUserInfo
@UserName nvarchar(256),
@Mobile nvarchar(16),
@FirstName nvarchar(100),
@LastName nvarchar(100),
@Password nvarchar(256),
@Email nvarchar(512)
as
begin
	set nocount on
	BEGIN TRY
		BEGIN TRAN
			declare @UserId uniqueidentifier
			if not exists(select UserId from Users where UserName=@UserName)
		begin
			set @UserId=NEWID();
			insert into Users(UserId,UserName,LoweredUserName,Mobile,FirstName,LastName,LastActivityDate)
			values(@UserId,@UserName,LOWER(@UserName),@Mobile,@FirstName,@LastName,GETDATE())

			insert into UserMembership(UserId,Password,Email,LoweredEmail,IsApproved,IsLockedOut,CreatedDate,LastLoginDate,LastPasswordChangeDate,LastLockedOutDate,FailedPasswordAttemptCount,FailedPasswordAttemptCountDate,FailedPasswordAnswerCount,FailedPasswordAnswerCountDate)
			values(@UserId,@Password,@Email,LOWER(@Email),1,0,GETDATE(),GETDATE(),GETDATE(),GETDATE(),0,GETDATE(),0,GETDATE())

			declare @RoleId uniqueidentifier=(select top 1 RoleId from Roles where RoleName='CompanyUser')
			insert into UsersInRoles(UserId,RoleId)
			values(@UserId,@RoleId)
		end
			select @UserId as UserId
		COMMIT TRAN
	END TRY
	BEGIN CATCH
	 ROLLBACK TRAN
	 INSERT INTO ErrorLogging(ErrorDesc,MoreInfo,generatedDate,ActionResultName)
	 values(ERROR_MESSAGE(),ERROR_LINE(),GETDATE(),ERROR_PROCEDURE())
	END CATCH
end