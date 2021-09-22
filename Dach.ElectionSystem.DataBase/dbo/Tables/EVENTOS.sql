﻿CREATE TABLE [dbo].[EVENTOS] (
  [EVT_ID ] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
  [EVT_NOMBRE] VARCHAR(500) NULL,
  [EVT_FOTO] VARCHAR(200) NULL,
  [EVT_DESCRIPCION] VARCHAR(MAX) NULL,
  [EVT_MAX_PERSONAS] BIT NULL,
  [EVT_NUM_MAX_PERSONAS] INT NULL,
  [EVT_NUM_MAX_CANDIDATOS] INT NULL,
  [EVT_CATEGORIA] VARCHAR(50) NULL,
  [EVT_ID_USUARIO_CREADOR] INT NULL,
  [EVT_CODIGO_EVENTO] VARCHAR(30),
  [EVT_LIBRE_ACCESO] BIT NULL,
  [EVT_FECHA_REGISTRO] DATETIME NULL,
  [EVT_FECHA_MAX_REGISTRO_PARTICIPANTES] DATETIME NULL,
  [EVT_FECHA_MIN_VOTACION] DATETIME NULL,
  [EVT_FECHA_MAX_VOTACION] DATETIME NULL,
  [EVT_INICIADO] BIT NULL,
  [EVT_TERMINADO] BIT NULL,
  [EVT_ESTADO] BIT NULL,
  [EVT_BORRADO] BIT NULL
)