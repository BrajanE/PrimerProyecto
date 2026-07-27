namespace PrimerProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float promedioCpu;
            MetricaSistema maximo;

            MetricaSistema pc_1 = new MetricaSistema(89, 19000);
            MetricaSistema pc_2 = new MetricaSistema(15, 5000);
            MetricaSistema pc_3 = new MetricaSistema(55, 15000);
            MetricaSistema pc_4 = new MetricaSistema(34, 10000);

            AdministradorMetricas historial = new AdministradorMetricas();
            historial.AgregarMetrica(pc_1);
            historial.AgregarMetrica(pc_2);
            historial.AgregarMetrica(pc_3);
            historial.AgregarMetrica(pc_4);

            List<MetricaSistema> listaAlertas = new List<MetricaSistema>();

            listaAlertas = historial.ObtenerAlertasCpu(50);

            for (int i = 0; i < listaAlertas.Count; i++)
            {
                listaAlertas[i].MostrarEnPantalla();
            }

            promedioCpu = historial.ObtenerPromedioCpu();
            Console.WriteLine($"Promedio Uso Cpu: {promedioCpu}");
            maximo = historial.ObtenerMetricaMaximaCpu();
            Console.WriteLine($"Metrica Maxima:");
            maximo.MostrarEnPantalla();

            Console.WriteLine("**********LIMPIEZA**********");

            historial.LimpiarHistorial();
            maximo = null;

            promedioCpu = historial.ObtenerPromedioCpu();
            Console.WriteLine($"Promedio Uso Cpu: {promedioCpu}");
            if (maximo != null)
            {
                maximo = historial.ObtenerMetricaMaximaCpu();
                Console.WriteLine($"Metrica Maxima:");
                maximo.MostrarEnPantalla();
            }
            else Console.WriteLine("No hay metricas registradas!");
        }
    }
}
