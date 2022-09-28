--Cria��o da base de dados
CREATE DATABASE MaisSaude;

--Acessa a base de dados
USE MaisSaude;

--Cria��o de tabela
CREATE TABLE TipoUsuario
(
--Identity vai incrementar o ID automaticamente
	Id INT PRIMARY KEY IDENTITY,

--NVARCHAR que aceita at� 50 caracteres
    Tipo NVARCHAR(50)
);
GO
CREATE TABLE Usuario
(
--Identity vai incrementar o ID automaticamente
	Id INT PRIMARY KEY IDENTITY,

--NVARCHAR que aceita at� 50 caracteres
    Nome NVARCHAR(50),
	Email NVARCHAR(50),
	Senha NVARCHAR(250),

	--DecLara��o de FK
	IdTipoUsuario INT
	FOREIGN KEY (IdTipoUsuario) REFERENCES TipoUsuario(Id)
);
GO
CREATE TABLE Especialidade
(
--Identity vai incrementar o ID automaticamente
	Id INT PRIMARY KEY IDENTITY,

--NVARCHAR que aceita at� 50 caracteres
    Categoria NVARCHAR(50)
);
GO

CREATE TABLE Medico
(
--Identity vai incrementar o ID automaticamente
	Id INT PRIMARY KEY IDENTITY,

--NVARCHAR que aceita at� 50 caracteres
    CRM NVARCHAR(50),

	--DecLara��o de FK
	IdEspecialidade INT
	FOREIGN KEY (IdEspecialidade) REFERENCES Especialidade(Id),
	IdUsuario INT
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
);
GO

CREATE TABLE Paciente
(
--Identity vai incrementar o ID automaticamente
	Id INT PRIMARY KEY IDENTITY,

--NVARCHAR que aceita at� 50 caracteres
    Carteirinha NVARCHAR(50),
	DataNascimento DATETIME,
	Ativo bit,

	--DecLara��o de FK
	IdUsuario INT
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
);
GO

CREATE TABLE Consulta
(
--Identity vai incrementar o ID automaticamente
	Id INT PRIMARY KEY IDENTITY,

--NVARCHAR que aceita at� 50 caracteres
	DataHora DATETIME,

	--DecLara��o de FK
	IdMedico INT
	FOREIGN KEY (IdMedico) REFERENCES Medico(Id),

	IdPaciente INT
	FOREIGN KEY (IdPaciente) REFERENCES Paciente(Id)
);
GO
