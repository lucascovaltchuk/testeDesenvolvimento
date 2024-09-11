
# Teste Desenvolvimento

Este projeto é uma aplicação web em C# utilizando ASP.NET Core.

## Pré-requisitos

- .NET 6.0 SDK ou superior: [Instalar .NET SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio 2022 ou superior (recomendado) com os seguintes workloads instalados:
- ASP.NET e desenvolvimento web
- Desenvolvimento com .NET Core
- Banco de dados SQLite (já incluso no projeto com o arquivo `app.db`).

## Como rodar o projeto localmente

1. Clone ou baixe este repositório para sua máquina local.

2. Abra o projeto no Visual Studio:
    - Localize o arquivo da solução `WebAppTestFull.sln` e abra com o Visual Studio.

3. Restaurar pacotes NuGet:
    - No Visual Studio, navegue até o menu **Ferramentas** > **Gerenciador de Pacotes NuGet** > **Gerenciar Pacotes NuGet para a Solução** e clique em **Restaurar**.

4. Aplicar Migrações:
    - No terminal do Visual Studio (Menu **Exibir** > **Outras Janelas** > **Console do Gerenciador de Pacotes**), execute o seguinte comando para aplicar as migrações ao banco de dados SQLite:
    ```bash
    Update-Database
    ```

5. Rodar a aplicação:
    - Pressione **F5** ou clique no botão de execução no Visual Studio para rodar o projeto.

6. Acessar a aplicação:
    - Após rodar a aplicação, ela estará disponível no navegador em: `https://localhost:5001` ou `http://localhost:5000`.

## Notas

- A aplicação está configurada para utilizar um banco de dados SQLite localizado em `app.db`.
- Certifique-se de que todas as dependências estão devidamente restauradas antes de executar o projeto.
