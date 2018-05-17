use invictus;
create table USERS (
	Id bigint identity(1,1) primary key,
	Username varchar(255),
	Password varchar(255),
	Name varchar(255)
);
insert into Users(username, password, name) values ('invictus@gmail.com', 'admin123', 'Invictus');
select * from Users;