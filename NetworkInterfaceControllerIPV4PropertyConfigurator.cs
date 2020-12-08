using System;
using System.Diagnostics;

namespace culs_library
{
    public class NetworkInterfaceControllerIPV4PropertyConfigurator
    {

        public static void SetStaticIPV4LocalAddress(String interfaceName, String ip, String mask, String gateway)
        {
            ExecuteCommand("/c netsh interface ip set address \"" + interfaceName + "\" static " + ip + " " + mask + " " + gateway);
        }

        public static void SetDHCPIPV4LocalAddress(String interfaceName)
        {
            ExecuteCommand("/c netsh interface ip set address \"" + interfaceName + "\" dhcp ");
        }

        private static void ExecuteCommand(String command)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                psi.UseShellExecute = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.Verb = "runas";
                psi.Arguments = command;
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}