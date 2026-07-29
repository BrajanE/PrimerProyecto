namespace PrimerProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            MetricaSistema pc_1 = new MetricaSistema(18.5f, 45.2f, 12.8f, 39.5f, 2100, 6800);
            MetricaSistema pc_2 = new MetricaSistema(42.3f, 58.7f, 35.4f, 55.1f, 4700, 10200);
            MetricaSistema pc_3 = new MetricaSistema(67.9f, 71.3f, 81.6f, 73.8f, 8900, 14500);
            MetricaSistema pc_4 = new MetricaSistema(9.8f, 40.6f, 95.3f, 35.7f, 1200, 5400);

            AdministradorMetricas historial = new AdministradorMetricas();
            historial.AgregarMetrica(pc_1);
            historial.AgregarMetrica(pc_2);
            historial.AgregarMetrica(pc_3);
            historial.AgregarMetrica(pc_4);
            */
            LectorHardware pc = new LectorHardware();
            MetricaSistema pc_1 = pc.ObtenerMetricaActual();
            pc_1.MostrarEnPantalla();
            pc.TerminarMonitoreo();

        }
    }
}
