# TP-GSC
Trabajo practico final del curso dictado por el Grupo San Cristobal y la UTN

## Descripcion del proyecto

La idea es desarrollar un sistema de préstamos de objetos (de aquí en adelante, les diremos
cosas ya que “objeto” se puede confundir con la palabra reservada object).
A quien no le sucedió que le prestó algo a un amigo o amiga y más tarde se olvido a quien se lo
prestó y cuando. La idea de este sistema es ayudarnos a recordar a quien y cuando se lo
prestamos.

## Requisitos

El sistema va a contar con 4 entidades. Categorías, Cosas, Personas y Préstamos (relación
entre cosas y personas).
Para el final del curso, como mínimo, cada alumno deberá entregar:
- Alta de Categorías por defecto en una aplicación de consola (o WebAPI). La aplicación
solo debe agregar las categorías en caso de que las mismas no existan.
- ABM de Personas con Web API
- ABM de Cosas con Web API
- Marcar el préstamo como devuelto con una llamada de gRPC.
- Proyecto de UnitTests que pruebe un controller (proyecto de WebAPI).
- Del lado del frontend (Angular), armar una página de Login, que me permita acceder al
sistema (Llamando a las APIs de Autenticacion). Una vez ingresado vamos a poder
acceder a un ABM de personas la cual debe estar segurizada usando JWT.
Requisitos Tecnicos

## Modelo de dominio
![image](https://github.com/Matiaja/TP-GSC/assets/102177224/d81780f6-dbe3-4101-9579-9d4b30db38fa)

## Requisitos tecnicos

- App en NetCore 7 u 8
- Uso de EntityFramework Core en toda la solución
- La solución debe ser entregada en Github y compartida con el del profesor.
Opcional
- Implementar Logging en archivos
- Implementar Automapper


## Aclaracion del proyecto
Para el uso del login en frontend, el usuario es Admin y la clave es 1234

## Experiencia personal durante el curso
La verdad que el curso me parecio muy útil, aprendi muchisimas tecnologias que no conocía y reforcé conocimientos previos, realmente fue una experiencia maravillosa y eso es en gran parte a los profes que nos dieron la capacitacion, compartiendo sus experiencias y sus conocimientos, y estuvieron siempre a disposición para nosotros, asi que estoy muy agradecido tanto con Walter, como Beto por las clases de Backend y Luciano por las clases de Frontend, realmente un curso muy recomendable y muy interesante.
