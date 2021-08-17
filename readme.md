# Api para para depósito e saque em banco digital

API em C# com .NET Core que simula algumas funcionalidades de um banco digital. Projeto desenvolvido no Visual Studio 19.

## Cenários

DADO QUE eu consuma a API <br>
QUANDO eu chamar a mutation `sacar` informando o número da conta e um valor válido<br>
ENTÃO o saldo da minha conta no banco de dados diminuirá de acordo<br>
E a mutation retornará o saldo atualizado.

DADO QUE eu consuma a API <br>
QUANDO eu chamar a mutation `sacar` informando o número da conta e um valor maior do que o meu saldo<br>
ENTÃO a mutation me retornará um erro do GraphQL informando que eu não tenho saldo suficiente

DADO QUE eu consuma a API <br>
QUANDO eu chamar a mutation `depositar` informando o número da conta e um valor válido<br>
ENTÃO a mutation atualizará o saldo da conta no banco de dados<br>
E a mutation retornará o saldo atualizado.

DADO QUE eu consuma a API <br>
QUANDO eu chamar a query `saldo` informando o número da conta<br>
ENTÃO a query retornará o saldo atualizado.

## Dependências

- .NET Core 3.1
- GrapQL: HotChocolate.AspNetCore 11.3.4
- Microsoft.EntityFrameworkCore 5.0.9
- Microsoft.EntityFrameworkCore.SqlServer 5.0.9
- Microsoft.EntityFrameworkCore.Tools 5.0.9

## Execução

Com o projeto aberto no Visual Studio (se utilizar VS Code, verifique as equivalências dos comandos pelo dotnet CLI), compile o projeto.

### Configurando o banco

Abra o terminal do gereciador de pacotes  e exetute o comando 'update-database', para criar o banco e as tabelas. No SQL Server Manager, abra e execute os scripts da pasta DB no banco DigitalBank_DB. Isto irá preencher as tabelas com os dados para os testes.

### Executanto 

Execute o projeto no Visual Studio (run), isso irá abrir o navegador já com o framework Banana Cake do Hot Chocolate executanto. As queries podem ser executadas diretamente no navegador, pelo framework.

Exemplo de query do GraphQL

```
query{
  usuariosContas{
    name
    accounts{
      accountNumber
      accountValue
    }
  }
}
```

Resposta

```
{
  "data": {
    "usuariosContas": [
      {
        "name": "Maria",
        "accounts": [
          {
            "accountNumber": 4897,
            "accountValue": 50
          },
          {
            "accountNumber": 2547,
            "accountValue": 560
          }
        ]
      },
      ...
```

Transação

```
mutation{
  sacar(accountNumber:1568,takeAwayValue:806){
    accountValue
    accountNumber
    user{
      name
    }
  }
}
```

Resposta

```
{
  "data": {
    "sacar": {
      "accountValue": 4194,
      "accountNumber": 1568,
      "user": {
        "name": "Bob"
      }
    }
  }
}
```

Mensagens de erro

```
{
  "errors": [
    {
      "message": "Conta não encontrada!",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      ...
```
```{
  "errors": [
    {
      "message": "Valor inválido!",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
  ...
```
```
{
  "errors": [
    {
      "message": "Saldo insuficiente!",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
  ...
```