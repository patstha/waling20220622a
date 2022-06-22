create table person
(
	id int identity primary key,
	legalname nvarchar(255) not null,
	preferredname nvarchar(255) null,
);