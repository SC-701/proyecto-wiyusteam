CREATE DATABASE SIGSAC;
GO

USE SIGSAC;
GO

CREATE TABLE persona(
    id INT PRIMARY KEY IDENTITY(1,1),

    nombre VARCHAR(100) NOT NULL,
    primer_apellido VARCHAR(100) NOT NULL,
    segundo_apellido VARCHAR(100) NOT NULL,

    cedula VARCHAR(20) NOT NULL,
    pasaporte VARCHAR(20) NOT NULL,

    sexo VARCHAR(10) NOT NULL,

    fecha_nacimiento DATE NOT NULL,
    hora_nacimiento VARCHAR(10) NOT NULL,

    lugar_nacimiento VARCHAR(150) NOT NULL,
    nacionalidad VARCHAR(100) NOT NULL,

    estado_civil VARCHAR(50) NOT NULL,

    profesion VARCHAR(100) NOT NULL,
    religion VARCHAR(100) NOT NULL,

    direccion VARCHAR(200) NOT NULL
);

CREATE TABLE bautismo(
    id INT PRIMARY KEY IDENTITY(1,1),

    sacramento VARCHAR(200) NOT NULL,

    bautizando_id INT NOT NULL,
    padre_id INT NOT NULL,
    madre_id INT NOT NULL,

    tipo_union_padres VARCHAR(50) NOT NULL,
    fecha_matrimonio_padres DATE NOT NULL,

    abuelo_materno_id INT NOT NULL,
    abuela_materna_id INT NOT NULL,
    abuelo_paterno_id INT NOT NULL,
    abuela_paterna_id INT NOT NULL,

    padrino_id INT NOT NULL,
    madrina_id INT NOT NULL,
    declarante_id INT NOT NULL
);

ALTER TABLE bautismo ADD FOREIGN KEY (bautizando_id) REFERENCES persona(id);
ALTER TABLE bautismo ADD FOREIGN KEY (padre_id) REFERENCES persona(id);
ALTER TABLE bautismo ADD FOREIGN KEY (madre_id) REFERENCES persona(id);

ALTER TABLE bautismo ADD FOREIGN KEY (abuelo_materno_id) REFERENCES persona(id);
ALTER TABLE bautismo ADD FOREIGN KEY (abuela_materna_id) REFERENCES persona(id);

ALTER TABLE bautismo ADD FOREIGN KEY (abuelo_paterno_id) REFERENCES persona(id);
ALTER TABLE bautismo ADD FOREIGN KEY (abuela_paterna_id) REFERENCES persona(id);

ALTER TABLE bautismo ADD FOREIGN KEY (padrino_id) REFERENCES persona(id);
ALTER TABLE bautismo ADD FOREIGN KEY (madrina_id) REFERENCES persona(id);

ALTER TABLE bautismo ADD FOREIGN KEY (declarante_id) REFERENCES persona(id);

INSERT INTO persona
(nombre,primer_apellido,segundo_apellido,cedula,pasaporte,sexo,fecha_nacimiento,hora_nacimiento,lugar_nacimiento,nacionalidad,estado_civil,profesion,religion,direccion)
VALUES
('Juan','Perez','Lopez','101','P001','M','1990-05-10','10:30','San Jose','Costarricense','Soltero','Ingeniero','Catolica','San Jose'),
('Maria','Gonzalez','Rodriguez','102','P002','F','1992-07-12','08:20','Cartago','Costarricense','Casada','Profesora','Catolica','Cartago'),
('Carlos','Ramirez','Soto','103','P003','M','1988-03-15','14:10','Alajuela','Costarricense','Casado','Medico','Catolica','Alajuela'),
('Ana','Jimenez','Vargas','104','P004','F','1995-11-20','09:15','Heredia','Costarricense','Soltera','Abogada','Catolica','Heredia'),
('Luis','Castro','Mora','105','P005','M','1980-06-18','07:50','Puntarenas','Costarricense','Casado','Contador','Catolica','Puntarenas'),
('Laura','Rojas','Campos','106','P006','F','1998-01-02','11:45','Limon','Costarricense','Soltera','Estudiante','Catolica','Limon'),
('Pedro','Solano','Diaz','107','P007','M','1985-04-22','12:30','San Jose','Costarricense','Casado','Comerciante','Catolica','San Jose'),
('Sofia','Alvarado','Perez','108','P008','F','1993-09-09','16:00','Cartago','Costarricense','Soltera','Arquitecta','Catolica','Cartago'),
('Andres','Vega','Cruz','109','P009','M','1991-02-14','05:20','Alajuela','Costarricense','Soltero','Programador','Catolica','Alajuela'),
('Daniela','Mendez','Flores','110','P010','F','2000-12-01','18:40','Heredia','Costarricense','Soltera','Estudiante','Catolica','Heredia'),

