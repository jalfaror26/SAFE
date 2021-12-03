@echo off
@echo Generando Backup del %1, %date% %time%"
				
cd C:\app\jalfa\product\18.0.0\dbhomeXE\bin
EXP userid=SAFE/SAFE_UTN FILE=D:\johnny\PROYECTOS\VS_2019\SAFE\PROYECTO\Leame\BD_SAFE.DMP FULL=N

@cd C:\Program Files
@"WinRAR\Rar.exe" a -tl -df -agDD-MMM-YYYY D:\johnny\PROYECTOS\BD's\SAFE\BD_SAFE_.rar D:\johnny\PROYECTOS\BD's\SAFE\BD_SAFE.DMP

@echo rem copy D:\johnny\PROYECTOS\BD's\SAFE\*.rar D:\johnny\PROYECTOS\VS 2019\SAFE\backupBD

@echo rem del D:\johnny\PROYECTOS\VS 2019\SAFE\backupBD\*.rar
