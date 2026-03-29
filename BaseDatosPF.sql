use master;
if exists (select * from sys.databases where name = 'BasePF')
begin
    drop database BasePF;
end;
create database BasePF;
go
use BasePF;


create table Clientes 
(
  Cedula int primary key check(cedula between 10000000 and 99999999),
  NombreCompleto varchar(30) not null,
  Telefono int check(telefono between 10000000 and 99999999) not null,
  NumeroDeTarjeta bigint check(numerodetarjeta between 1000000000000000 and 9999999999999999) not null,
)

create table categoria
(
  Codigo varchar(6) primary key check(Codigo LIKE '[A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9]'),
  Nombre varchar(50)not null

)

create table Articulos
(
  Codigo varchar(10) primary key check(len(codigo) = 10),
  Nombre varchar(50) not null, 
  Precio int not null check (precio > 0),
  tipo varchar(20) not null check (tipo in('Unidad', 'Blister', 'Sobre', 'Frasco')), 
  tamaño int not null check (tamaño > 0),
  CodigoCategoria varchar(6) not null foreign key references categoria(Codigo) 
)

create table Empleado
(
  UsuarioLogeo varchar(50) primary key,
  contraseña varchar(50) not null check(len(contraseña) > 0),
  Nombre varchar(20) not null
)

create table Ventas
(
  NumeroDeVenta int identity primary key,
  fechaVenta dateTime default getdate(),
  Estado varchar(10) not null check (Estado in('armado', 'enviado', 'entregado', 'devuelto')) default ('armado'),
  Direccion varchar(20) not null,
  cantidad int not null,
  CedulaCliente int  not null foreign key references Clientes(cedula), 
  CodigoArticulo varchar(10) not null foreign key references Articulos(Codigo) ,
  EmpleadoAsociado varchar(50) not null foreign key references Empleado(UsuarioLogeo) 
)


insert into Clientes(cedula, nombrecompleto, telefono, NumeroDeTarjeta) values
(12345678, 'juan perez', 099123456, 4234000012345678),
(57654321, 'maria lopez', 098654321, 4765000087654321),
(23456789, 'carlos garcia', 091234567, 4335000023456789),
(58765432, 'ana fernandez', 092345678, 4876000098765432),
(34567890, 'luis rodriguez', 095678901, 4456000034567890);


insert into categoria (codigo, nombre) values
('a001mu', 'analgesico'),
('b002gi', 'gotas '),
('c003to', 'dermatologicos'),
('d004vi', 'vitaminas y suplementos'),
('e005si', 'inmunologicos');


insert into articulos (codigo, nombre, precio, tipo, tamaño, codigocategoria) values
('angri10239', 'anti gripal diurno', 130, 'sobre', 45, 'a001mu'),
('gotof20045', 'gotas oculares ', 200, 'frasco', 10, 'b002gi'),
('derma10078', 'crema para quemaduras', 250, 'unidad', 1, 'c003to'),
('vitam30090', 'vitamina c', 180, 'blister', 30, 'd004vi'),
('inmun50060', 'suplemento', 220, 'unidad', 1, 'e005si');


insert into empleado (usuariologeo, contraseña, nombre) values
('emp001', 'pass1234', 'carlos torres'),
('emp002', 'pass5678', 'ana ramirez'),
('emp003', 'pass1555', 'diego sanchez'),
('emp004', 'pass4555', 'mariana perez'),
('emp005', 'pass3333', 'lucas fernandez');


insert into ventas (fechaventa, estado, direccion, cantidad, cedulacliente, codigoarticulo, empleadoasociado) values
('2026-3-2', 'armado', 'la herrera', 2, 12345678, 'angri10239', 'emp001'),
('2026-3-2', 'enviado', '18 de julio 33', 1, 57654321, 'gotof20045', 'emp002'),
('2026-3-2', 'entregado', 'Hidra 3325', 3, 23456789, 'derma10078', 'emp003'),
('2026-3-2', 'devuelto', 'ruta 11 km 5', 1, 58765432, 'vitam30090', 'emp004'),
('2026-3-2', 'armado', 'ruta 8 km 14', 5, 34567890, 'inmun50060', 'emp005');
go



create procedure BuscarCategoria
@codigo varchar(6)
as
begin 
	SELECT * 
	FROM categoria where Codigo = @codigo
end
go

create procedure AgregarCategoria
   @Codigo varchar(6),
  @Nombre varchar
as
begin

     if @Codigo not like '[A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9]' 
	 begin
	    print 'Codigo a de tener 6 Letras/numeros'
	 return -1
	 end

     if exists ( select 1 from categoria where Codigo = @Codigo or Nombre = @Nombre)
    begin  
          print'Categoria ya existente'
        return -2
    end

	insert into categoria (Codigo,Nombre)
    values (@Codigo , @Nombre)

