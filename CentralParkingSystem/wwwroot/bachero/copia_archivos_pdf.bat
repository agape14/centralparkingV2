@echo off
set origen=C:\Users\Agape\Documents\GitHub\centralparkingV2\CentralParkingSystem\wwwroot\docs
set destino=C:\Users\Agape\Documents\GitHub\centralparkingV2\Cms\wwwroot\docs

:: Verifica si la carpeta de destino existe, si no, créala
if not exist "%destino%" mkdir "%destino%"

:: Copia solo las imágenes que no existen en la ruta de destino
xcopy "%origen%\*.pdf" "%destino%\" /C /Y /Q
