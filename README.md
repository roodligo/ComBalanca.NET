# ComBalanca.NET

Este projeto é uma aplicação em C# para comunicação com uma balança através de uma porta serial. Ele solicita o peso da balança, lê a resposta, converte e formata o peso para exibição. Testes feitos com balança prix 3 fit.

## Funcionalidades

- Comunicação com a balança através de uma porta serial.
- Solicitação e leitura do peso da balança.
- Conversão e formatação do peso recebido.

## Requisitos

- .NET Framework (versão compatível)
- Balança conectada a uma porta serial do computador.

## Configuração

1. Clone este repositório para sua máquina local.
2. Abra o projeto no seu IDE de preferência.
3. Verifique e substitua a porta serial utilizada no código (`COM8`) pela porta correta à qual sua balança está conectada.

## Uso

1. Compile e execute o projeto.
2. Digite qualquer tecla para solicitar o peso da balança (exceto '0' para sair).
3. O peso recebido será exibido no console, formatado em quilogramas.
