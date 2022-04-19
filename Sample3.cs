namespace AsyncException
{
    public class Sample3
    {
        // Com paralelismo, usando Task, aguardando resposta na Tread principal
        // O Paralelismo com async await deixa o gerenciamento de treads por conta do .NET
        public static void Execute()
        {
            try
            {
                Console.WriteLine("Inicio Sample3");
                var stepProcessors = new List<Task>() { ProcessoA(), ProcessoB(), ProcessoC() };
                Task.WaitAll(stepProcessors.ToArray());
                Console.WriteLine("Fim Sample3");
                Console.WriteLine("\n");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine("\n");
            }
        }

        private static async Task ProcessoA()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Processo A | Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task ProcessoB()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Processo B | Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task ProcessoC()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Processo C | Thread: {Thread.CurrentThread.ManagedThreadId}");
            throw new Exception("Erro no Processo C");
        }
    }
}