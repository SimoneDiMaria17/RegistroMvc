select * from [User]

insert into [User] (username,[password]) values('pippo','cocaina');

Create Table [Studenti](
	StudentiID int not null primary key identity(1,1),
	Nome varchar(50) not null,
	DataCreazione datetime2(3) default getdate()
)

Create Table [Lezione](
	LezioneId int not null primary key identity(1,1),
	UserId int not null foreign key references [User](UserId),
	DataLezione  datetime2(3) not null unique
)

Create Table LezioniStudenti(
	LezioniStudentiId  int not null primary key identity(1,1),
	LezioneId int not null foreign key references [Lezione](LezioneId),
	StudenteId int not null foreign key references [Studenti](StudentiID),
	Presente bit not null default 0
)

INSERT INTO Lezione (UserId, DataLezione) VALUES
(1, '2026-01-10 09:00:00.000'),
(1, '2026-01-11 09:00:00.000'),
(1, '2026-01-12 09:00:00.000'),
(1, '2026-01-13 09:00:00.000'),
(1, '2026-01-14 09:00:00.000');

INSERT INTO Studenti (Nome) VALUES
('Mario Rossi'),
('Luca Bianchi'),
('Anna Verdi'),
('Giulia Neri'),
('Paolo Gallo'),
('Sara Ferrari'),
('Marco Conti'),
('Elena Romano'),
('Davide Ricci'),
('Francesca Marino');

insert into LezioniStudenti(LezioneId,StudenteId)values(1,1)

select * from Studenti
select * from Lezione
select * from LezioniStudenti