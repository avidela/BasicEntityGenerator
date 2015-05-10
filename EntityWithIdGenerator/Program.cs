namespace EntityWithIdGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public static class Program
    {
        static Program()
        {
            LocalEntityBuilder = new EntityBuilder();

            EntitlyList = new List<BaseEntity>();    
        }

        private static IEntityBuilder LocalEntityBuilder { get; set; }

        private static IList<BaseEntity> EntitlyList { get; set; }

        public static void Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                CreateNewEntities(50000000);
                stopwatch.Stop();
                Console.WriteLine("Total Entities Created {0} in {1}ms", EntitlyList.Count, stopwatch.ElapsedMilliseconds);
                Console.ReadKey();
            }
            catch (OutOfMemoryException exception)
            {
                stopwatch.Stop();

                Console.WriteLine("Total Entities Created {0} in {1}ms", EntitlyList.Count, stopwatch.ElapsedMilliseconds);
                Console.WriteLine("Not enough memory to create new entities. {0}", exception.Message);
                Console.WriteLine("Consider adding extra ram  or compiling as x64...");
                Console.ReadKey();
            }
        }

        private static void CreateNewEntities(long total)
        {
            for (var i = 0; i < total; i++)
            {
                var newEntity = LocalEntityBuilder.Build();
                EntitlyList.Add(newEntity);
            }
        }
    }
}