using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerProyecto
{
    public class MetricaSistema
    {
        public DateTime FechaHora { get; set; }
        public float UsoCpu { get; set; }
        public float TempCpu { get; set; }
        public float UsoGpu { get; set; }
        public float TempGpu { get; set; }
        public float VidRam { get; set; }
        public float UsoRam { get; set; }

        public MetricaSistema( float usoCpu, float tempCpu, float usoGpu, float tempGpu, float vidRam, float usoRam)
        {
            FechaHora = DateTime.Now;
            UsoCpu = usoCpu;
            TempCpu = tempCpu;
            UsoGpu = usoGpu;
            TempGpu = tempGpu;
            VidRam = vidRam;
            UsoRam = usoRam;
        }
        public void MostrarEnPantalla()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fecha actual: {FechaHora}");
            sb.AppendLine($"Uso CPU: {UsoCpu:F2} %");
            sb.AppendLine($"Temperatura CPU: {TempCpu:F2} °C");
            sb.AppendLine($"Uso GPU: {UsoGpu:F2} %");
            sb.AppendLine($"Temperatura GPU: {TempGpu:F2} °C");
            sb.AppendLine($"Uso vRAM en GB: {VidRam:F2}");
            sb.AppendLine($"Uso RAM en GB: {UsoRam:F2}");
            Console.WriteLine(sb);
        }
    }

 
}

