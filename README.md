# TDE

- Instalar [Visual Studio Code](https://code.visualstudio.com/docs/?dv=win).
- Instalar [SDK do .NET Core](https://download.visualstudio.microsoft.com/download/pr/475b587c-e586-4187-8feb-a602f3c6b449/b82433e88760e76d2ab591530e0784b9/dotnet-sdk-5.0.300-win-x64.exe
).
- Com o Visual Studio Code aberto Aperte ```Ctrl+Shift+X``` isso abrirá a aba de extensões. 
- Digite **Ionide-fsharp** na caixa de busca e intale a extensão como na imagem abaixo:

![bd07c97f-4b0e-481d-9893-7bbde24a5935](https://user-images.githubusercontent.com/81246770/121075876-18d75680-c7ac-11eb-923a-c2996fe0c09f.jpg)

- Reinicie o Visual Studio Code.
- Pelo Explorador de Arquivos acesse `C:\Users\<seu_usuario>\AppData\Roaming\NuGet` e terá um arquivo chamado **NuGet.Config**.
- Abra-o com o Visual Studio Code, apague todo o conteúdo e insira o seguinte xml:
```<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
```

- Aperte `Ctrl+S`
- Baixe o **TDE.rar**, decompacte o arquivo para a sua máquina e arraste a pasta para o Visual Studio Code.
- Agora aperte `Ctrl+'`
- Dentro do terminal digite:
```
cd TDE
```
- Até que o caminho seja `"...\TDE\TDE"`, que contém o arquivo Program.fs dentro.
- Depois digite:

```
dotnet run
```
