
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