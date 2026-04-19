# WindowsGSM.WindRose
Plugin para suporte ao servidor dedicado de **WindRose** no WindowsGSM.

## Autor
* **Luiz Francisco** ([VemJogar](https://github.com/lavfrancisco))

## Download
Você pode baixar a versão mais recente e estável aqui:
**[Baixar WindRose Plugin v1.0.0](https://github.com/lavfrancisco/WindowsGSM.WindRosePlugin/releases/tag/v1.0.0)**

## Opção 1: Instalar (Manual)

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

## Funcionalidades
- [x] Instalação e Update via SteamCMD (AppID: 4129620).
- [x] Console Redirect (Logs em tempo real).
- [x] Auto-Restart em caso de crash.
- [x] Backup nativo integrado.


