
USE MedicalGroup;
GO

INSERT INTO tiposUsuarios(tipos)
VALUES					 ('Administrador')
						,('Colaboradores')
						,('Pacientes');
GO

INSERT INTO usuarios(idTiposUsuario, email, senha)
VALUES				(2, 'ricardo.lemos@spmedicalgroup.com.br', 'lemos123')
				   ,(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle123')
				   ,(2, 'helena.souza@spmedicalgroup.com.br', 'helena123')
				   ,(3, 'ligia@gmail.com', 'ligia123')
				   ,(3, 'alexandre@gmail.com', 'alexandre123')
				   ,(3, 'fernando@gmail.com', 'fernando123')
				   ,(3, 'henrique@gmail.com', 'henrique123')
				   ,(3, 'joao@hotmail.com',  'joao123')
				   ,(3, 'bruno@gmail.com', 'bruno123')
				   ,(3, 'mariana@outlook.com', 'mariana123');
GO

INSERT INTO pacientes(idUsuario, nomePaciente, RG, CPF, telefone, dataNascimento, endereco)
VALUES				 (4, 'Ligia Moreira  de Andrade', '43522543-5', '94839859000', '11 3456-7654', '13/10/1983', 'Rua Estado de Israel 240, S�o Paulo, Estado de S�o Paulo, 04022-000')
					,(5, 'Alexandre Souza', '32654345-7', '73556944057', '11 98765- 6543', '23/07/2001', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200')
					,(6, 'Fernando Lima Moraes', '54636525-3', '16839338002', '11 97208-4453', '10/10/1978', 'Av. Ibirapuera - Indian�polis, 2927, S�o Paulo - SP, 04029-200')
					,(7, 'Henrique Lima Guimar�es', '54366362-5', '14332654765', '11 3456-6543', '13/10/1985', 'R. Vit�ria, 120 - Vila S�o Jorge, Barueri - SP, 06402-030')
					,(8, 'Jo�o Augusto Soares', '53254444-1', '91305348010', '11 7656-6377', '27/08/1975', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380')
					,(9, 'Bruno da Silva', '54566266-7', '79799299004', '11 95436-8769', '21/03/1972', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001')
					,(10, 'Mariana Ribeiro Alves', '54566266-8', '13771913039', '', '05/03/2018', 'R. S�o Ant�nio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

INSERT INTO especialidades(tipos)
VALUES					  ('Acupuntura')
						 ,('Anestesiologia')
						 ,('Angiologia')
						 ,('Cardiologia')
						 ,('Cirurgia Cardiovascular')
						 ,('Cirurgia da M�o')
						 ,('Cirurgia do Aparelho Digestivo')
						 ,('Cirurgia Geral')
						 ,('Cirurgia Pedi�trica')
						 ,('Cirurgia  Pl�stica')
						 ,('Cirurgia Tor�xica')
						 ,('Cirurgia Vascular')
						 ,('Dermatologia')
						 ,('Radioterapia')
						 ,('Urologia')
						 ,('Pediatria')
						 ,('Psiquiatria');
GO

INSERT INTO situacoes(situacao)
VALUES				 ('Agendada')
					,('Realizada')
					,('Cancelada');
GO

INSERT INTO clinicas(razaoSocial, nomeFantasia, CNPJ, endereco, telefone, horarioAbertura, horarioFechamento)
VALUES				('SP Medical Group', 'Clinica Possarle', '86.400.902/0001-30', 'Av. Bar�o Limeira, 532, S�o Paulo, SP', '11  4367-8976', '08:00h', '23:00');
GO

INSERT INTO medicos(idUsuario, idEspecialidade, idClinica, nomeMedico, CRM)
VALUES			   (1, 2, 1, 'Ricardo Lemos', '54356-SP')
				  ,(2, 17, 1, 'Roberto Possarle', '53452-SP')
				  ,(3, 16, 1, 'Helena Souza', '65463-SP');
GO

INSERT INTO consultas(idPaciente, idMedico, idSituacao, horario, dataConsulta, descricao)
VALUES				 (7, 3, 2, '15:00', '20/01/2020', 'Atendimento realizado com sucesso')
					,(2, 2, 3, '10:00', '06/01/2020', 'Paciente n�o compareceu na consulta, n�o houve aviso de falta')
					,(3, 2, 2, '11:00', '07/02/2020', 'Atendimento realizado com sucesso, necessidades tratadas ')
					,(2, 2, 2, '10:00', '06/02/2018', 'Atendimento realizado com sucesso, todas as necessidades tratadas e observadas, sem prescri��o de retorno ')
					,(4, 1, 3, '11:00', '07/02/2019', 'Paciente n�o compareceu � consulta, sem avisos pr�vios de falta')
					,(7, 3, 1, '15:00', '08/03/2020', 'Consulta agendada')
					,(4, 1, 1, '11:00', '09/03/2020', 'Consulta agendada');
GO
