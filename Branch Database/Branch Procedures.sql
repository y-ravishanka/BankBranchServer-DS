
use bankbranch

create procedure insert_logintime
@id int
as
insert into tmp_activitylog (id,logintime) values (@id,CURRENT_TIMESTAMP)

create procedure insert_logouttime
@id int
as
update tmp_activitylog set logouttime = CURRENT_TIMESTAMP where id = @id
delete from tmp_activitylog where id = @id