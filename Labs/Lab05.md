# Задание 5. Работа с исключениями. Валидация данных

Необходимо разработать механизм валидации данных и реализовать базовые проверки для исключения ошибок ввода данных пользователем.

Валидация должна строиться с использованием исключений для контроля отдельных критериев. Для этого необходимо реализовать в коде класс ValidationException следующего вида:

```CSharp
public class ValidationException: Exception
{
    //...
}
```

Методы валидации должны выглядеть следующим образом:

```CSharp
public void Validate(SomeType object)
{
    if (<Проверка условия>)
    {
        //Если объект не прошёл валидацию по критерию
        throw new ValidationException("Some message");
    }
}
```

## Требования к функционалу программы

1. При создании записи сотрудника значения --name, --phone, --hired являются обязательными

2. Формат ввода телефона и email должны контролироваться на соответствие регулярному выражению. Примеры готовых выражений можно найти на сайте: https://ihateregex.io/

3. При создании/редактировании записи поле --fired не может иметь значение меньше чем --hired.

4. При вводе отпусков поле --end должно быть не меньше чем --start;

5. В случае, если ошибка в данных обнаружена на этапе ввода данных, должно выдаваться сообщение об ошибке. Сообщение должно начинаться с "ERROR:".

6. Формат команд и вывода на экран следующий:

```Shell
>pllab.exe --add --email "Ivanova@org.ru" --phone "8(923)123-45-67" --hired "01.09.2020"
ERROR: Name is necessary. Please, specify --name parameter.

>pllab.exe --add --email "Ivanova@org.ru" --name "Ivanova I.I." --hired "01.09.2020"
ERROR: Phone is necessary. Please, specify --phone parameter.

>pllab.exe --add --email "Ivanova@org.ru" --name "Ivanova I.I." --phone "8(923)123-45-67"
ERROR: Hired date is necessary. Please, specify --hired parameter.

>pllab.exe --add --email "Ivanova@org.ru" --name "Ivanova I.I." --phone "3-45-67" --hired "01.09.2020"
ERROR: Incorrect format of phone. Please, check string --phone

>pllab.exe --add --email "Ivanova" --name "Ivanova I.I." --phone "3-45-67" --hired "01.09.2020"
ERROR: Incorrect format of email. Please, use format '<user>@<server>.<local>' of string --email.

>pllab.exe --add --email "Ivanova@org.ru" --name "Ivanova I.I." --phone "8(923)123-45-67" --hired "01.09.2020" --fired "01.08.2020"
ERROR: Fired date must be greater than hired date. Please, check dates --hired and --fired and try again.
```

## Требования к коду программы

1. Отдельный класс ValidationException для хранения данных сотрудника.
2. Отдельные классы-валидаторы с различными критериями проверок.
3. Централизованный механизм использования и расширения набора валидаторов.
4. В журнал событий обязательно должны фиксироваться ошибки валидации.
5. Все классы-валидаторы должны быть покрыты тестами.

## Приёмка

1. Последовательность команд из п.6 должна выполняться указанным там способом, без существенных отклонений.
2. Должны быть реализованы модульные тесты. Все тесты должны выполняться успешно.
3. Должны быть реализованы все требования к коду.
