CREATE TABLE [Persona] (
  [persona_id] int PRIMARY KEY IDENTITY(1, 1),
  [nombre] nvarchar(255),
  [primer_apellido] nvarchar(255),
  [segundo_apellido] nvarchar(255),
  [cedula] nvarchar(255),
  [pasaporte] nvarchar(255),
  [sexo] nvarchar(255),
  [fecha_nacimiento] date,
  [hora_nacimiento] nvarchar(255),
  [lugar_nacimiento] int,
  [nacionalidad] id,
  [estado_civil] nvarchar(255),
  [profesion_id] int,
  [religion_id] int,
  [direccion_id] int
)
GO

CREATE TABLE [Matrimonios] (
  [matrimonio_id] int PRIMARY KEY IDENTITY(1, 1),
  [sacramento_id] int UNIQUE,
  [novia_id] int,
  [novio_id] int,
  [testigo1_id] int,
  [testigo2_id] int,
  [padre_novio_id] int,
  [padre_novia_id] int,
  [madre_novio_id] int,
  [madre_novia_id] int,
  [bautismo_id] int,
  [confirmacion_id] int
)
GO

CREATE TABLE [Defunciones] (
  [defuncion_id] int PRIMARY KEY IDENTITY(1, 1),
  [sacramento_id] int UNIQUE,
  [fecha_fallecimiento] datetime,
  [causa_muerte] nvarchar(255),
  [persona_id] int,
  [edad] int,
  [sacramentos] boolean
)
GO

CREATE TABLE [Sacramento] (
  [sacramento_id] int PRIMARY KEY IDENTITY(1, 1),
  [fecha] datetime,
  [sacerdote_id] int,
  [registro_id] int
)
GO

CREATE TABLE [Bautismos] (
  [bautismo_id] int PRIMARY KEY IDENTITY(1, 1),
  [sacramento_id] int UNIQUE,
  [bautizando_id] int,
  [padre_id] int,
  [madre_id] int,
  [tipo_union_padres] enum,
  [fecha_matrimonio_padres] date,
  [registro_id_matrimonial] int,
  [abuelo_materno_id] int,
  [abuela_materna_id] int,
  [abuelo_paterno_id] int,
  [abuela_paterna_id] int,
  [padrino_id] int,
  [madrina_id] int,
  [declarante_id] int
)
GO

CREATE TABLE [Confirmaciones] (
  [confirmacion_id] int PRIMARY KEY IDENTITY(1, 1),
  [sacramento_id] int UNIQUE,
  [confirmando_id] int,
  [padre_id] int,
  [madre_id] int,
  [testigo_id] int,
  [parroquia_origen_id] int
)
GO

CREATE TABLE [Primeras_comuniones] (
  [primera_comunion_id] int PRIMARY KEY IDENTITY(1, 1),
  [sacramento_id] int UNIQUE,
  [catecumeno_id] int,
  [padre_id] int,
  [madre_id] int,
  [testigo_id] int,
  [parroquia_origen_id] int
)
GO

CREATE TABLE [Sacerdotes] (
  [sacerdote_id] int PRIMARY KEY IDENTITY(1, 1),
  [persona_id] int
)
GO

CREATE TABLE [Parroquias] (
  [parroquia_id] int PRIMARY KEY IDENTITY(1, 1),
  [nombre] int,
  [direccion_id] int
)
GO

CREATE TABLE [RegistroLibro] (
  [registro_id] int PRIMARY KEY IDENTITY(1, 1),
  [libro_id] int,
  [folio] int,
  [asiento] int
)
GO

CREATE TABLE [Libro] (
  [libro_id] int PRIMARY KEY IDENTITY(1, 1),
  [parroquia_id] int,
  [tipo_sacramento] nvarchar(255) NOT NULL CHECK ([tipo_sacramento] IN ('Bautismo', 'Confirmacion', 'Primera_Comunion', 'Matrimonio', 'Defuncion'))
)
GO

CREATE TABLE [Certificacion] (
  [certificacion_id] int PRIMARY KEY IDENTITY(1, 1),
  [sacramento_id] int,
  [fecha_emision] date,
  [emitida] boolean,
  [observaciones] text
)
GO

CREATE TABLE [Pais] (
  [pais_id] int PRIMARY KEY IDENTITY(1, 1),
  [nombre] nvarchar(255),
  [codigo_iso] nvarchar(255)
)
GO

CREATE TABLE [DivisionTerritorial] (
  [division_id] int PRIMARY KEY IDENTITY(1, 1),
  [pais_id] int,
  [nombre] nvarchar(255),
  [tipo] nvarchar(255),
  [padre_id] int
)
GO

