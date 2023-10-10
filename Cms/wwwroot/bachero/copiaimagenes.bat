@echo off
set origen=C:\Users\Agape\Documents\GitHub\centralparkingV2\Cms\wwwroot\images
set destino=C:\Users\Agape\Documents\GitHub\centralparkingV2\CentralParkingSystem\wwwroot\images

:: Verifica si la carpeta de destino existe, si no, créala
if not exist "%destino%" mkdir "%destino%"

:: Copia solo las imágenes que no existen en la ruta de destino
xcopy "%origen%\*.jpg" "%destino%\" /C /Y /Q
xcopy "%origen%\*.jpeg" "%destino%\" /C /Y /Q
xcopy "%origen%\*.png" "%destino%\" /C /Y /Q
xcopy "%origen%\*.gif" "%destino%\" /C /Y /Q
