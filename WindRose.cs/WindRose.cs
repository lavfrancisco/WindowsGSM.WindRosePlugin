using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WindowsGSM.Functions;
using WindowsGSM.GameServer.Query;
using WindowsGSM.GameServer.Engine;
using System.IO;

namespace WindowsGSM.Plugins
{
    public class WindRose : SteamCMDAgent
    {
        public Plugin Plugin = new Plugin
        {
            name = "WindowsGSM.WindRose", 
            author = "Luiz Francisco",
            description = "WindowsGSM plugin for supporting WindRose Dedicated Server",
            version = "1.0.3", // Incrementei a versão
            url = "https://github.com/lavfrancisco/WindowsGSM.WindRosePlugin",
            color = "#0763f7"
        };

        public override bool loginAnonymous => true;
        public override string AppId => "4129620"; 

        private readonly ServerConfig _serverData;
        public WindRose(ServerConfig serverData) : base(serverData) => _serverData = serverData;

        public override string StartPath => @"R5\Binaries\Win64\WindroseServer-Win64-Shipping.exe";
        public string FullName = "WindRose Dedicated Server";
        
        // Default values for the UI
        public string Port = "7777";
        public string QueryPort = "27015";
        public string Defaultmap = "Default";
        public string Maxplayers = "16";
        // REMOVIDO o -log daqui para não duplicar se o usuário colocar no Start Param
        public string Additional = "-log -nostatustext"; 

        public async Task<Process> Start()
        {
            await Task.Yield();
            string shipExePath = ServerPath.GetServersServerFiles(_serverData.ServerID, StartPath);
            
            if (!File.Exists(shipExePath))
            {
                base.Error = $"{Path.GetFileName(shipExePath)} not found";
                return null;
            }

            // Removido o -log e -unbuffered fixos. Agora usa o que vem do serverData.ServerParam (Additional)
            string param = $" {_serverData.ServerParam} -port={_serverData.ServerPort} -queryport={_serverData.ServerQueryPort} -maxplayers={_serverData.ServerMaxPlayer}";

            var p = new Process {
                StartInfo = {
                    WorkingDirectory = ServerPath.GetServersServerFiles(_serverData.ServerID),
                    FileName = shipExePath,
                    Arguments = param,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = true
            };

            var serverConsole = new ServerConsole(_serverData.ServerID);
            p.OutputDataReceived += serverConsole.AddOutput;
            p.ErrorDataReceived += serverConsole.AddOutput;

            try {
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                return p;
            } catch (Exception e) { base.Error = e.Message; return null; }
        }

        public async Task Stop(Process p)
        {
            await Task.Run(() => {
                if (p == null || p.HasExited) return;
                p.CloseMainWindow();
                if (!p.WaitForExit(5000)) p.Kill();
            });
        }

        public bool CanBackup => true;
        // O método Backup() foi removido para usar o nativo da SteamCMDAgent (Full Backup),
        // evitando confusão sobre o RocksDB que ainda não está implementado via script.
    }
}
