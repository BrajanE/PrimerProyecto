using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerProyecto
{
    public class MetricaSistema
    {
        public DateTime FechaHora { get; set; }
        public float UsoCpu { get; set; }
        public float UsoRam { get; set; }

        public MetricaSistema( float usoCpu, float usoRam)
        {
            FechaHora = DateTime.Now;
            UsoCpu = usoCpu;
            UsoRam = usoRam;
        }
        public void MostrarEnPantalla()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fecha actual: {FechaHora}");
            sb.AppendLine($"Uso CPU: {UsoCpu}");
            sb.AppendLine($"Uso RAM en MB: {UsoRam}");
            Console.WriteLine(sb);
        }
    }

 
}

