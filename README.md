# Locadora

Sistema WEBAPI de uma locadora de filme

#Iniciando Projeto

Banco de dados MYSQL

versão do .NET framework 4.8

#Gerar Migrations e Banco de Dados
-Comando necessarios

Fazer o Downloads do Projeto no GitHub;
Abrir o projeto clicando em 'Gerenciamento de Consulta.sln' no VS 2019;
Nos arquivos "Startup.cs" e "appsentings.json" dentro da Vontroller verifique se a connectionString utilizada é compativel com seu servidor de banco de dados;
No Search digitar "Console" e selecionar o Packege Maneger Console;
No Packege Maneger Console(que abre na parte de baixo da tela);
Digitar os Seguintes comandos:
> Enable-Migrations - (A primeira vez para criar, depois não necessario)

> add-Migration

> upadate-database