('Mario','Soto','Perez','111','P011','M','1984-03-10','09:20','San Jose','Costarricense','Casado','Profesor','Catolica','San Jose'),
('Elena','Rojas','Lopez','112','P012','F','1986-06-12','10:10','Cartago','Costarricense','Casada','Enfermera','Catolica','Cartago'),
('Jose','Campos','Diaz','113','P013','M','1975-07-22','11:00','Alajuela','Costarricense','Casado','Abogado','Catolica','Alajuela'),
('Patricia','Lopez','Perez','114','P014','F','1978-08-30','13:20','Heredia','Costarricense','Casada','Contadora','Catolica','Heredia'),
('Roberto','Salas','Gomez','115','P015','M','1970-04-15','15:30','San Jose','Costarricense','Casado','Ingeniero','Catolica','San Jose'),
('Teresa','Gomez','Salas','116','P016','F','1972-01-25','07:45','Cartago','Costarricense','Casada','Profesora','Catolica','Cartago'),
('Ricardo','Flores','Mora','117','P017','M','1968-09-12','06:50','Alajuela','Costarricense','Casado','Comerciante','Catolica','Alajuela'),
('Adriana','Mora','Flores','118','P018','F','1969-12-11','08:10','Heredia','Costarricense','Casada','Ama de casa','Catolica','Heredia'),
('Fernando','Castro','Vega','119','P019','M','1977-02-17','17:10','San Jose','Costarricense','Casado','Arquitecto','Catolica','San Jose'),
('Gabriela','Vega','Castro','120','P020','F','1979-03-19','18:00','Cartago','Costarricense','Casada','Diseñadora','Catolica','Cartago'),

('Alberto','Navarro','Rojas','121','P021','M','1983-11-01','09:30','San Jose','Costarricense','Casado','Ingeniero','Catolica','San Jose'),
('Silvia','Rojas','Navarro','122','P022','F','1985-12-02','10:40','Cartago','Costarricense','Casada','Profesora','Catolica','Cartago'),
('Victor','Perez','Navarro','123','P023','M','1974-06-03','11:50','Alajuela','Costarricense','Casado','Medico','Catolica','Alajuela'),
('Claudia','Navarro','Perez','124','P024','F','1976-05-04','12:20','Heredia','Costarricense','Casada','Abogada','Catolica','Heredia'),
('Eduardo','Campos','Rojas','125','P025','M','1973-07-07','13:10','San Jose','Costarricense','Casado','Contador','Catolica','San Jose'),
('Monica','Rojas','Campos','126','P026','F','1975-08-08','14:30','Cartago','Costarricense','Casada','Profesora','Catolica','Cartago'),
('Oscar','Vargas','Lopez','127','P027','M','1981-09-09','15:40','Alajuela','Costarricense','Casado','Ingeniero','Catolica','Alajuela'),
('Lucia','Lopez','Vargas','128','P028','F','1982-10-10','16:50','Heredia','Costarricense','Casada','Administradora','Catolica','Heredia'),
('Diego','Rojas','Perez','129','P029','M','1994-11-11','17:30','San Jose','Costarricense','Soltero','Programador','Catolica','San Jose'),
('Natalia','Perez','Rojas','130','P030','F','1996-12-12','18:15','Cartago','Costarricense','Soltera','Diseñadora','Catolica','Cartago');

INSERT INTO bautismo
(sacramento,bautizando_id,padre_id,madre_id,tipo_union_padres,fecha_matrimonio_padres,
abuelo_materno_id,abuela_materna_id,abuelo_paterno_id,abuela_paterna_id,
padrino_id,madrina_id,declarante_id)
VALUES
('Bautismo',1,2,3,'Matrimonio','2010-05-05',4,5,6,7,8,9,10),

('Bautismo',11,12,13,'Matrimonio','2012-06-10',14,15,16,17,18,19,20),

