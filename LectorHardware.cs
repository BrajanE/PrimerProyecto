using LibreHardwareMonitor.Hardware;

namespace PrimerProyecto
{
    public class LectorHardware
    {
        private Computer pcMasterRace;

        public LectorHardware()
        {
            pcMasterRace = new Computer();
            pcMasterRace.IsCpuEnabled = true;
            pcMasterRace.IsGpuEnabled = true;
            pcMasterRace.IsMemoryEnabled = true;
            pcMasterRace.Open();
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

            foreach (IHardware componente in pcMasterRace.Hardware)
            {
                componente.Update();
                switch (componente.HardwareType)
                {
                    case HardwareType.Cpu:
                        foreach (ISensor sensor in componente.Sensors)
                        {

                            if (sensor.SensorType == SensorType.Load)
                            {
                                if (sensor.Name.Contains("Total"))
                                {
                                    usoCpu = sensor.Value ?? 0;
                                }
                            }
                            if (sensor.SensorType == SensorType.Temperature && (sensor.Name.Contains("Package") || sensor.Name.Contains("Core")))
                            {
                                tempCpu = sensor.Value ?? 0;
                            }

                        }
                        break;
                    case HardwareType.GpuNvidia:
                    case HardwareType.GpuAmd:
                    case HardwareType.GpuIntel:
                        foreach (ISensor sensor in componente.Sensors)
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

                                tempGpu = sensor.Value ?? 0;


                            }
                       
                            if (sensor.Name.Contains("Used") && (sensor.Name.Contains("Memory") || sensor.Name.Contains("VRAM")) && !sensor.Name.Contains("Shared"))
                            {

                                float valorLeido = 0;
                                if (sensor.SensorType == SensorType.Data)
                                {
                                    valorLeido = sensor.Value ?? 0;
                                }
                                else if (sensor.SensorType == SensorType.SmallData && sensor.Name == "GPU Memory Used")
                                {
                                    valorLeido = (sensor.Value ?? 0) / 1024;
                                }
                                if (valorLeido > vidRam)
                                {
                                    vidRam = valorLeido;
                                }
                            }
                        }
                            break;
                    case HardwareType.Memory:
                                foreach (ISensor sensor in componente.Sensors)
                                {

                                    if (sensor.SensorType == SensorType.Data && sensor.Name.Contains("Used"))
                                    {
                                        usoRam = sensor.Value ?? 0;
                                    }

                                }
                                break;


                            }

                        }
                        return new MetricaSistema(usoCpu, tempCpu, usoGpu, tempGpu, vidRam, usoRam);
                }
            }
        }