CREATE TABLE [Direccion] (
  [direccion_id] int PRIMARY KEY IDENTITY(1, 1),
  [division_id] int,
  [otras_senas] text
)
GO

CREATE TABLE [Religion] (
  [religion_id] int PRIMARY KEY IDENTITY(1, 1),
  [nombre] nvarchar(255)
)
GO

CREATE TABLE [Profesion] (
  [Profesion_id] int PRIMARY KEY IDENTITY(1, 1),
  [nombre] nvarchar(255)
)
GO

CREATE TABLE [nacionalidad] (
  [nacionalidad_id] int PRIMARY KEY IDENTITY(1, 1),
  [nombre] nvarchar(255)
)
GO

ALTER TABLE [Persona] ADD FOREIGN KEY ([religion_id]) REFERENCES [Religion] ([religion_id])
GO

ALTER TABLE [Persona] ADD FOREIGN KEY ([nacionalidad]) REFERENCES [nacionalidad] ([nacionalidad_id])
GO

ALTER TABLE [Persona] ADD FOREIGN KEY ([profesion_id]) REFERENCES [Profesion] ([Profesion_id])
GO

ALTER TABLE [Persona] ADD FOREIGN KEY ([direccion_id]) REFERENCES [Direccion] ([direccion_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([sacramento_id]) REFERENCES [Sacramento] ([sacramento_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([novio_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([novia_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([padre_novio_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([madre_novio_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([padre_novia_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([madre_novia_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([testigo1_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Matrimonios] ADD FOREIGN KEY ([testigo2_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Defunciones] ADD FOREIGN KEY ([sacramento_id]) REFERENCES [Sacramento] ([sacramento_id])
GO

ALTER TABLE [Defunciones] ADD FOREIGN KEY ([persona_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Sacramento] ADD FOREIGN KEY ([registro_id]) REFERENCES [RegistroLibro] ([registro_id])
GO

ALTER TABLE [Sacramento] ADD FOREIGN KEY ([sacerdote_id]) REFERENCES [Sacerdotes] ([sacerdote_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([sacramento_id]) REFERENCES [Sacramento] ([sacramento_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([bautizando_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([padre_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([madre_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([abuelo_paterno_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([abuela_paterna_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([abuelo_materno_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([abuela_materna_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([padrino_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([madrina_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Bautismos] ADD FOREIGN KEY ([declarante_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Confirmaciones] ADD FOREIGN KEY ([sacramento_id]) REFERENCES [Sacramento] ([sacramento_id])
GO

ALTER TABLE [Confirmaciones] ADD FOREIGN KEY ([confirmando_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Confirmaciones] ADD FOREIGN KEY ([padre_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Confirmaciones] ADD FOREIGN KEY ([madre_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Confirmaciones] ADD FOREIGN KEY ([testigo_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Primeras_comuniones] ADD FOREIGN KEY ([sacramento_id]) REFERENCES [Sacramento] ([sacramento_id])
GO

ALTER TABLE [Primeras_comuniones] ADD FOREIGN KEY ([catecumeno_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Primeras_comuniones] ADD FOREIGN KEY ([padre_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Primeras_comuniones] ADD FOREIGN KEY ([madre_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Primeras_comuniones] ADD FOREIGN KEY ([testigo_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Sacerdotes] ADD FOREIGN KEY ([persona_id]) REFERENCES [Persona] ([persona_id])
GO

ALTER TABLE [Parroquias] ADD FOREIGN KEY ([direccion_id]) REFERENCES [Direccion] ([direccion_id])
GO

ALTER TABLE [RegistroLibro] ADD FOREIGN KEY ([libro_id]) REFERENCES [Libro] ([libro_id])
GO

ALTER TABLE [Libro] ADD FOREIGN KEY ([parroquia_id]) REFERENCES [Parroquias] ([parroquia_id])
GO

ALTER TABLE [Certificacion] ADD FOREIGN KEY ([sacramento_id]) REFERENCES [Sacramento] ([sacramento_id])
GO

ALTER TABLE [DivisionTerritorial] ADD FOREIGN KEY ([pais_id]) REFERENCES [Pais] ([pais_id])
GO

ALTER TABLE [DivisionTerritorial] ADD FOREIGN KEY ([padre_id]) REFERENCES [DivisionTerritorial] ([division_id])
GO

ALTER TABLE [Direccion] ADD FOREIGN KEY ([division_id]) REFERENCES [DivisionTerritorial] ([division_id])
GO