end
go

create procedure ModificarCategoria
   @Codigo varchar(6),
  @Nombre varchar
as
begin

     if @Codigo not like '[A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9][A-Za-z0-9]'	 
	 begin
	    print 'Codigo a de tener 6 Letras/numeros'
	 return -1
	 end

	 if not exists (select 1 from categoria where Codigo = @Codigo)
    begin
        print 'La Categoria no existe'
        return -2
    end
	
	update categoria
    set 
        Nombre = @Nombre   
    where Codigo = @Codigo

    print 'Categoria actualizada correctamente'
    return 0
end
go

create procedure EliminarCategoria
    @Codigo varchar(6)
as
begin
    if not exists (select 1 from categoria where Codigo = @Codigo)
    begin
        print 'La Categoria no existe'
        return -1
    end

    if exists (select 1 from Articulos where CodigoCategoria= @Codigo)
    begin
        print 'La Categoria tiene articulos asociados y no puede eliminarse';
        return -2
    end

    delete from categoria where Codigo = @Codigo;
    print 'Categoria eliminada correctamente';
end
go


create procedure BuscarArticulos
@codigo varchar(10)
as
begin 
	SELECT * 
	FROM Articulos where Codigo = @codigo
end
go

create procedure EliminarArticulos
@codigo varchar(10)
as
begin 
	
	if NOT EXISTS (select Codigo from Articulos where Codigo = @codigo)
		return -1

	if EXISTS (select CodigoArticulo from Ventas where CodigoArticulo = @codigo)
		return -2

	begin tran
	
	delete Ventas	where CodigoArticulo = @codigo 
	
	delete Articulos where Codigo = @codigo
	
	if(@@ERROR = 0)
	begin
		commit tran
		return 1
	end	
	else
	begin
		rollback tran
		return -3
	end	
end
go

create Procedure AltaArticulos
@Codigo varchar(10), @nombre varchar(50), @precio int, @tipo varchar(20), @tamaño int, @codigoCat varchar(6)
as
Begin	

	

	IF exists(select * from Articulos where Codigo = @Codigo)
	begin
		return -1
	end

	Begin Tran

	insert into Articulos(codigo, nombre, precio, tipo, tamaño, codigocategoria)
	values(@Codigo, @nombre, @precio, @tipo, @tamaño, @codigoCat)
	if (@@ERROR != 0)
	begin
		rollback tran
		return -2
	end
		
	Commit Tran
	return 1
End
Go

create procedure ModificarArticulos
@codigo varchar(10),
@nombre varchar(50),
@precio int
as
begin 
	if NOT EXISTS (select Codigo from Articulos where Codigo = @codigo)
		return -1
	
	begin tran

	update Articulos set Nombre = @nombre, precio = @precio
	where Codigo = @codigo

	if(@@ERROR = 0)
	begin
		commit tran
		return 1
	end
	
	else
	begin
		rollback tran
		return -2
	end	
end
go

create Procedure AltaVentas 
@fechaVenta datetime, @estado varchar(10), @direccion varchar(20), @cantidad int, @cedulacliente int, @codigoarticulo varchar(10), @empleadoasociado varchar(50)
as
Begin
		
		if not exists(select * from Ventas where CodigoArticulo = @codigoarticulo)
	begin
		return -1
	end
		
	if not exists(select * from Ventas where CedulaCliente = @cedulacliente)
	begin
		return -2
	end

		if not exists(select * from Ventas where EmpleadoAsociado = @empleadoasociado)
	begin
		return -3
	end

	if exists(select * from Ventas where @fechaVenta = fechaVenta and @fechaVenta = getdate())
	begin
		return -4
	end

	insert into Ventas (fechaventa, estado, direccion, cantidad, cedulacliente, codigoarticulo, empleadoasociado)
	Values(@fechaVenta, @estado, @direccion, @cantidad, @cedulacliente, @codigoarticulo, @empleadoasociado)
	if (@@ERROR != 0)
	begin
		return -5
	end
	
		return ident_current('Ventas')

End
go


create procedure BuscarCliente
@cedula int
as
begin 
	SELECT * 
	FROM Clientes where Cedula = @cedula
end
go

create procedure AgregarCliente

  @Cedula int,
  @NombreCompleto varchar(30),
  @Telefono int,
  @NumeroDeTarjeta bigint
as
begin

  if exists(select * from Clientes where Cedula =  @cedula)
		return -1


	insert into Clientes(Cedula, NombreCompleto, Telefono, NumeroDeTarjeta)
	Values( @cedula, @nombrecompleto, @Telefono, @NumeroDeTarjeta)
	if (@@ERROR != 0)
	begin
		return 1
	end

	return -2
