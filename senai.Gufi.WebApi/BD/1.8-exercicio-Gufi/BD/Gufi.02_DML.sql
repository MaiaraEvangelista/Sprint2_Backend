--DML

--Uso do banco
USE Gufi;
GO


--INSER��O DAS TABELAS
INSERT INTO tiposUsuario(tituloTipoUsuario)
VALUES					('Administrador')
					   ,('Comum');
GO

INSERT INTO usuario(idTipoUsuario, nomeUsuario, email, senha)
VALUES			   (1, 'Administrador', 'adm@adm.com', 'adm123')
				  ,(2, 'Caique', 'caique@email.com', 'caique123')
				  ,(2, 'Saulo', 'saulo@email.com', 'saulo123');
GO

INSERT INTO instituicao(CNPJ, nomeFantasia, endereco)
VALUES				   ('99999999999999', 'Escola SENAI de Inform�tica', 'Al. Bar�o de Limeira, 538');
GO

INSERT INTO tiposEvento(tituloEvento)
VALUES				   ('C#')
					  ,('ReactJs')
					  ,('SQL');
GO

INSERT INTO eventos(idTipoEvento, idInstituicao, nomeEvento, acessoLivre, dataEvento, descricao)
VALUES			   (1, 1, 'POO', 1, '07/04/2021', 'Conceitos sobre os pilares da programa��o orientada a objetos')
				  ,(2, 1, 'Ciclo de Vida', 0, '08/04/2021', 'Como utilizar os ciclos de vida com a biblioteca ReactJs')
				  ,(3, 1, 'Introdu��o a SQL', 1, '09/04/2021', 'Comandos b�sicos utilizando SQL Server');
GO

INSERT INTO presenca(idUsuario, idEvento, situacao)
VALUES				(2, 2, 'n�o confirmada')
				   ,(2, 3, 'confirmada')
				   ,(3, 1, 'confirmada');
GO