USE MASTER;
GO

CREATE DATABASE Marketplace
       ON PRIMARY (NAME=N'Marketplace', FILENAME=N'C:\Users\hugo\Desktop\Impacta\C#\03\ImpactaAspNet\Dados\Marketplace.MDF')
       LOG ON (NAME=N'Marketplace_LOG', FILENAME=N'C:\Users\hugo\Desktop\Impacta\C#\03\ImpactaAspNet\Dados\Marketplace_LOG.LDF')
GO

USE Marketplace;
GO

CREATE TABLE Cliente
(
       Id INT PRIMARY KEY IDENTITY(1,1),
       Documento varchar(14) not null,
       Nome varchar(60) not null,
       Telefone varchar(20) not null,
       Email varchar(60) not null,
       CONSTRAINT UKClienteDocumento UNIQUE(Documento),       
       CHECK(LEN(Documento) = 11 OR LEN(Documento) = 14)
);
GO
CREATE TABLE Pedido
(
       Id int IDENTITY(1,1) not null,
       IdCliente int not null,
       Data datetime not null,
       Numero varchar(20) not null,
       PRIMARY KEY (Id),
       FOREIGN KEY (IdCliente) REFERENCES Cliente (Id)
);
GO
CREATE TABLE Categoria
(
       Id int IDENTITY(1,1) not null,
       Descricao varchar(20) not null,
       PRIMARY KEY (Id)
);
GO
CREATE TABLE Produto
(
       Id int IDENTITY(1,1) not null,
       IdCategoria int not null,
       Descricao varchar(50) not null,
       Unidade varchar(10) not null,
       Preco Decimal(11, 2) not null,
       PRIMARY KEY (Id),
       FOREIGN KEY (IdCategoria) REFERENCES Categoria (Id)
);
GO
CREATE TABLE ProdutoFoto
(
       Id int IDENTITY(1,1) not null,
       IdProduto int not null,
       Foto varbinary(MAX),
       MimeType varchar(20),
       PRIMARY KEY (Id),
       FOREIGN KEY (IdProduto) REFERENCES Produto (Id)
);
GO
CREATE TABLE ItemPedido
(
       Id int IDENTITY(1,1) not null,
       IdPedido int not null,
       IdProduto int not null,
       Quantidade float not null,
       PRIMARY KEY (Id),
       FOREIGN KEY (IdPedido) REFERENCES Pedido (Id),
       FOREIGN KEY (IDProduto) REFERENCES Produto (Id)
);
GO
CREATE TABLE [Cartao]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdCliente int not null,
    [Guid] UNIQUEIDENTIFIER NOT NULL,
    [Mascara] NVARCHAR(20) NOT NULL,
    [Apelido] NVARCHAR(50) NULL,
    FOREIGN KEY (IdCliente) REFERENCES Cliente (Id)
);
GO