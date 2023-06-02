create database test;

use test;

create table empleados(
    empleado_id char(36) primary key,
    empleado_nombre varchar(50) not null,
    create_at datetime not null,
    modify_at datetime not null
);

create table clientes(
    cliente_id char(36) primary key,
    cliente_nombre varchar(50) not null,
    create_at datetime not null,
    modify_at datetime not null
);

create table productos(
    producto_id char(36) primary key,
    producto_nombre varchar(50) not null,
    producto_descripcion varchar(50) not null,
    create_at datetime not null,
    modify_at datetime not null
);

create table inventarios(
    inventario_id char(36) primary key,
    producto_id char(36) not null,
    inventario_stock int not null,
    create_at datetime not null,
    modify_at datetime not null,
    foreign key (producto_id) references productos(producto_id)
);

create table ventas(
    venta_id char(36) primary key,
    cliente_id char(36) not null,
    empleado_id char(36) not null,
    producto_id char(36) not null,
    cantidad int not null,
    create_at datetime not null,
    modify_at datetime not null,
    foreign key (cliente_id) references clientes(cliente_id),
    foreign key (producto_id) references productos(producto_id),
    foreign key (empleado_id) references empleados(empleado_id)

);

#insert ventas
insert into ventas(venta_id, cliente_id, empleado_id, producto_id, cantidad, create_at, modify_at)
values (uuid(),'32677415-015e-11ee-833c-0242ac110002','326284b2-015e-11ee-833c-0242ac110002','325d62ec-015e-11ee-833c-0242ac110002',5,now(),now());

#Insert Productos
insert into productos(producto_id, producto_nombre, producto_descripcion, create_at, modify_at)
VALUES ( UUID(),'Producto 1','Este es el producto 1',now(),now()),
       ( UUID(),'Producto 2','Este es el producto 2',now(),now()),
       ( UUID(),'Producto 3','Este es el producto 3',now(),now()),
       ( UUID(),'Producto 4','Este es el producto 4',now(),now()),
       ( UUID(),'Producto 5','Este es el producto 5',now(),now()),
       ( UUID(),'Producto 6','Este es el producto 6',now(),now());

#Insert empleados
insert into empleados(empleado_id, empleado_nombre, create_at, modify_at)
values(uuid(),'Empleado 1',now(),now()),
      (uuid(),'Empleado 2',now(),now()),
      (uuid(),'Empleado 3',now(),now());

#Insert clientes
insert into clientes(cliente_id, cliente_nombre, create_at, modify_at)
values (uuid(),'Cliente 1',now(),now()),
       (uuid(),'Cliente 2',now(),now()),
       (uuid(),'Cliente 3',now(),now());

#insert Inventario
insert into inventarios(inventario_id, producto_id, inventario_stock, create_at, modify_at)
values (uuid(), '325d659b-015e-11ee-833c-0242ac110002',20,now(), now());

#2-
select e.*,c.*,p.*, vn.cantidad as "cantidad vendida"
from ventas as vn
join empleados e on e.empleado_id = vn.empleado_id
join clientes c on c.cliente_id = vn.cliente_id
join productos p on p.producto_id = vn.producto_id;


#Extra queries
insert into ventas(venta_id, cliente_id, empleado_id, producto_id, cantidad, create_at, modify_at) values (@venta_id, @cliente_id, @empleado_id, @producto_id, @cantidad, @create_at, @modify_at);
delete from productos where producto_id= @producto_id;
select * from productos where producto_id =@producto_id;
select * from productos;
insert into productos(producto_id, producto_nombre, producto_descripcion, create_at, modify_at) VALUES ( @producto_id, @producto_nombre, @producto_descripcion, @create_at, @modify_at);
update productos set @producto where producto_id = producto_id;

select p.*,i.*
from ventas as vn
join productos p on p.producto_id = vn.producto_id
join inventarios i on p.producto_id = i.producto_id;
