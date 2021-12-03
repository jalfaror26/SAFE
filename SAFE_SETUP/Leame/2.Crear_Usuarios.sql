// Conectado con System

alter session set "_ORACLE_SCRIPT"=true;

create user SAFE identified by SAFE_UTN;

grant dba,connect to SAFE;

create role SAFE_USUARIOS;

create user ADMINISTRADOR identified by Admin123;

grant SAFE_USUARIOS to ADMINISTRADOR WITH ADMIN OPTION;

grant create session to ADMINISTRADOR;

grant dba to ADMINISTRADOR;

grant debug connect session to ADMINISTRADOR;
