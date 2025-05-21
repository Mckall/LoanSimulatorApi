# 📊 API de Simulação de Empréstimos com Tabela Price (.NET 6)

Esta API calcula o cronograma de pagamentos de um empréstimo com base no método de amortização **Tabela Price**. Desenvolvida em .NET 6, armazena os dados no SQL Server e expõe um endpoint via Swagger.

---

## ✅ Funcionalidades

- Recebe valores de empréstimo, juros e meses
- Calcula parcela fixa, total de juros e cronograma detalhado
- Retorna os dados via JSON
- Salva os dados no banco de dados (tabelas `Proposta` e `PaymentFlowSummary`)
- Documentação integrada via Swagger

---

## 🚀 Como Rodar o Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/Mckall/LoanSimulatorApi.git
```

### 2. Configure o Banco de Dados

Crie um banco de dados SQL Server chamado `LoanDb`.

Você pode executar o seguinte script:

```sql
CREATE DATABASE LoanDb;
```

### 3. Atualize a `ConnectionString`

No arquivo `appsettings.json`, edite a string de conexão:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LoanDb;Trusted_Connection=True;"
}
```

> 🔐 Para conexões com autenticação SQL, use:
> `"Server=localhost;Database=LoanDb;User Id=seu_usuario;Password=sua_senha;"`

---

### 4. Instale os pacotes necessários

Certifique-se de instalar os pacotes NuGet com:

```bash
dotnet restore
```

---

### 5. Crie o banco com EF Core

Execute os comandos:

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 6. Rode a API

```bash
dotnet run
```

Acesse no navegador:

```
https://localhost:5001/swagger
```

---

## 📬 Endpoint

### `POST /api/loans/simulate`

#### 🔸 Corpo da Requisição (JSON)

```json
{
  "loanAmount": 50000,
  "annualInterestRate": 0.12,
  "numberOfMonths": 24
}
```

#### 🔹 Resposta (JSON)

```json
{
  "monthlyPayment": 2364.50,
  "totalInterest": 6748.00,
  "totalPayment": 56748.00,
  "paymentSchedule": [
    {
      "month": 1,
      "principal": 1864.50,
      "interest": 500.00,
      "balance": 48135.50
    }
    // ...
  ]
}
```

---

## 🧱 Estrutura das Tabelas

### 🟩 Proposta

| Campo             | Tipo       |
|------------------|------------|
| Id               | int (PK)   |
| LoanAmount       | decimal    |
| AnnualInterestRate | float    |
| NumberOfMonths   | int        |
| CreatedAt        | datetime   |

### 🟦 PaymentFlowSummary

| Campo             | Tipo       |
|------------------|------------|
| Id               | int (PK)   |
| PropostaId       | int (FK)   |
| MonthlyPayment   | decimal    |
| TotalInterest    | decimal    |
| TotalPayment     | decimal    |
| PaymentScheduleJson | nvarchar(max) |

---

## 🛠 Requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server (local ou remoto)
- Visual Studio ou VS Code

---

## 📚 Observações

- A API segue arquitetura em camadas: `Controller`, `Service`, `Model`, `Data`
- Swagger UI está disponível no caminho `/swagger`
- Requisições inválidas retornam `400 BadRequest`

---

## 🧑‍💻 Autor

Desenvolvido por [Seu Nome] - [email@dominio.com] - Ribeirão Preto/SP