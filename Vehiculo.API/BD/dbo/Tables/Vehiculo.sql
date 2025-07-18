﻿CREATE TABLE [dbo].[Vehiculo] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [IdModelo]            UNIQUEIDENTIFIER NOT NULL,
    [Placa]               VARCHAR (MAX)    NOT NULL,
    [Color]               VARCHAR (MAX)    NOT NULL,
    [Anio]                INT              NOT NULL,
    [CorreoPropietario]   VARCHAR (MAX)    NOT NULL,
    [Precio]              VARCHAR (MAX)    NOT NULL,
    [TelefonoPropietario] VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vehiculo_Modelos] FOREIGN KEY ([IdModelo]) REFERENCES [dbo].[Modelos] ([Id])
);

