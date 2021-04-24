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