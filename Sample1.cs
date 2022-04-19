namespace AsyncException
{
    public class Sample1
    {
        // Sem paralelismo
        public static void Execute()
        {
            try
            {
                Console.WriteLine("Inicio Sample1");
                ProcessoA();
                ProcessoB();
                ProcessoC();
                Console.WriteLine("Fim Sample1");
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