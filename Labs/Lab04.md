# Задание 4. Добавить механизм учёта отпусков

Необходимо доработать класс Employee для хранения данных отпусков сотрудника. Итоговый вид класса:

```CSharp
public class Employee
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Hired { get; set; }
    public DateTime Fired { get; set; }

    public List<EmployeeVacation> Vacations { get; set; }
}


public class EmployeeVacation
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}
```

Так же необходимо реализовать команды для редактирования отпусков.

## Требования к функционалу программы

1. При создании записи сотрудника, список отпусков должен быть пустым.

2. Для добавления отпуска необходимо указать --email сотрудника и даты начала (--start) и окончания отпуска (--end). Параметры --start и --end обязательные.

3. Для удаления отпуска необходимо указать --email сотрудника и дату начала отпуска (--start)

4. Формат команд и вывода на экран следующий:

```Shell
>pllab.exe --add-vacation --email "Ivanova@org.ru" --start "01.09.2024" --end "16.09.2024"
Vacation added successfull.

 Name: Ivanova I.I.
EMail: Ivanova@org.ru
Phone: 8(923)123-45-67
Hired: 01.09.2020
Fired: 01.10.2021

Vacations
| Start      | End        |
| 01.09.2024 | 16.09.2024 |

>pllab.exe --add-vacation --start "01.09.2024" --end "16.09.2024"
ERROR: Employee not specified. Specify --email parameter.

>pllab.exe --add-vacation --email "Ivanova@org.ru" --start "01.09.2024" 
ERROR: End of vacation is necessary. Specify --end parameter.

>pllab.exe --add-vacation --email "Ivanova@org.ru" --end "01.09.2024" 
ERROR: Start of vacation is necessary. Specify --start parameter.

>pllab.exe --remove-vacation --email "Ivanova@org.ru" --start "01.09.2024"
Vacation was removed.

 Name: Ivanova I.I.
EMail: Ivanova@org.ru
Phone: 8(923)123-45-67
Hired: 01.09.2020
Fired: 01.10.2021

No vacations

>pllab.exe --remove-vacation --email "Ivanova@org.ru"
ERROR: Start of vacation is necessary. Specify --start parameter.
```

## Требования к коду программы

1. Отдельный класс EmployeeVacation для хранения данных сотрудника.
2. В журнал событий обязательно должны фиксироваться операции --add-vacation, --remove-vacation.
3. Должны быть написаны модульные тесты на 30 любых методов. Тестируемые методы студент может выбрать самостоятельно.

## Приёмка

1. Последовательность команд из п.4 должна выполняться указанным там способом, без существенных отклонений.
2. Должны быть реализованы модульные тесты. Все тесты должны выполняться успешно.
3. Должны быть реализованы все требования к коду.
