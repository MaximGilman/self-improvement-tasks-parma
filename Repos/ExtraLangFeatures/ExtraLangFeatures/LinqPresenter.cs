using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ExtraLangFeatures
{
    public class LinqPresenter
    {
        public LinqPresenter()
        {
        }

        public void Run()
        {
            // Получение коллекции и работа над элементами
            var collection = new List<Operation>()
            {
                new Operation() {Value = 10},
                new Operation() {Value = 0}
            };

            Print(collection, nameof(collection));
            // Через расширения
            var smallOperations = collection.Where(x => x.Value < 10).Select(x => x.Value);
            Print(smallOperations, nameof(smallOperations));

            // Напрямую LINQ
            var otherSmallOperations = from c in collection
                                       where c.Value < 10
                                       select c.Value;
            Print(otherSmallOperations, nameof(otherSmallOperations));

            // Анонимные методы
            Func<Operation, bool> searchSmallOperationsLambdaFunc = op => op.Value < 10;
            Func<Operation, bool> searchSmallOperationsFunc = delegate (Operation op) { return op.Value < 10; };

            Func<Operation, int> projectValues = delegate (Operation op) { return op.Value; };

            var smallOperationsWithAnonMethods =
                collection.Where(searchSmallOperationsFunc).Select(projectValues);
            Print(smallOperationsWithAnonMethods, nameof(smallOperationsWithAnonMethods));

            // Просто методы
            Func<Operation, bool> searchFilter = new Func<Operation, bool>(FindSmall);
            var otherSmallOperationsWithMethod = collection.Where(searchFilter);
            Print(otherSmallOperationsWithMethod, nameof(otherSmallOperationsWithMethod));

            var smallOperationsWithMethod = collection.Where(FindSmall);
            Print(smallOperationsWithMethod, nameof(smallOperationsWithMethod));

            // Не типизированные коллекции
            ArrayList list = new ArrayList()
            {
                new Operation() {Value = 1},
                1,
                null,
                "string"
            };
            
            var operations = list.OfType<Operation>().Select(x => x);
            Print(operations, nameof(operations));

            try
            {
                var enumerable = list.Cast<Operation>();
                Print(enumerable, nameof(enumerable));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool FindSmall(Operation arg) => arg.Value < 10;
        private void Print<T>(IEnumerable<T> collection, string name)
        {
            Console.WriteLine($"Коллекция: {name}");
            foreach (var element in collection)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();
        }
        
        // Про пересечение - при экспорте есть проверка на дельту. Там пересечение
    }
}