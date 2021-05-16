DECLARE @Init int = 1

DELETE  FROM USUARIOS
DBCC CHECKIDENT (USUARIOS, RESEED, @Init)


DELETE  FROM CANDIDATOS
DBCC CHECKIDENT (CANDIDATOS, RESEED, @Init)


DELETE  FROM EVENTOS
DBCC CHECKIDENT (EVENTOS, RESEED, @Init)


DELETE  FROM ADMINISTRADOR_EVENTO
DBCC CHECKIDENT (ADMINISTRADOR_EVENTO, RESEED, @Init)


DELETE  FROM VOTOS
DBCC CHECKIDENT (VOTOS, RESEED, @Init)


DELETE  FROM EVENTOS_CANTIDAD
DBCC CHECKIDENT (EVENTOS_CANTIDAD, RESEED, @Init)


DELETE  FROM CANDIDATO_IMAGENES
DBCC CHECKIDENT (CANDIDATO_IMAGENES, RESEED, @Init)

DELETE  FROM VOTOS_REGISTRO_CORREO
DBCC CHECKIDENT (VOTOS_REGISTRO_CORREO, RESEED, @Init)



GO
--UsuarioPrueba

INSERT INTO USUARIOS VALUES('1716361411','Pruebas1','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas1@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas2','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas2@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas3','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas3@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas4','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas4@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas5','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas5@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas6','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas6@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas7','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas7@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas8','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas8@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas9','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas9@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas10','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','prueba101@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas11','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas11@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas12','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas12@gmail.com',1,0)
INSERT INTO USUARIOS VALUES('1716361411','Pruebas13','3960d343ea3ea3ed7fd2042e84201c5851ac79731251c6421ff1c8a01046fbc8',Null,'Pruebas','Pruebas','Pruebas','Pruebas','2021-03-24','pruebas13@gmail.com',1,0)

--Nuumero de Evenntos
INSERT INTO EVENTOS_CANTIDAD VALUES(1,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(2,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(3,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(4,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(5,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(6,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(7,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(8,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(9,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(10,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(11,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(12,5)
INSERT INTO EVENTOS_CANTIDAD VALUES(13,5)