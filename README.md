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
git clone https://github.com/seu-usuario/nome-do-repo.git
cd nome-do-repo
