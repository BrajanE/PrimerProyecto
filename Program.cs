namespace PrimerProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MetricaSistema> historialMetricas = new List<MetricaSistema>();
            historialMetricas.Add(new MetricaSistema(89,19000));
            historialMetricas.Add(new MetricaSistema(15,5000));
            historialMetricas.Add(new MetricaSistema(55,15000));
            historialMetricas.Add(new MetricaSistema(34,10000));

            foreach(MetricaSistema metrica in historialMetricas){
                metrica.MostrarEnPantalla();
            }
        }
    }
}
