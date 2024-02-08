# Controle de clientes

Aplicação para gerenciamento de clientes construido com ASP.NET (.NET 8), seguindo padrão MVC com conexão a banco de dados SqlServer.

## Rodando a aplicação no seu PC

Faça um clone deste repositório em seu ambiente de desenvolvimento:

```
git clone https://github.com/Arnaldo-PS/api-vendas.git
```

Após clonar o conteúdo do repositório e executar a solução, realize o download das dependências do projeto, executando este comando no Package Manager Console:
```
dotnet restore
```

Após o download, adapte as configurações de banco no arquivo appsettings.json e realize as migrations através dos comandos:

```
Add-Migration NomeDaMigracaoInicial -Context BancoContext
```
```
Update-DataBase -Context BancoContext
```
