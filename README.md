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

update Notas set quantidade = 50

#Dados Mockados
O método ObterSaldoCliente() retorna um valor fixo de 2000
Este metodo se conecta ao serviço da conta do cliente para obter o saldo.


========================================================================================================
#GERENCIADOR DAS CAIXAS
Create Database BancoAtlanticoGC
go

Use BancoAtlanticoGC
go

Create table Caixa
(
Id uniqueidentifier primary key,
Nome varchar(50) not null
)
Go

Create table Status
(
Id uniqueidentifier primary key,
CaixaId uniqueidentifier not null references Caixa(Id),
CodigoStatus varchar(15) not null
)
Go

CREATE TABLE Notas(
	Id uniqueidentifier NOT NULL,
	Valor int NOT NULL,
	Quantidade int NOT NULL,
	CaixaId uniqueidentifier not null references Caixa(Id),
	QuantidadeCritico int default(0)
)
GO

