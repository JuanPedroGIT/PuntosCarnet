# API REST PUNTOS CARNET

Para la gestión de las infracciones de los conductores y los puntos del carnet
Está construida con .NET Core 3.1

## Arrancar API

Desde Visual Studio Arrancar la Aplicacion
Desde Visual Studio Code dentro de /API ejecutar el comando "dotnet run"

## Probar Aplicacion

En el archivo Adjunto PUNTOS CARNET.postman_collection.json estan los end Points listos para probarlos con Postman.

## Base de Datos

Se utiliza SqLite para probar, la base de datos está construida y con datos. (puntoscarnet.db)

en la ruta /Data/Migrations se encuentran los script de la migracion para la construccion de la base de datos

En /sql están los scripts que he utilizado para llenar la base de datos