using LibreHardwareMonitor.Hardware;


namespace PrimerProyecto
{
    public class LectorHardware
    {
        private Computer pcMasterRace;
        private IHardware cpu;
        private List<IHardware> gpus = new List<IHardware>();
        private IHardware ram;

        public LectorHardware()
        {
            pcMasterRace = new Computer()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
            };
            pcMasterRace.Open();


            foreach (IHardware componente in pcMasterRace.Hardware)
            {
                switch (componente.HardwareType)
                {
                    case HardwareType.Cpu:
                        cpu = componente;
                        break;

                    case HardwareType.GpuNvidia:
                    case HardwareType.GpuAmd:
                    case HardwareType.GpuIntel:
                        gpus.Add(componente);
                        break;
                    case HardwareType.Memory:
                        ram = componente;
                        break;
                }
            }
        }

        public void TerminarMonitoreo()
        {
            pcMasterRace.Close();
        }
        public MetricaSistema ObtenerMetricaActual()
        {
            float usoCpu = 0;
            float tempCpu = 0;
            float usoGpu = 0;
            float tempGpu = 0;
            float vidRam = 0;
            float usoRam = 0;

            if (cpu != null)
            {
                cpu.Update();
                foreach (ISensor sensor in cpu.Sensors)
                {

                    if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Total"))
                    {
                        usoCpu = sensor.Value ?? 0;
                    }

                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        float valor = sensor.Value ?? 0;

                        if (sensor.Name.Contains("Tctl") || sensor.Name.Contains("Package") || sensor.Name.Contains("Core"))
                        {
                            tempCpu = valor;
                        }
                    }

                }

                // A FALTA DE SENSOR DE TEMPERATUA ACCESIBLE POR EL MOMENTO USARE ESTA FORMULA GENERAL

                if (tempCpu == 0)
                {
                    tempCpu = 35.0f + (usoCpu * 0.45f);
                }
            }

            if (gpus != null)
            {
                foreach (IHardware gpu in gpus)
                {
                    gpu.Update();
                    foreach (ISensor sensor in gpu.Sensors)
                    {

                        if (sensor.SensorType == SensorType.Load && (sensor.Name == "GPU Core" || sensor.Name == "D3D 3D" || sensor.Name == "GPU Engine"))
                        {
                            float cargaActual = sensor.Value ?? 0;

                            if (cargaActual > usoGpu)
                            {
                                usoGpu = cargaActual;
                            }

                        }
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("Core"))
                        {

                            float tempActual = sensor.Value ?? 0;

                            if (tempActual > tempGpu)
                            {
                                tempGpu = tempActual;
                            }
                        }

                        if (sensor.Name.Contains("Used") && (sensor.Name.Contains("Memory") || sensor.Name.Contains("VRAM")) && !sensor.Name.Contains("Shared"))
                        {

                            float memoriaActual = 0;
                            if (sensor.SensorType == SensorType.Data)
                            {
                                memoriaActual = sensor.Value ?? 0;
                            }
                            else if (sensor.SensorType == SensorType.SmallData && sensor.Name == "GPU Memory Used")
                            {
                                memoriaActual = (sensor.Value ?? 0) / 1024;
                            }
                            if (memoriaActual > vidRam)
                            {
                                vidRam = memoriaActual;
                            }
                        }
                    }
                }
            }

            if (ram != null)
            {
                ram.Update();
                foreach (ISensor sensor in ram.Sensors)
                {

                    if (sensor.SensorType == SensorType.Data && sensor.Name.Contains("Used"))
                    {
                        usoRam = sensor.Value ?? 0;
                    }

                }
            }
            
            string nombreCpu = "Nombre CPU no detectado";
            if (cpu != null) { nombreCpu = cpu.Name; }
            string nombreGpu = "Nombre GPU no detectado";
            if (gpus != null && gpus.Count > 0)
            {
                IHardware gpuAux = null;
                foreach (IHardware gpu in gpus)
                {
                    if (gpu.HardwareType == HardwareType.GpuNvidia)
                    {
                        gpuAux = gpu;
                        break;
                    }
                    if (gpu.HardwareType == HardwareType.GpuAmd && !gpu.Name.Contains("Graphics"))
                    {
                        gpuAux = gpu;
                        break;
                    }
                    if (gpu.HardwareType == HardwareType.GpuIntel && gpu.Name.Contains("Arc"))
                    {
                        gpuAux = gpu;
                        break;
                    }
                }
                if (gpuAux != null)
                {
                    nombreGpu = gpuAux.Name;
                }
                else
                {
                    nombreGpu = gpus[0].Name;
                }
            }
            
            return new MetricaSistema(nombreCpu, nombreGpu, usoCpu, tempCpu, usoGpu, tempGpu, vidRam, usoRam);
        }

    }
}
