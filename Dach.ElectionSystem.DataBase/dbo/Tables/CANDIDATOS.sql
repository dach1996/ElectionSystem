﻿CREATE TABLE [dbo].[CANDIDATOS] (
  [ID_CANDIDATOS] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
  [IMAGEN_CANDIDATO] VARCHAR(50) NULL,
  [VIDEO_CANDIDATO] VARCHAR(50) NULL,
  [DETALLES_CANDIDATO] VARCHAR(50) NULL,
  [ROL_CANDIDATO] VARCHAR(50) NULL,
  [EDAD_CANDIDATO] INT NULL,
  [PROPUESTA_CANDIDATO] VARCHAR(50) NULL,
  [PUESTOS_LABORALES_CANDIDATO] VARCHAR(50) NULL,
  [ESTADO_CANDIDATO] BIT NULL,
)