using System;
using System.Threading;
using System.Threading.Tasks;

namespace STM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var s = new StmRef<int>(5))
            {
                Stm.Do(() =>
                {
                    s.Set(6);
                    s.Get();
                });

                Stm.Do(() =>
                {
                    s.Set(4);
                });

                Console.WriteLine();

                var taskRead = Task.Run(() =>
                {
                    Stm.Do(() =>
                    {
                        s.Get();
                        Thread.Sleep(1050);
                        s.Get();
                    });
                });

                var taskWrite = Task.Run(() =>
                {
                    Stm.Do(() =>
                    {
                        Thread.Sleep(200);
                        s.Set(2);
                    });
                });

                taskRead.Wait();
                taskWrite.Wait();
            }

            Console.WriteLine();
        }
    }
}
