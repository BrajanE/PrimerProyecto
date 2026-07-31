namespace PrimerProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; // Oculta el cursor para que no parpadee
            LectorHardware lector = new LectorHardware();

            Console.WriteLine("Iniciando monitoreo en vivo... Presioná 'ESC' para salir.\n");
            Thread.Sleep(1000);

            // Bucle principal de monitoreo
            while (true)
            {
                // Si el usuario presiona la tecla ESC, salimos del bucle
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    break;
                }

                // 1. Obtenemos las métricas en tiempo real
                MetricaSistema metrica = lector.ObtenerMetricaActual();

                // 2. Reposicionamos el cursor arriba del todo para sobrescribir en lugar de usar Clear()
                // (Esto evita el parpadeo molesto en la consola)
                Console.SetCursorPosition(0, 2);

                metrica.MostrarEnPantalla();

                // 4. Pausa de 1 segundo entre lecturas
                Thread.Sleep(1000);
            }

            // Cierre limpio de hardware al salir
            lector.TerminarMonitoreo();
            Console.CursorVisible = true;
            Console.WriteLine("\nMonitoreo finalizado correctamente.");

        }
    }
}
