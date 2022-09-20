
use bankbranch

create trigger setBalance_fullstatus
on fullstatus
after update
as
begin
update fullstatus set balance = ((select top 1 damount from fullstatus order by id desc)-(select top 1 wamount from fullstatus order by id desc)) where date = (select top 1 date from fullstatus order by id desc)
end

create trigger setBalance_userstatus
on userstatus
after update
as
begin
update userstatus set balance = ((select top 1 damount from userstatus order by id desc)-(select top 1 wamount from userstatus order by id desc)) where date = (select top 1 date from userstatus order by id desc)
end

create trigger insert_activitylog
on tmp_activitylog
for delete
as 
begin
insert into activitylog select * from deleted
end

create trigger insert_password
on login_details
for insert
as
begin
update login_details set password = CONVERT(nvarchar(10),LEFT(REPLACE(NEWID(),'-',''),10)) where nic = (select nic from inserted)
end