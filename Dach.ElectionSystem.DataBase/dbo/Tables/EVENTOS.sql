﻿CREATE TABLE [dbo].[EVENTOS] (
  [EVT_ID ] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
  [EVT_NOMBRE] VARCHAR(50) NULL,
  [EVT_FOTO] VARCHAR(50) NULL,
  [EVT_DESCRIPCION] VARCHAR(50) NULL,
  [EVT_MAX_PERSONAS] BIT NULL,
  [EVT_NUM_MAX_PERSONAS] INT NULL,
  [EVT_NUM_MAX_CANDIDATOS] INT NULL,
  [EVT_CATEGORIA] VARCHAR(50) NULL,
  [EVT_ID_USUARIO_CREADOR] INT NULL,
  [EVT_ESTADO] BIT NULL,
  [EVT_BORRADO] BIT NULL
)