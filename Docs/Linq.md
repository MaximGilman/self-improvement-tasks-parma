# LINQ

## Основные моменты в работе LINQ
- Неявно типизированые лок. переменные
- Упрощенный синтаксис инициализации
- Лямбда - выражения
- Методы расширения
- Анонимные типы

### LINQ TO
- LINQ To objects - arrays and collections
- LINQ To XML - XPath - like
- LINQ To DataSet - ADO.NET
- LINQ To Entities - EF
- PLINQ - AsParrallel

## Роль Linq
#### Общий подход к разным DataSource'ам. Строится не запрос, а выражение запроса, которое описывает flow работы с данными. Одно выражение в зависимости от источника данных по-разному преобразуется в исполняемые команды

> В Linq выражения __строго типизированы__, в отличие от SQL и CLR будет следить за корректностью

### Два базовых подхода к написанию запроса
#### Базовый
```csharp
from F in collection
where CLAUSE
order by ORDER
select PROJECTION
```
#### Через метод расширения
```csharp
collection.Where().OrderBy().Select();
```

> Оба формата *почти* взаимозаменяемы. 
Первый вернет **OrderedEnumerable<_T_>**. Второй **WhereSelectEnumerableIterator<_T_>** c Select и **OrderedEnumerable<_T_>** без него.

В общем случае используется IEnumerable<_T_>


## Методы расширения LINQ
### LINQ работает для реализаций IEnumerable<_T_>. 
>Array не реализует такой интерфейс, но LINQ с ним работает, поскольку Array получил его через System.Linq.Enumerable


## Отложенное выполнение
#### Linq строит дерево выражений (AST) и под катом использует итераторы. Это значит, что реальное значение коллекции не будет рассчитано, пока не начнется итерация. 
Данный подход позволяет создать конвейер запросов а выполнить его только один раз.
> Чтобы начать итерацию достаточно пробежаться по коллекции. Это происходит при вызове ToList(), Cast(), foreach.

> Присваивание результата LINQ запроса в конкретный тип коллекции тоже вызовет итерацию. List получит значение сразу, а IEnumerable оставит выражение не посчитанным



## LINQ и необощенные коллекции
#### Можно запустить LINQ для коллекции, предварительно скастовав ее в нужный тип или отобрать те, которые подходят под описание
- Cast<_T_> - попробует съесть все
- OfType<_T_> - отберет все подходящие



## Устройство запросов
#### Условия принимают делегаты. Их можно описать своими методами или лямбдами по месту использования

> IEnumerable сразу кастанет и рассчитает значение в памяти, а вот IQuariable позволяет перемещаться в обе стороны коллекции удаленно