end
go

create procedure ModificarCaliente

  @Cedula int,
  @NombreCompleto varchar,
  @Telefono int,
  @NumeroDeTarjeta bigint
as
begin
	IF not exists(select * from Clientes where Cedula = @cedula)
		return -1

		update Clientes
	set Nombrecompleto = @NombreCompleto,
      Telefono = @Telefono, 
      NumeroDeTarjeta = @NumeroDeTarjeta
	where Cedula = @cedula 
	if (@@ERROR = 0)
		return 1
	else
		return -2
end
go

create procedure EliminarCliente
    @Cedula int
as
begin
    if not exists (select 1 from Clientes where Cedula = @Cedula)
    begin
        print 'El Cliente no existe'
        return -1
    end

    if exists (select 1 from Ventas where CedulaCliente = @Cedula)
    begin
        print 'El cliente tiene ventas asociados y no puede eliminarse';
        return -2
    end

    delete from Clientes where Cedula = @Cedula;
    print 'Cliente eliminada correctamente';
	return 0

end
go

create procedure desplegestadoactual
@codigoventa varchar(10)
as
begin
    declare @estado varchar(10);

    select @estado = estado
    from ventas
    where numerodeventa = @codigoventa;
   
    if @estado is null
    begin
        print 'No se encontró el estado para este número de venta';
        return -1;
    end
    else if @estado = 'Armado'
        return 1;
    else if @estado = 'Enviado'
        return 2;
    else if @estado = 'Entregado'
        return 3;
    else if @estado = 'Devuelto'
        return 4;
    else 
        return -1; 
end;
go


create procedure Seguimientodeventa
@numerodeventa int
as 
begin
    declare @estadoActual varchar(10)

    select @estadoActual = estado from Ventas where NumeroDeVenta = @numerodeventa

    if @estadoActual is null
        return -1

    declare @nuevoEstado varchar(10)

    if @estadoActual = 'armado'
        set @nuevoEstado = 'enviado'
    else if @estadoActual = 'enviado'
        set @nuevoEstado = 'entregado'
    else if @estadoActual = 'entregado'
        set @nuevoEstado = 'devuelto'
    else
        return -3

    begin tran

    update Ventas 
    set Estado = @nuevoEstado
    where NumeroDeVenta = @numerodeventa

    if @@ERROR = 0
    begin
        commit tran
        return 1 
    end
    else
    begin
        rollback tran
        return -2
    end
 
end
go


create procedure ListarClientes
as
begin
	SELECT * 
	FROM Clientes
end
go

create procedure ListarArticulos
AS
Begin
	SELECT * 
	FROM Articulos
End
go

create procedure ListarCategorias
AS
Begin
	SELECT * 
	FROM categoria
End
go

create Procedure LogueoEmpleado
@Usu varchar(50),
@Pass varchar(50),
@nombre varchar(50)
AS
Begin
	Select *
	From Empleado where Empleado.UsuarioLogeo = @Usu and Empleado.contraseña = @pass and Empleado.Nombre = @nombre
End
go

create procedure ObtenerArticulosPorCategoria
    @CodigoCategoria varchar(50)
as
begin
    select 
        Codigo,
        Nombre,
        Precio,
        tipo,
        tamaño,
        CodigoCategoria
    from 
        Articulos
    where 
        CodigoCategoria = @CodigoCategoria;
End;
go
create procedure ObtenerVentasPorArticulos
    @CodigoArticulo varchar(50)
as
begin
    select * from Ventas
    where 
        CodigoArticulo = @CodigoArticulo;
End;
go

create procedure ObtenerEmpleado
    @UsuarioLogeo varchar(50)
as
begin
    select * from Empleado	
    where 
        UsuarioLogeo = @UsuarioLogeo;
End;
go
create procedure ObtenerCliente
    @Cedula varchar(50)
as
begin
    select * from Clientes	
    where 
        Cedula = @Cedula;
End;

go

create procedure ObtenerArticulo
    @Codigo varchar(50)
as
begin
    select * from Articulos	
    where 
        Codigo = @Codigo;
End;
go
create procedure ObtenerVentaCliente
    @Cedula varchar(50)
as
begin
    select * from Ventas
    where 
        CedulaCliente = @Cedula;
End;
go

create procedure ObtenerAriculoCodigo
    @Codigo varchar(50)
as
begin
    select * from Articulos
    where 
       Codigo = @Codigo;
End;
go
create procedure ObtenerVentaArmadoEnviado
    
as
begin
    select * from Ventas
    where 
        Estado = 'Armado' or Estado= 'Enviado'
End;
go


