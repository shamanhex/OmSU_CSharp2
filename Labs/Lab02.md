# Задание 2. Подключение файла конфигурации и вывод журнала сообщений

К разработанному ранее консольному приложению необходимо подключить файл appsettings.json, в котором будет храниться конфигурация приложения. Вынести строку вывода в конфигурацию. В сроке должны обрабатываться следующие маркеры:

1. %name% - при выводе заменяется на значение параметра --name
2. %hired% - при выводе заменяется на значение параметра --hired в формате "ММ.ДД.ГГГГ"

Пример файла конфигурации:

```JSON
{
    "Message":"%name% was employed on %hired%". 
}
```

## Примечания

Для работы с конфигурацией рекомендуется использовать библиотеку Microsoft.Extensions.Configuration.

```Shell
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
```

Для работы с журналом событий рекомендуется использовать NLog

```Shell
dotnet add package NLog
```

## Требования к функционалу программы

1. При выполнении программы, сообщение должно формироваться на основе параметра указанного в appsettings.json. Пример:

```Shell
>'{ "Message":"%name% hired %hired%" }' > appsettings.json
>pllab.exe --name "Ivanov Ivan Ivanovich" --hired "01.01.2020"
Ivanov Ivan Ivanovich hired 01.01.2020
```

2. Если файл конфигурации не найден, должно выводиться сообщение об ошибке:

```Shell
>rm appsettings.json
>pllab.exe --name "Ivanov Ivan Ivanovich" --hired "01.01.2020"
ERROR: Configuration file appsettings.json not found or access denied.
```

## Требования к коду программы

1. Отдельный класс отвечающий за работу с конфигурацией (рекомендованное имя Cfg)
2. Отдельный класс отвечающий за журналирование событий и вывод на экран (рекомендованное имя Log)
3. В классе лог реализовать методы "Debug", "Info", "Console", "Error" для различных вариантов событий.
4. Журналироваться должны следующие события:

*<В разработке...>*

## Приёмка

1. Запустить командную оболочку и перейти в каталог с программой.
2. Сформировать файл конфигурации и проверить запуск программы:

```Shell
>'{ "Message":"%name% hired %hired%" }' > appsettings.json
>pllab.exe --name "Ivanov Ivan Ivanovich" --hired "01.01.2020"
Ivanov Ivan Ivanovich hired 01.01.2020
```

3. Проверить отсутствие имени в аргументах. Вывод должен начинаться с "ERROR: ", дальнейший текст ошибки на усмотрение студента:

```
>pllab.exe --hired "01.01.1990"
ERROR: Name not specified. Please, specify --name argument.
```

4. Проверить отсутствие даты трудоустройства в аргументах. Вывод должен начинаться с "ERROR: ", дальнейший текст ошибки на усмотрение студента:

```
>pllab.exe --name "Ivanov Ivan Ivanovich"
ERROR: Hired date not specified. Please, specify --hired argument.
```

5. Проверить ввод некорректной даты в разных вариантах. Должен подходить только формат ДД.ММ.ГГГГ, любой другой формат должен вызывать ошибку с сообщением начинающимся на "ERROR: ":

```
>pllab.exe --name "Ivanov Ivan Ivanovich" --hired "1.01.2015"
ERROR: Hired date is incorrect. Please, use the format DD.MM.YYYY.
>pllab.exe --name "Ivanov Ivan Ivanovich" --hired "01.1.2015"
ERROR: Hired date is incorrect. Please, use the format DD.MM.YYYY.
>pllab.exe --name "Ivanov Ivan Ivanovich" --hired "01.01.15"
ERROR: Hired date is incorrect. Please, use the format DD.MM.YYYY.
>pllab.exe --name "Ivanov Ivan Ivanovich" --hired "2015-01-01"
ERROR: Hired date is incorrect. Please, use the format DD.MM.YYYY.
```
