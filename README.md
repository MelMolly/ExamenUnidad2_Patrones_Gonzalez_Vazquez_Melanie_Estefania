# Gonzalez Vazquez Melanie Estefania

Proyecto: # Mensajería Instántanea en red local

Este proyecto esta en base a 2 patrones de diseño, Object Pool y Singleton. Es simulado como un servicio de mendsajeria con mensajes predeterminados, prácticanente un chat bot, el usuario podrá interactuar con el prgrama mandandole mensajes y recibiendolos al instante.

En el Object Pool, es donde estan gestionado los mensajes, tiene un límite de mensajes para volver el programa más sencillo, sin saturarlo, ahí checará cuando el usuario mande un mensaje, iniciará un contador de la capacidad de mensajes que el ususario ingresará. En caso de de llegar al límite, el programa devolverá el mensaje a la piscina, se resetea para que no colapse y se pueda volver a usar.

En el Singleton creamos una única instancia que será utilizado para el servidor, en este patrón, se agregan a los destinarios al seervidor para empezar a mandarle mensaje al bot, se conecta e inicia el método para tomar en mensaje de pool y y simular el envio, en este caso son 2 destinario, podemos poner un destinario cualquiera que queramos mandarle mensaje y simulara el envio(no se vera ningun mensaje por parte del destinario, solo simulacion de que respondió), y del bot, donde si se recibirá mensajes aleatorios ya predeterminados.

Ya en el program se manda a llamar a la unica instancia para empezar con la estrutura de la mensajeria, se crea un ciclo donde cada que mande mensaje el usuario cuando se conecte, pueda volver a mandar mensaje, en caso de que no coloque bien al destinario, se mandará un mensaje donde diga que ponga bien al  destinario. Mandara a llamar al metodo de enviar mensaje del servidor para agregar al usuario, destinario y remitente

La manera de usar el programa es:

Ingresa tu nombre: tunombre
tunombre se ha conectado al servidor

Escribe mensaje (destinatario:mensaje) o 'salir':  milka:holaa
[10:58:01] tunombre → milka: holaa //simulacion de que le llego el mensaje, no hay respuesta pero se simula que si respondió

Escribe mensaje (destinatario:mensaje) o 'salir': bot:holaa
[11:00:53] tunombre → bot: holaa
[11:00:54] Bot → tunombre: holaa //Se recibe una prespuesta predeterminada aleatoria del bot

Escribe mensaje (destinatario:mensaje) o 'salir': salir
Saliendo del chat...
