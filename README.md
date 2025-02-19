# API de Antecipação de Recebíveis

Esta API é a resolução do teste técnico do processo seletivo da Size Fintech (https\://github.com/pratesy/size-tecnico).

A API consiste no cadastro de empresas e notas fiscais para cálculo de antecipação de recebíveis com base no faturamento mensal e no ramo da empresa.

## 🚀 Tecnologias Utilizadas

- .NET 8 C#
- ASP.NET Web API
- Entity Framework Core
- SQL Server

## 🪄 Funcionalidades

- **Cadastro de Empresas**
- **Cadastro de Notas Fiscais**
- **Cálculo do Limite de Crédito**
- **Cálculo de Antecipação (Checkout)**

## 🔄 Fluxo da Aplicação

1. **Cadastro da Empresa**: A empresa deve ser cadastrada informando CNPJ, Nome, Faturamento Mensal e Ramo de Atuação.
2. **Cadastro de Notas Fiscais**: Após o cadastro da empresa, ela pode registrar notas fiscais informando Número, CNPJ da Empresa, Valor e Data de Vencimento.
3. **Gerenciamento do Carrinho**: A empresa pode adicionar ou remover notas fiscais do carrinho de antecipação.
4. **Cálculo da Antecipação**: Com base nas notas fiscais  e no limite de crédito da empresa, a API calcula o valor final de antecipação de cada nota e o valor total do carrinho.

## 🔗 Endpoints Principais

### 📌 Cadastrar Empresa

**POST** `/Empresa/cadastrar`

- Realiza o Cadastramento da Empresa.
- Aceita apenas um CNPJ por cadastro.

### 📌 Listar Empresas

**GET** `/Empresa/Listar`

- Retorna uma lista com todas as Empresas cadastradas no banco de dados.

### 📌 Cadastrar Nota Fiscal

**POST** `/NotaFiscal/Cadastrar`

- Realiza o Cadastramento da Nota Fiscal

### 📌 Remover Nota Fiscal

**POST** `/NotaFiscal/Remover/{numeroNotaFiscal}`

- Remove a Nota Fiscal do banco de dados utilizando o número da nota.

### 📌 Calcular Antecipação

**GET** `/CarrinhoAntecipacao/Calcular/{cnpj}`

- Realiza o cálculo de antecipação e retorna um JSON com o valor final de antecipação para cada nota e o valor total do carrinho da empresa selecionada baseando-se no CNPJ inserido no parâmetro da requisição.