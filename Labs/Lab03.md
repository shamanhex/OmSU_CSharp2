# Задание 3. Формирование БД сотрудников. Базовые CRUD операции

Логика анализа аргументов командной стройки из первых 2х лабораторных, исключается из программы.

Необходимо разработать класс Employee для хранения данных сотрудника следующего вида:

```CSharp
public class Employee
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Hired { get; set; }
    public DateTime Fired { get; set; }
}
```

Реализовать простую базу данных в программе и базовые CRUD (Create, Read, Update, Delete) операции через аргументы командной строки. Данные базы должны храниться в файле data.json в той же директории, где находится исполняемый файл.

В качестве первичного ключа, по которому уникально идентифицируются записи, используется email.

## Примечания

Для работы с конфигурацией рекомендуется использовать библиотеку Newtonsoft.Json

```Shell
dotnet add package Newtonsoft.Json
```

## Требования к функционалу программы

1. Если файл с данными удалён, программа должна его создать пустым.

2. Если аргументы не соответствуют логике выполняемой операции, то необходимо вывести соответствующее сообщение об ошибке.

3. Если аргумент не указан его значение следует считать пустым (null). Пустые строки приравниваются к отсутствию значению.

4. При выполнении операций --add, --show, --remove поле email является обязательным, остальные поля опциональны.

5. Формат команд и вывода на экран следующий:

```Shell
>pllab.exe
ERROR: Please specify arguments. 

>pllab.exe --list
No records in database.

>pllab.exe --add --email "Ivanova@org.ru" --name "Ivanova I.I." --phone "8(923)123-45-67" --hired "01.09.2020" --fired "01.10.2021"
Record added successfull.

 Name: Ivanova I.I.
EMail: Ivanova@org.ru
Phone: 8(923)123-45-67
Hired: 01.09.2020
Fired: 01.10.2021

>pllab.exe --add --email "petrov@mail.ru" --name "Petrov K.G." --phone "8(913)765-43-21"
Record added successfull.

 Name: Petrov K.G.
EMail: petrov@mail.ru
Phone: 8(913)765-43-21
Hired: -
Fired: -

>pllab.exe --list
| Name         | EMail           | Phone           | Hired      | Fired      |
| Ivanova I.I. | Ivanova@org.ru  | 8(923)123-45-67 | 01.09.2020 | 01.10.2021 |
| Petrov K.G.  | petrov@mail.ru  | 8(913)765-43-21 | -          | -          |

>pllab.exe --show --email "Ivanova@org.ru"
 Name: Ivanova I.I.
EMail: Ivanova@org.ru
Phone: 8(923)123-45-67
Hired: 01.09.2020
Fired: 01.10.2021

>pllab.exe --update --email "Ivanova@org.ru" --phone "8(923)777-66-55"
Phone updated.

 Name: Ivanova I.I.
EMail: Ivanova@org.ru
Phone: 8(923)777-66-55
Hired: 01.09.2020
Fired: 01.10.2021

>pllab.exe --update --email "Ivanova@org.ru" --name "Petrova I.I."
Name updated.

 Name: Petrova I.I.
EMail: Ivanova@org.ru
Phone: 8(923)777-66-55
Hired: 01.09.2020
Fired: 01.10.2021

>pllab.exe --remove --email "Ivanova@org.ru"
Ivanova@org.ru was removed.

```

## Требования к коду программы

1. Отдельный класс Employee для хранения данных сотрудника.
2. Отдельный класс для операций с базой данных DataEngine.
3. Отдельный класс для форматирования таблиц.
4. В журнал событий обязательно должны фиксироваться операции --list, --show, --add, --update, --remove.
5. Должны быть написаны модульные тесты на 10 любых методов. Тестируемые методы студент может выбрать самостоятельно.
6. Тестовый проект должен называться так же как и проект основной программы, но к имени следует добавить ".Tests"
7. Структура файлов тестового проекта должна повторять основной проект. т.е. структура папок и расположение файлов аналогичное.
8. Классы с тестами должны иметь такое же имя, как и тестируемый класс, но с постфиксом "Tests", как в имени класса, так и в имени файла.
9. Тестовые методы следует именовать следующим образом class_method_scenario_result();

## Приёмка

1. Последовательность команд из п.5 должна выполняться указанным там способом, без существенных отклонений.
2. Должны быть реализованы модульные тесты. Все тесты должны выполняться успешно.
3. Должны быть реализованы все требования к коду.
