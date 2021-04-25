# banco_atlantico_caixa
Caixa Eletrônico do banco Atlantico


#banco de dados para caixa
Create Database BancoAtlanticoCaixa
go

Use BancoAtlanticoCaixa
go

Create table Notas
(
Id uniqueidentifier primary key,
Valor int not null 
)
Go

Create table Status
(
Id int primary key,
Descricao varchar(max) not null
)
Go

insert into Notas values (NewId(), 50), (NewId(), 20), (NewId(), 10), (NewId(), 5), (NewId(), 2)
Go

Alter Table Status add Nome varchar(30)
Go

Alter Table Status Add Horario Datetime 
Go

Alter TAble Status Add Constraint Horario_Default Default GETDATE() FOR Horario
Go

Alter Table Notas Add Quantidade int not null default(0)
Go


Alter Table Notas add constraint valor_unico unique(Valor)
Go