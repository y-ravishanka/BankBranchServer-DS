
create database bankbranch

use bankbranch

create table customer
(
	id int identity(1,1),
	nic varchar(15)  not null,
	fname varchar(100)  not null,
	lname varchar(200)  not null,
	dob varchar(10)  not null,
	saddress varchar(200)  not null,
	city varchar(50)  not null,
	distric varchar(50)  not null,
	province varchar(50)  not null,
	zip varchar(10)  not null,
	citizenship varchar(30)  not null,
	currency varchar(3)  not null,
	phone1 varchar(12)  not null,
	phone2 varchar(12)  null,
	email varchar(100)  null,
	branchid int not null,
	primary key (nic)
)

select * from customer
delete customer
drop table customer

create table account
(
	number int not null,
	nic varchar(15) not null,
	balance float not null,
	active varchar(5) default 'true',
	branchid int not null,
	createby int not null,
	primary key (number)
)

select * from account
delete account
drop table account


create table transactions
(
	id varchar(20) not null,
	date varchar(10) not null,
	type varchar(10) not null,
	account int not null,
	amount float not null,
	depositor varchar(15) null,
	primary key (id)
)

select * from transactions
delete transactions
drop table transactions

create table userstatus
(
	id int identity(1,1),
	date varchar(20) not null,
	nic varchar(15) not null,
	deposits int default 0,
	damount float default 0,
	withdraws int default 0,
	wamount float default 0,
	balance float default 0,   /* no need to enter a value system with auto fill it */
	newaccounts int default 0,
	primary key (date,nic)
)

select * from userstatus
delete userstatus
drop table userstatus

create table fullstatus
(
	id int identity(1,1),
	date varchar(20) not null,
	deposits int default 0,
	damount float default 0,
	withdraws int default 0,
	wamount float default 0,
	balance float default 0,   /* no need to enter a value system with auto fill it */
	newaccounts int default 0,
	primary key (date)
)

select * from fullstatus
delete fullstatus
drop table fullstatus

insert into fullstatus(date) values ('2022/12/03')

update fullstatus set damount = 123 where date = (select top 1 date from fullstatus order by id desc)
update fullstatus set wamount = 1485 where date = (select top 1 date from fullstatus order by id desc)

create table tmp_activitylog
(
	id int not null,
	logintime datetime not null,
	logouttime datetime null,
	primary key (id)
)

select * from tmp_activitylog
delete tmp_activitylog
drop table tmp_activitylog

exec insert_logintime @id = 1321414
exec insert_logouttime @id = 1321414

create table activitylog
(
	id int not null,
	logintime datetime not null,
	logouttime datetime null,
	primary key (id,logintime)
)

select * from activitylog
delete activitylog
drop table activitylog

/*
create table test
(
	id int,
	string varchar(12)
)

select * from test
delete test
drop table test

SELECT CONVERT(nvarchar(10),LEFT(REPLACE(NEWID(),'-',''),10))

insert into test (id,string) values (12,CONVERT(nvarchar(10),LEFT(REPLACE(NEWID(),'-',''),10)))
*/

create table login_details
(
	id int not null,
	nic varchar(13) not null,
	password varchar(16) null,  /* no need to enter a value system with auto fill it */
	posision varchar(30) not null,
	active varchar(10) default 'true', /* no need to enter a value */
	resetpass int default 0,
	primary key (nic)
)

select * from login_details
delete login_details
drop table login_details

select 1

create table branchdata
(
	id int not null,
	name varchar(100) not null,
	saddress varchar(200) not null,
	city varchar(50) not null,
	distric varchar(50) not null,
	province varchar(50) not null,
	zip varchar(10) not null,
	phone1 varchar(12) not null,
	phone2 varchar(12) not null,
	email varchar(100) not null,
	managerid int not null
)

select * from branchdata
delete branchdata
drop table branchdata

create table systemdata /* not created */
(
	email varchar(100) not null,
	password varchar(20) not null
)

select * from systemdata
delete systemdata
drop table systemdata