('Bautismo',21,22,23,'Matrimonio','2015-03-20',24,25,26,27,28,29,30);
/* =============================================
   PERSONA
============================================= */

CREATE PROCEDURE AgregarPersona
    @Nombre VARCHAR(100),
    @PrimerApellido VARCHAR(100),
    @SegundoApellido VARCHAR(100),
    @Cedula VARCHAR(20),
    @Pasaporte VARCHAR(20),
    @Sexo VARCHAR(10),
    @FechaNacimiento DATE,
    @HoraNacimiento VARCHAR(10),
    @LugarNacimiento VARCHAR(150),
    @Nacionalidad VARCHAR(100),
    @EstadoCivil VARCHAR(50),
    @Profesion VARCHAR(100),
    @Religion VARCHAR(100),
    @Direccion VARCHAR(200)

AS
BEGIN

SET NOCOUNT ON;

BEGIN TRANSACTION

INSERT INTO Persona
(
Nombre,primer_apellido,segundo_apellido,
cedula,pasaporte,sexo,
fecha_nacimiento,hora_nacimiento,
lugar_nacimiento,nacionalidad,
estado_civil,profesion,religion,direccion
)
VALUES
(
@Nombre,@PrimerApellido,@SegundoApellido,
@Cedula,@Pasaporte,@Sexo,
@FechaNacimiento,@HoraNacimiento,
@LugarNacimiento,@Nacionalidad,
@EstadoCivil,@Profesion,@Religion,@Direccion
)

SELECT SCOPE_IDENTITY()

COMMIT TRANSACTION

END
GO


CREATE PROCEDURE EditarPersona

@Id INT,
@Nombre VARCHAR(100),
@PrimerApellido VARCHAR(100),
@SegundoApellido VARCHAR(100),
@Cedula VARCHAR(20),
@Pasaporte VARCHAR(20),
@Sexo VARCHAR(10),
@FechaNacimiento DATE,
@HoraNacimiento VARCHAR(10),
@LugarNacimiento VARCHAR(150),
@Nacionalidad VARCHAR(100),
@EstadoCivil VARCHAR(50),
@Profesion VARCHAR(100),
@Religion VARCHAR(100),
@Direccion VARCHAR(200)

AS
BEGIN

SET NOCOUNT ON;

BEGIN TRANSACTION

UPDATE Persona
SET
nombre=@Nombre,
primer_apellido=@PrimerApellido,
segundo_apellido=@SegundoApellido,
cedula=@Cedula,
pasaporte=@Pasaporte,
sexo=@Sexo,
fecha_nacimiento=@FechaNacimiento,
hora_nacimiento=@HoraNacimiento,
lugar_nacimiento=@LugarNacimiento,
nacionalidad=@Nacionalidad,
estado_civil=@EstadoCivil,
profesion=@Profesion,
religion=@Religion,
direccion=@Direccion

WHERE id=@Id

SELECT @Id

COMMIT TRANSACTION

END
GO


CREATE PROCEDURE EliminarPersona

@Id INT

AS
BEGIN

SET NOCOUNT ON;

DELETE
FROM Persona
WHERE id=@Id

SELECT @Id

END
GO

CREATE PROCEDURE ObtenerPersona
@Id INT
AS
BEGIN
SET NOCOUNT ON;

SELECT
id,
nombre,
primer_apellido AS PrimerApellido,
segundo_apellido AS SegundoApellido,
cedula,
pasaporte,
sexo,
fecha_nacimiento AS FechaNacimiento,
hora_nacimiento AS HoraNacimiento,
lugar_nacimiento AS LugarNacimiento,
nacionalidad,
estado_civil AS EstadoCivil,
profesion,
religion,
direccion
FROM persona
WHERE id = @Id

END
GO


CREATE PROCEDURE ObtenerPersonas
AS
BEGIN
SET NOCOUNT ON;

SELECT
id,
nombre,
primer_apellido AS PrimerApellido,
segundo_apellido AS SegundoApellido,
cedula,
pasaporte,
sexo,
fecha_nacimiento AS FechaNacimiento,
hora_nacimiento AS HoraNacimiento,
lugar_nacimiento AS LugarNacimiento,
nacionalidad,
estado_civil AS EstadoCivil,
profesion,
religion,
direccion
FROM persona

END
GO


/* =============================================
   BAUTISMO
============================================= */
