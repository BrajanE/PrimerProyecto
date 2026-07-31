using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerProyecto
{
    public class MetricaSistema
    {
        public DateTime FechaHora { get; set; }
        public string NombreCpu { get; set; }
        public string NombreGpu { get; set; }
        public float UsoCpu { get; set; }
        public float TempCpu { get; set; }
        public float UsoGpu { get; set; }
        public float TempGpu { get; set; }
        public float VidRam { get; set; }
        public float UsoRam { get; set; }

        public MetricaSistema( string nombreCpu, string nombreGpu, float usoCpu, float tempCpu, float usoGpu, float tempGpu, float vidRam, float usoRam)
        {
            FechaHora = DateTime.Now;
            NombreCpu = nombreCpu;
            NombreGpu = nombreGpu;

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
            sb.AppendLine($"  ÚLTIMA ACTUALIZACIÓN: {DateTime.Now:HH:mm:ss}        ");
            sb.AppendLine($"--------------------------------------------------");
            sb.AppendLine($"*** CPU: {NombreCpu} ***");       
            sb.AppendLine($"    Uso:         {UsoCpu,6:F1} %                        ");
            sb.AppendLine($"    Temp:        {TempCpu,6:F1} °C                       ");
            sb.AppendLine($"--------------------------------------------------");
            sb.AppendLine($"*** GPU: {NombreGpu} ***");
            sb.AppendLine($"    Uso:         {UsoGpu,6:F1} %                        ");
            sb.AppendLine($"    Temp:        {TempGpu,6:F1} °C                       ");
            sb.AppendLine($"    vRAM Usada:  {VidRam,6:F2} GB                        ");
            sb.AppendLine($"--------------------------------------------------");
            sb.AppendLine($"    RAM Usada:   {UsoRam,6:F2} GB                        ");
            Console.WriteLine(sb);
        }
    }

 
}

