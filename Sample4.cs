namespace AsyncException
{
    public class Sample4
    {
        // Com paralelismo, usando Task, sem aguardar resposta na Tread principal
        // A Thread principal não "enxerga" o que está acontecendo em outras Threads, ou não aguarda a resposta de outras Threads
        // Logo, a exceção que é lançada no processo C não é identificado na Thread principal
        // Logs acabam sendo a melhor opção para tratar exceções nestes casos
        public static void Execute()
        {
            try
            {
                Console.WriteLine("Inicio Sample4");
                ProcessoA();
                ProcessoB();
                ProcessoC();
                Console.WriteLine("Fim Sample4");
                Console.WriteLine("\n");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");                
                Console.WriteLine("\n");
            }
        }

        private static async void ProcessoA()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Processo A | Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async void ProcessoB()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Processo B | Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async void ProcessoC()
        {
            await Task.Delay(2000);
            Console.WriteLine($"Processo C | Thread: {Thread.CurrentThread.ManagedThreadId}");
            throw new Exception("Erro no Processo C");
        }
    }
}