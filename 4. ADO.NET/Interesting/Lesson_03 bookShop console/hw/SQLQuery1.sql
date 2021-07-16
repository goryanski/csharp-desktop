USE master
DROP DATABASE BookShop
GO

CREATE DATABASE BookShop
GO

USE BookShop
GO

CREATE TABLE Countries (
	id INT PRIMARY KEY IDENTITY,
	[name] NVARCHAR(50) NOT NULL CHECK(len([name]) > 0) UNIQUE
);

INSERT INTO Countries VALUES
('Украина'),
('Польша'),
('Германия'),
('Америка'),
('Китай');


CREATE TABLE Authors (
	id INT PRIMARY KEY IDENTITY,
	[name] NVARCHAR(MAX) NOT NULL CHECK(len([name]) > 0),
	surname NVARCHAR(MAX) NOT NULL CHECK(len(surname) > 0), 
	countryId INT,
	FOREIGN KEY (countryId) REFERENCES Countries(id)
);

INSERT INTO Authors VALUES
('Елизавета', 'Ансимова', 1),
('Матвей', 'Беляев', 4),
('Виталий', 'Горбушин', 5),
('Алексей', 'Гриненко', 2),
('Мария', 'Топорова', 3),
('Дина', 'Фазуллина', 1);

CREATE TABLE Themes (
	id INT PRIMARY KEY IDENTITY,
	[name] NVARCHAR(100) NOT NULL CHECK(len([name]) > 0) UNIQUE
);

INSERT INTO Themes VALUES
('Природа'),
('Животные'),
('Психология'),
('Философия'),
('Наука');

CREATE TABLE Books (
	id INT PRIMARY KEY IDENTITY,
	[name] NVARCHAR(MAX) NOT NULL CHECK(len([name]) > 0),
	pages INT NOT NULL CHECK(pages >= 1),
	price MONEY NOT NULL CHECK(price >= 0),
	publishDate DATE NOT NULL CHECK(publishDate <= GETDATE()),
	authorId INT,
	FOREIGN KEY (authorId) REFERENCES Authors(id),
	themeId INT,
	FOREIGN KEY (themeId) REFERENCES Themes(id),
	isDeleted BIT NOT NULL
);

INSERT INTO Books VALUES
('Небо', 455, 200, '2020-11-02', 2, 1, 0),
('Бронзовый ключ', 477, 100, '2010-12-22', 1, 2, 0),
('Похитители снов', 866, 400, '2019-11-04', 3, 3, 0),
('Красный смех', 755, 200, '2017-04-07', 4, 4, 0),
('Поднятая целина', 555, 300, '2016-09-11', 6, 5, 0);
INSERT INTO Books VALUES
('Ночь', 1000, 450, '2019-11-04', 3, 3, 0);

CREATE TABLE Shops (
	id INT PRIMARY KEY IDENTITY,
	[name] NVARCHAR(MAX) NOT NULL CHECK(len([name]) > 0),
	countryId INT,
	FOREIGN KEY (countryId) REFERENCES Countries(id)
);

INSERT INTO Shops VALUES
('Libreria El Pendulo', 2),
('Поларе', 3),
('Детская республика', 5),
('Книжный магазин Барта', 4),
('Ler Devagar', 1);

CREATE TABLE Sales (
	id INT PRIMARY KEY IDENTITY,
	price MONEY NOT NULL CHECK(price >= 0),
	quantity INT NOT NULL CHECK(quantity >= 1),
	saleDate DATE NOT NULL CHECK(saleDate <= GETDATE()) DEFAULT GETDATE(),
	bookId INT,
	FOREIGN KEY (bookId) REFERENCES Books(id),
	shopId INT,
	FOREIGN KEY (shopId) REFERENCES Shops(id)
);

INSERT INTO Sales VALUES
(1000, 5, '2020-12-04', 1, 2),
(500, 5, '2020-12-04', 2, 3),
(800, 2, '2020-12-05', 3, 4),
(600, 3, '2020-12-06', 4, 1),
(300, 1, '2020-12-07', 5, 5);
GO







-- задание
create table People (
	id int primary key identity,
	firstName nvarchar(30) NOT NULL,
	lastName nvarchar(30) NOT NULL,
	birth date NOT NULL
);
go

create table Accounts (
	id int primary key identity,
	[login] varchar(30) NOT NULL unique,
	[password] varchar(30) NOT NULL,
	regDate date default getdate()
);
go

alter table People add accountId int;
alter table People add constraint fk_people_account_id_accounts foreign key (accountId) references Accounts (id);

select * from People;
select * from Accounts;

GO

create or alter procedure sp_Registration
		@login varchar(30),
		@pasword varchar(30),
		@firstName nvarchar(30),
		@lastName nvarchar(30),
		@birth date
	as
begin
	INSERT INTO Accounts ([login], [password]) VALUES (@login, @pasword); 
	INSERT INTO People VALUES (@firstName, @lastName, @birth, @@IDENTITY);
end
go

