--GERENCIADOR DAS CAIXAS
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

