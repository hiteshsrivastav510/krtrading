create or alter  Proc BannerData
@BannerImg nvarchar(max),
@Sequence int,
@Action nvarchar(250),
@BannerId int
as

begin
declare @MaxSequence int=(select  top 1 Sequence from Banner order by Sequence desc) 
if(@Action='Insert' And @BannerId=0 )
begin 
 set @MaxSequence=ISNULL(@MaxSequence,0)
 set @MaxSequence=@MaxSequence+1
insert into Banner(BannerImg, Sequence,isdelete,status,created_date) 
values (@BannerImg,@MaxSequence,0,1,GETDATE())
end
else if(@Action='Delete' And @BannerId<>0 )
begin 
update Banner set isdelete=1 where id=@BannerId
end
else if(@Action='BindData' )

 begin
 select  * from Banner where status=1 and isdelete=0
 end
end

