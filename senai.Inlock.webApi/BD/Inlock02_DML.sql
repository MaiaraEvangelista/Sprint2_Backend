--DM-L
USE Inlock;
GO

--Inser��o nas tabelas criadas
INSERT INTO Estudio(nomeEstudio)
VALUES			   ('Blizzard')
				  ,('Rockstar Studios')
				  ,('Square Enix');
GO

INSERT INTO TiposUsuario(Titulo)
VALUES			        ('Administrador')
					   ,('Cliente');
GO


INSERT INTO Usuario(email, senha, idTipoUsuario)
VALUES			   ('admin@admin.com', 'admin', 1)
				  ,('cliente@cliente', 'cliente', 2);
GO


INSERT INTO Jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			 ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '2012-05-15','99.00',1)
				,('Red Dead Redemption II','jogo eletr�nico de a��o-aventura western','2018-10-26','120.00',2);
GO