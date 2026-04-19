# WindowsGSM.WindRose

[English](#english) | [Português](#português)

---

## English

Plugin for **WindRose** Dedicated Server support in WindowsGSM.

### Author
* **Luiz Francisco**

### Download
You can download the latest stable version here:
**[Download WindRose Plugin v1.0.0](https://github.com/lavfrancisco/WindowsGSM.WindRosePlugin/releases/download/v1.0.0/WindowsGSM.WindRose.zip)**

### Option 1: Manual Installation (Recommended)

The WindowsGSM automatic installer may encounter naming errors (e.g., `zip.cs`). To ensure it works correctly, follow these steps:

1. Navigate to the folder where your **WindowsGSM.exe** is installed.
2. Open the `plugins` folder.
3. Create a new folder named exactly **`WindRose.cs`**.
4. Download the `WindRose.cs` file (and the images) from this repository and place them inside that folder.
5. Restart WindowsGSM.

**Correct folder structure:**
`WindowsGSM/plugins/WindRose.cs/WindRose.cs`

### Option 2: Import via Interface (Automatic)

If you downloaded the structured `.zip` file, you can use the built-in WindowsGSM installer:

1. In WindowsGSM, click the **Plugins** icon (puzzle piece) on the left sidebar.
2. Click the **Import** button at the top of the window.
3. Select the `WindRose.zip` file.
4. WindowsGSM will automatically extract the files to the correct folder.
5. **Restart WindowsGSM** for the plugin to appear in the available servers list.

> **Note:** If the server does not appear after importing, verify that the folder `plugins/WindRose.cs` contains the `WindRose.cs` file directly inside it.

### Features
- [x] Install and Update via SteamCMD (AppID: 4129620).
- [x] Console Redirect (Real-time logs).
- [x] Auto-Restart on crash.
- [x] Integrated native backup.

---

## Português

Plugin para suporte ao servidor dedicado de **WindRose** no WindowsGSM.

### Autor
* **Luiz Francisco** ### Download
Você pode baixar a versão mais recente e estável aqui:
**[Baixar WindRose Plugin v1.0.0](https://github.com/lavfrancisco/WindowsGSM.WindRosePlugin/releases/download/v1.0.0/WindowsGSM.WindRose.zip)**

### Opção 1: Instalar (Manual)

O instalador automático do WindowsGSM pode apresentar erros de nomenclatura (ex: `zip.cs`). Para garantir o funcionamento, siga estes passos:

1. Vá até a pasta onde o seu **WindowsGSM.exe** está instalado.
2. Abra a pasta `plugins`.
3. Crie uma nova pasta chamada exatamente **`WindRose.cs`**.
4. Baixe o arquivo `WindRose.cs` (e as imagens) deste repositório e coloque-os dentro dessa pasta.
5. Reinicie o WindowsGSM.

**Estrutura de pastas correta:**
`WindowsGSM/plugins/WindRose.cs/WindRose.cs`

### Opção 2: Importação via Interface (Automática)

Se você baixou o arquivo `.zip` estruturado, pode usar o instalador do próprio WindowsGSM:

1. No WindowsGSM, clique no ícone de peça de quebra-cabeça (**Plugins**) na barra lateral esquerda.
2. Clique no botão **Import** localizado no topo da janela.
3. Selecione o arquivo `WindRose.zip` (ou o nome que você deu ao arquivo de release).
4. O WindowsGSM irá extrair os arquivos automaticamente para a pasta correta.
5. **Reinicie o WindowsGSM** para que o plugin apareça na lista de servidores disponíveis.

> **Nota:** Se após a importação o servidor não aparecer, verifique se a pasta em `plugins/WindRose.cs` contém o arquivo `WindRose.cs` diretamente nela.

### Funcionalidades
- [x] Instalação e Update via SteamCMD (AppID: 4129620).
- [x] Console Redirect (Logs em tempo real).
- [x] Auto-Restart em caso de crash.
- [x] Backup nativo integrado.
