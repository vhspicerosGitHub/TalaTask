# TalaTask


## Download
Bajar dede https://github.com/vhspicerosGitHub/TalaTask.git

```bash
git clone https://github.com/vhspicerosGitHub/TalaTask.git
```

## Ejecucion

Se ejecuta con docker, ya tiene el archivo docker-compose 😉

 ```bash
 cd .\TalaTask\
 docker-compose up

```

Luego para probar la api, se puede usar swagger 😎 abriendo http://localhost:8080/swagger/index.html

## Consideraciones tecnicas

Se utilizaron las siguientes librerias y conceptos

* **.Net8**: 
* Inyeccion de dependencias
* Modelo separados por capas
* Middleware para manejo de errores
* Patron repository (una implementacion en memoria)
* Swaggger - Para la documentacion de la API.
* Unit testing - pocos, pero hay algunos. Y se jecutan con github actions 😎
* Docker

 ## Logica / casos de uso / approach del problema

 se tiene dos entidades importantes empleados y tareas. los empleados tienen tiempo especifico para poder tomar tareas, tiempos con fecha hora de inicio y termino. Por otro lado las tareas tienen un una fechalimite y una cantidad de horas estimadas.

 ### Desarrollo/logica
 la asignacion de las tareas, tiene la siguiente logica
 * Busca los empleados que cumplan con las habilidades
 * Luego de ese universo, se busca tiempos disponibles donde se pueda realizar la tarea y que este antes del deadline.
 * Tercero y final, asigna la tarea, pero sigue dejando disponible el resto de tiempo. por ejemplo si tenemos una disponibilidad de 8 horas y tenemos que hacer una tarea de 3, nos queda un espacio de 5 horas para realizar otras tareas(como google calendar u cualquier otro calendario)

## Puntos de mejora en general
* En general la logica podria priorizarm primero asignar las tareas con mas habilidades requeridas, o tareas con mas duracion.
* No considera hacer split de las tareas.
* incluir muchos mas unit tests.
* Se incluyeron varios mantenedores, pero creo que faltan algunos.
* incluir seguridad.
* Base de datos, use en memoria ya que no considere que  fuera necesario.
* Se tienen algunos reportes bastantes funcionales, pero faltan muchos mas(con imaginacion),algunos ejemplos
  * reporte de empleados por fecha.
  * tareas sin asignar
  * empleados sin asignaciones
  * empleados sin espacio
  * etc, etc.

## Bonus

Se incluyo un endpoint para cargar datos de prueba,  este crea tres empleados y 4 tareas

 ```bash
curl -X 'POST' \
  'http://localhost:8080/CargaInicial' \
  -H 'accept: */*' \
  -d ''

```

y para asignar las tareas

 ```bash
curl -X 'POST' \
  'http://localhost:8080/Asignacion' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '[1,2,3,]'
```
