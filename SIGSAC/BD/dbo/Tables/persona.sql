CREATE TABLE [dbo].[persona] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [nombre]           VARCHAR (100) NOT NULL,
    [primer_apellido]  VARCHAR (100) NOT NULL,
    [segundo_apellido] VARCHAR (100) NOT NULL,
    [cedula]           VARCHAR (20)  NOT NULL,
    [pasaporte]        VARCHAR (20)  NOT NULL,
    [sexo]             VARCHAR (10)  NOT NULL,
    [fecha_nacimiento] DATE          NOT NULL,
    [hora_nacimiento]  VARCHAR (10)  NOT NULL,
    [lugar_nacimiento] VARCHAR (150) NOT NULL,
    [nacionalidad]     VARCHAR (100) NOT NULL,
    [estado_civil]     VARCHAR (50)  NOT NULL,
    [profesion]        VARCHAR (100) NOT NULL,
    [religion]         VARCHAR (100) NOT NULL,
    [direccion]        VARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

