Para realizar la correcta configuración de la base de datos se deben seguir los siguientes pasos

1 - Conectarse con SQLDEVELOPER a System

2 - Crear usuarios importantes para la implementación
	2.1 - Ejecutar el script del archivo 2.Crear_Usuarios.sql

3 - Realizar el import de la Base de Datos para el usuario SAFE
	3.1 - Copiar el archivo BD_SAFE.DMP en la unidad de disco duro local (C:) desde la carpeta de instalación.
	3.2 - Copiar el archivo import_SAFE.BAT en la unidad de disco duro local (C:) desde la carpeta de instalación.
	3.3 - Ejecutar el archivo import_SAFE.BAT localizado en la carpeta (C:)

4 - Crear sinonimos para los objetos de la Base de Datos
	4.1 - Ejecutar el script del archivo 4.Crear_Sinonimos.sql