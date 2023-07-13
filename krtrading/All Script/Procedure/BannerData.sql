create or alter  Proc BannerData
@BannerImg nvarchar(max)=null,
@Action nvarchar(250),
@BannerId int=null
as

begin
declare @Seq int,@seq2 int=0,@BId int=0
if(@Action='Insert')
begin
declare @MaxSequence int=(select  top 1 Sequence from Banner order by Sequence desc) 
 set @MaxSequence=ISNULL(@MaxSequence,0)
 set @MaxSequence=@MaxSequence+1
insert into Banner(BannerImg, Sequence,isdelete,status,created_date) 
values (@BannerImg,@MaxSequence,0,1,GETDATE())
end
else if(@Action='Delete' And @BannerId<>0 )
begin 
update Banner set isdelete=1 where id=@BannerId
end
else if(@Action='UpBanner' And @BannerId<>0 )
begin 
	select @Seq=Sequence from Banner where id=@BannerId and isdelete=0 and status=1
	if exists(select id from Banner 
	where Sequence<@Seq and isdelete=0 and status=1)
	begin
		select top 1 @seq2=Sequence,@BId=id from Banner 
		where Sequence<@Seq and isdelete=0 and status=1
		order by Sequence desc
	end
	else 
	begin
		select top 1 @seq2=Sequence,@BId=id
		from Banner 
		where isdelete=0 and status=1
		order by Sequence desc
	end
	if(@seq2=0 and @BId=0)
	begin
		set @seq2=@Seq
		set @BId=@BId
	end
	update Banner set Sequence=@seq2 where id=@BannerId
	update Banner set Sequence=@seq where id=@BId
end
else if(@Action='DownBanner' And @BannerId<>0 )
begin 
	select @Seq=Sequence from Banner where id=@BannerId and isdelete=0 and status=1
	
	if exists(select id from Banner 
	where Sequence>@Seq and isdelete=0 and status=1)
	begin
		select top 1 @seq2=Sequence,@BId=id from Banner 
		where Sequence>@Seq and isdelete=0 and status=1
	end
	else 
	begin
		select top 1 @seq2=Sequence,@BId=id
		from Banner 
		where isdelete=0 and status=1
	end
	if(@seq2=0 and @BId=0)
	begin
		set @seq2=@Seq
		set @BId=@BId
	end
	update Banner set Sequence=@seq2 where id=@BannerId
	update Banner set Sequence=@seq where id=@BId
end
else if(@Action='BindData' )
 begin
 select  id,BannerImg,count(*) over() as TotalRecord 
 from Banner where status=1 and isdelete=0
 order by Sequence
 end
end

