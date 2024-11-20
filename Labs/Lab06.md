# Задание 6. Доработка карточки для отображения проблем валидации

Требуется доработать карточку сотрудника, что бы все ошибки валидации отображались под карточкой в виде списка проблем. Должны отображаться все критерии, по которым валидация не прошла.

## Требования к функционалу программы

1. Формат команд и вывода на экран следующий:

```Shell
>pllab.exe --show --email "Ivanova@org.ru" 
 Name: Ivanova I.I.
EMail: Ivanova@
Phone: 23-45-6seven
Hired: 01.09.2020
Fired: 01.10.2019

Validation errors:
1. Email format is incorrect
2. Phone format is incorrect, 
3. Hired date is more than fired. Please, check dates.
```

2. В случае отсутствия ошибок валидации, блок "Validation errors:" отображаться не должен.

## Требования к коду программы

1. Список ошибок валидации должен собираться в виде списка или коллекции объектов ValidationException.
2. Сообщение для вывода на экран следует брать из текста Exception.

## Приёмка

1. В качестве файла data.json следует взять следующий пример:

```JSON
{
    "Employees": [
        {
            "FullName": ""
            "Email": "ivanova"
            "Phone": "23-45-6seven"
            "Hired": "01.09.2022 0:00:00"
            "Fired": "01.09.2020 0:00:00"
        },
        {
            "FullName": "Petrov E.G."
            "Email": "Petrov@org.ru"
            "Phone": "8(923)67-222-37"
            "Hired": "01.09.2021 0:00:00"
            "Fired": ""
        }
    ]
}
```

2. Вывод на экран программы должен быть следующим (текст и конкретные формулировки могут отличаться, но общий стиль форматирования и структура вывода должны сохраняться):

```Shell
>pllab.exe --show --email "ivanova" 
 Name: 
EMail: Ivanova
Phone: 23-45-6seven
Hired: 01.09.2020
Fired: 01.10.2019

Validation errors:
1. Name can not be empty. Please specify value.
2. Email format is incorrect.
3. Phone format is incorrect. 
4. Hired date is more than fired. Please, check dates.

>pllab.exe --show --email "Petrov@org.ru" 
 Name: Pertov E.G.
EMail: Petrov@org.ru
Phone: 8(923)67-222-37
Hired: 01.09.2021
Fired: 
```
