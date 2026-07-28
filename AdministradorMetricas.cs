using System.Text;

namespace PrimerProyecto
{
    public class AdministradorMetricas
    {
        private List<MetricaSistema> Historial;

        public AdministradorMetricas()
        {
            Historial = new List<MetricaSistema>();
        }
        public void AgregarMetrica(MetricaSistema nuevaMetrica)
        {
            Historial.Add(nuevaMetrica);
        }
        public List<MetricaSistema> ObtenerAlertasCpu(float porcentajeDeUso)
        {
            List<MetricaSistema> historialAux = new List<MetricaSistema>();

            foreach (MetricaSistema metrica in Historial)
            {
                if (metrica.UsoCpu > porcentajeDeUso)
                {
                    historialAux.Add(metrica);
                }

            }

            return historialAux;
        }
        public List<MetricaSistema> ObtenerAlertasGpu(float porcentajeDeUso)
        {
            List<MetricaSistema> historialAux = new List<MetricaSistema>();

            foreach (MetricaSistema metrica in Historial)
            {
                if (metrica.UsoGpu > porcentajeDeUso)
                {
                    historialAux.Add(metrica);
                }

            }

            return historialAux;
        }
        public float ObtenerPromedioCpu()
        {
            float sumaDeUsos = 0;
            if (Historial.Count > 0)
            {
                for (int i = 0; i < Historial.Count; i++)
                {
                    sumaDeUsos += Historial[i].UsoCpu;
                }
                return sumaDeUsos / Historial.Count;
            }
            return 0;
        }
        public MetricaSistema ObtenerMetricaMaximaCpu()
        {
            MetricaSistema maximo = null;

            if (Historial.Count > 0)
            {
                maximo = Historial[0];
                for (int i = 1; i < Historial.Count; i++)
                {

                    if (Historial[i].UsoCpu >= maximo.UsoCpu)
                    {
                        maximo = Historial[i];
                    }
                }
                return maximo;

            }
            return maximo;
        }
        public MetricaSistema ObtenerTemperatiraMaximaCpu()
        {
            MetricaSistema maximo = null;

            if (Historial.Count > 0)
            {
                maximo = Historial[0];
                for (int i = 1; i < Historial.Count; i++)
                {

                    if (Historial[i].TempCpu >= maximo.TempCpu)
                    {
                        maximo = Historial[i];
                    }
                }
                return maximo;

            }
            return maximo;
        }
        public float ObtenerPromedioGpu()
        {
            float sumaDeUsos = 0;
            if (Historial.Count > 0)
            {
                for (int i = 0; i < Historial.Count; i++)
                {
                    sumaDeUsos += Historial[i].UsoGpu;
                }
                return sumaDeUsos / Historial.Count;
            }
            return 0;
        }
        public MetricaSistema ObtenerMetricaMaximaGpu()
        {
            MetricaSistema maximo = null;

            if (Historial.Count > 0)
            {
                maximo = Historial[0];
                for (int i = 1; i < Historial.Count; i++)
                {

                    if (Historial[i].UsoGpu >= maximo.UsoGpu)
                    {
                        maximo = Historial[i];
                    }
                }
                return maximo;

            }
            return maximo;
        }
        public MetricaSistema ObtenerTemperatiraMaximaGpu()
        {
            MetricaSistema maximo = null;

            if (Historial.Count > 0)
            {
                maximo = Historial[0];
                for (int i = 1; i < Historial.Count; i++)
                {

                    if (Historial[i].TempGpu >= maximo.TempGpu)
                    {
                        maximo = Historial[i];
                    }
                }
                return maximo;

            }
            return maximo;
        }
        public void LimpiarHistorial()
        {
            Historial.Clear();
        }
        public void MostrarHistorialCompleto()
        {
            if (Historial.Count > 0)
            {
                Console.WriteLine("**HISTORIAL DE METRICAS**");
                StringBuilder sb = new StringBuilder();
                foreach (MetricaSistema metrica in Historial)
                {
                    metrica.MostrarEnPantalla();
                }
            }
            else Console.WriteLine("**HISTORIAL VACIO**");
        }
    }
}
