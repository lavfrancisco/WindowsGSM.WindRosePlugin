using System;
using System.Diagnostics;
using System.Linq;
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
            version = "1.0.0",
            url = "https://github.com/lavfrancisco/WindowsGSM.WindRosePlugin",
            color = "#0763f7"
        };

        public override bool loginAnonymous => true;
        public override string AppId => "4129620"; 

        public WindRose(ServerConfig serverData) : base(serverData) => base.serverData = _serverData = serverData;
        private readonly ServerConfig _serverData;

        public override string StartPath => @"R5\Binaries\Win64\WindroseServer-Win64-Shipping.exe";
        public string FullName = "WindRose Dedicated Server";
        public bool AllowsEmbedConsole = true;
        public int PortIncrements = 1;
        public object QueryMethod = new A2S();

        public string Port = "7777";
        public string QueryPort = "27015";
        public string Defaultmap = "Default";
        public string Maxplayers = "16";
        public string Additional = "-log -nostatustext";

        public async Task<Process> Start()
        {
            await Task.Yield(); // Resolve o aviso de 'async lacks await'
            
            string shipExePath = Functions.ServerPath.GetServersServerFiles(_serverData.ServerID, StartPath);
            if (!File.Exists(shipExePath))
            {
                base.Error = $"{Path.GetFileName(shipExePath)} não encontrado";
                return null;
            }

            string param = $" {_serverData.ServerParam} -port={_serverData.ServerPort} -queryport={_serverData.ServerQueryPort} -maxplayers={_serverData.ServerMaxPlayer} -log -unbuffered";

            var p = new Process {
                StartInfo = {
                    WorkingDirectory = ServerPath.GetServersServerFiles(_serverData.ServerID),
                    FileName = shipExePath,
                    Arguments = param,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardOutput = AllowsEmbedConsole,
                    RedirectStandardError = AllowsEmbedConsole,
                    RedirectStandardInput = AllowsEmbedConsole
                },
                EnableRaisingEvents = true
            };

            if (AllowsEmbedConsole) {
                var serverConsole = new ServerConsole(_serverData.ServerID);
                p.OutputDataReceived += serverConsole.AddOutput;
                p.ErrorDataReceived += serverConsole.AddOutput;
            }

            try {
                p.Start();
                if (AllowsEmbedConsole) { p.BeginOutputReadLine(); p.BeginErrorReadLine(); }
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

        public new async Task<Process> Install()
        {
            var steamCMD = new Installer.SteamCMD();
            return await steamCMD.Install(_serverData.ServerID, string.Empty, AppId, true, loginAnonymous);
        }

        public new async Task<Process> Update(bool validate = false, string custom = null)
        {
            var (p, error) = await Installer.SteamCMD.UpdateEx(_serverData.ServerID, AppId, validate, custom: custom, loginAnonymous: loginAnonymous);
            return p;
        }

        public new bool IsInstallValid() => File.Exists(ServerPath.GetServersServerFiles(_serverData.ServerID, StartPath));
        public new bool IsImportValid(string path) => File.Exists(Path.Combine(path, StartPath));
        public new string GetLocalBuild() => new Installer.SteamCMD().GetLocalBuild(_serverData.ServerID, AppId);
        public new async Task<string> GetRemoteBuild() => await new Installer.SteamCMD().GetRemoteBuild(AppId);
            
        
    }
}