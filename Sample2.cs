namespace AsyncException
{
    public class Sample2
    {
        // Com paralelismo, usando Parallel.Invoke, aguardando resposta na Tread principal
        // O Parallel.Invoke usa uma Thread para cada tarefa
        public static void Execute()
        {
            try
            {
                Console.WriteLine("Inicio Sample2");
                Parallel.Invoke(
                    () => ProcessoA(),
                    () => ProcessoB(),
                    () => ProcessoC()
                );
                Console.WriteLine("Fim Sample2");
                Console.WriteLine("\n");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine("\n");
            }
        }

        private static void ProcessoA()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Processo A | Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void ProcessoB()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Processo B | Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void ProcessoC()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Processo C | Thread: {Thread.CurrentThread.ManagedThreadId}");
            throw new Exception("Erro no Processo C");
        }
    }
}