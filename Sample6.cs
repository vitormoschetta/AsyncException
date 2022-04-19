namespace AsyncException
{
    public class Sample6
    {
        public static async Task Execute()
        {
            try
            {
                Console.WriteLine("Inicio Sample6");

                var (result1, result2, result3) = (ProcessoA(), ProcessoB(), ProcessoC());

                var stepProcessors = new List<Task>() { result1, result2, result3 };
                Task.WaitAll(stepProcessors.ToArray());

                Console.WriteLine("Resultados | ProcessoA: {0} | ProcessoB: {1} | ProcessoC: {2}", await result1, await result2, await result3);

                Console.WriteLine("Fim Sample6");
                Console.WriteLine("\n");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine("\n");
            }
        }

        private static async Task<int> ProcessoA()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Processo A | Thread: {Thread.CurrentThread.ManagedThreadId}");
            return 1;
        }

        private static async Task<int> ProcessoB()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Processo B | Thread: {Thread.CurrentThread.ManagedThreadId}");
            return 2;
        }

        private static async Task<int> ProcessoC()
        {
            try
            {
                await Task.Delay(2000);
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