# ArquiteturaDotNet
Trabalho final da disciplina Arquitetura Dot Net onde se explora o conceito do uso de WCF e WCF REST, API REST utilizando .netcore 2.1, além de filas utilizando o Microsoft Message Queuing (MSMQ) - implementando um produtor e um consumidor.

## Grupo
**_MATEUS SORIANO_** <br />
**_OTÁVIO AUGUSTO DE QUEIROZ REIS_**<br />
**_FREDERICO BITENCOURT_**


## Abaixo a descrição do trabalho prático enviado pelo professor.

O Trabalho consiste em fazer comunicação entre camadas no .NET

As portas de entradas são Web.Api e o Web Services. Os métodos recebem uma string como parâmetro e &quot;passa para as outras camadas&quot;.

Utilizando Httpclient ou RestSharp será realizado uma chamada (post ou get) para o WCF (rest).

O WCF vai colocar uma mensagem no MSMQ.

Vai ter outro WCF que vai ficar lendo a fila e gravando em algum BD (pode ser qualquer BD).

![Diagrama](https://i.snag.gy/MtKScy.jpg)
