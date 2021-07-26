# Тема: Linux + .Net

### Работа с линукс под .Net

У windows разработчика есть 3 стула для работы с Linux

1. 	Собирать на машине с linux через dotnet build, как если бы он делал это на виндовой машине
2.  Собрать self - contained папку на винде, и перенести все из папки publish на linux машину 

>	dotnet publish -c release -r win10-x64 

3. Docker. Собрать свой образ и запустить его на linux - машине
