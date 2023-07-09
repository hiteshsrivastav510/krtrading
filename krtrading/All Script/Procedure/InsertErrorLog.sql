create or alter proc InsertErrorLog
@ErrorDesc nvarchar(max),
@MoreInfo nvarchar(max),
@UserName nvarchar(max),
@ActionResultName nvarchar(500),
@ControllerName nvarchar(500)
as
begin
	insert into ErrorLogging
	values(@ErrorDesc,@MoreInfo,GETDATE(),@UserName,@ActionResultName,@ControllerName)
end