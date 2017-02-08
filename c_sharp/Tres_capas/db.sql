create database TutorialCShar;
use TutorialCShar;

create table tblPersona(
    cedula varchar(20) not null,
    nombre varchar(50) not null,
    apellido varchar(50) not null,
    edad varchar(3) not null,
    fechaNacimiento date not null,
    constraint pk_persona primary key(cedula)
)
go

/* Procedimiento para select y delete */
create procedure spPersonaSE
(
@operacion varchar(1),
@cedula varchar(20)
)as
if @operacion = 'S'
select * from tblPersona where cedula=@cedula
else
if @operacion = 'E'
delete from tblPersona where cedula=@cedula
else
select * from tblPersona

/* Procedimiento para insert y update */
create procedure spPersonaIA
(
@operacion varchar(1),
@cedula varchar(20),
@nombre varchar(50),
@apellido varchar(50),
@edad varchar(3),
@fechaNacimiento date
)
as
if @operacion = 'I'
insert into tblPersona values(@cedula, @nombre, @apellido, @edad, @fechaNacimiento)
else
if @operacion = 'A'
update tblPersona set nombre=@nombre, apellido=@apellido, edad=@edad, fechaNacimiento=@fechaNacimiento where cedula=@cedula
