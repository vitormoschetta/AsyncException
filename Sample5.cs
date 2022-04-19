namespace AsyncException
{
    public class Sample5
    {
        public static void Execute()
        {
            try
            {
                Console.WriteLine("Inicio Sample5");

                var (result1, result2, result3) = (0, 0, 0);

                Parallel.Invoke(
                    () => result1 = ProcessoA(),
                    () => result2 = ProcessoB(),
                    () => result3 = ProcessoC()
                );

                Console.WriteLine("Resultados | ProcessoA: {0} | ProcessoB: {1} | ProcessoC: {2}", result1, result2, result3);

                Console.WriteLine("Fim Sample5");
                Console.WriteLine("\n");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine("\n");
            }
        }

        private static int ProcessoA()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Processo A | Thread: {Thread.CurrentThread.ManagedThreadId}");
            return 1;
        }

        private static int ProcessoB()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Processo B | Thread: {Thread.CurrentThread.ManagedThreadId}");
            return 2;
        }

        private static int ProcessoC()
        {
            try
            {
                Thread.Sleep(2000);
                Console.WriteLine($"Processo C | Thread: {Thread.CurrentThread.ManagedThreadId}");
                throw new Exception("Erro no Processo C");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return 0;
            }
        }
    }
}