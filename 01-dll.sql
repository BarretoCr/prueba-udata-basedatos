CREATE DATABASE BDPRUEBA

USE BDPRUEBA 

CREATE TABLE seg_usuarios(
id INT NOT NULL,
correo varchar(150) NOT NULL,
nombre varchar(255) NOT NULL, 
estado smallint,
fecha_creacion datetime,
PRIMARY KEY(id)
)

CREATE TABLE seg_roles(
id INT NOT NULL,
nombre varchar(100) NOT NULL, 
estado smallint,
PRIMARY KEY(id)
)

CREATE TABLE seg_usuario_rol(
id INT NOT NULL,
usuario_id INT NOT NULL,
rol_id INT NOT NULL, 
CONSTRAINT fk_usuario FOREIGN KEY (usuario_id) REFERENCES seg_usuarios (id),
CONSTRAINT fk_rol FOREIGN KEY (rol_id) REFERENCES seg_roles (id),
);