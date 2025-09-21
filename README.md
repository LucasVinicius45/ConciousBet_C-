# ConsciousBet - Sistema de Gerenciamento de Apostas

Sistema de gerenciamento de apostas desenvolvido em C# com Windows Forms e MySQL, implementando operações CRUD completas para usuários e apostas.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
- [Como Usar](#como-usar)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Segurança](#segurança)
- [Contribuição](#contribuição)

## 🎯 Sobre o Projeto

ConsciousBet é uma aplicação desktop desenvolvida para gerenciar usuários e apostas, oferecendo uma interface intuitiva para operações de CRUD (Create, Read, Update, Delete). O sistema inclui recursos de segurança como criptografia de senhas e validações de dados.

### Características Principais

- **CRUD Completo**: Operações de criação, leitura, atualização e exclusão para usuários e apostas
- **Interface Gráfica**: Windows Forms com navegação intuitiva
- **Segurança**: Senhas criptografadas com BCrypt
- **Persistência de Dados**: Integração com MySQL e opção de exportação para JSON
- **Validações**: Verificação de dados de entrada e regras de negócio

## ⚡ Funcionalidades

### Gerenciamento de Usuários
- ✅ Cadastrar novos usuários
- ✅ Visualizar lista de usuários
- ✅ Editar dados de usuários existentes
- ✅ Excluir usuários com confirmação
- ✅ Validação de emails únicos
- ✅ Criptografia segura de senhas

### Gerenciamento de Apostas
- ✅ Cadastrar novas apostas
- ✅ Visualizar histórico de apostas
- ✅ Editar apostas existentes
- ✅ Excluir apostas com confirmação
- ✅ Associar apostas a usuários
- ✅ Estatísticas por usuário

### Recursos Adicionais
- ✅ Interface organizada com GroupBox
- ✅ Formatação de valores monetários
- ✅ Exportação de dados para JSON
- ✅ Tratamento de erros robusto

## 🛠 Tecnologias Utilizadas

- **Linguagem**: C# (.NET Framework)
- **Interface**: Windows Forms
- **Banco de Dados**: MySQL
- **ORM**: ADO.NET com MySql.Data
- **Criptografia**: BCrypt.Net-Next
- **Serialização**: Newtonsoft.Json

## 📋 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- [Visual Studio 2019+](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [.NET Framework 4.7.2+](https://dotnet.microsoft.com/download/dotnet-framework)
- [MySQL Server 8.0+](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) (opcional, para gerenciar o banco)

## 🚀 Instalação

### 1. Clonar o Repositório
```bash
https://github.com/LucasVinicius45/ConsciousBet_Csharp.git
cd consciousbet_Csharp
```

### 2. Instalar Dependências NuGet
Abra o projeto no Visual Studio e instale os seguintes pacotes via NuGet Package Manager:

```
MySql.Data
BCrypt.Net-Next
Newtonsoft.Json
```

Ou via Package Manager Console:
```powershell
Install-Package MySql.Data
Install-Package BCrypt.Net-Next
Install-Package Newtonsoft.Json
```

### 3. Configurar String de Conexão
Edite o arquivo `Utils/Database.cs` e ajuste a string de conexão:

```csharp
private static string connectionString = "server=localhost;database=aposta;user=root;password=SUA_SENHA;";
```

## 🗄 Configuração do Banco de Dados

### 1. Criar o Banco de Dados
Execute o script SQL fornecido no MySQL:

```sql
-- Criação do banco de dados
CREATE DATABASE IF NOT EXISTS aposta CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE aposta;

-- Dropar tabelas existentes (se existirem)
DROP TABLE IF EXISTS Aposta;
DROP TABLE IF EXISTS Usuario;

-- Tabela de Usuários
CREATE TABLE Usuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL,
    DataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Apostas
CREATE TABLE Aposta (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Valor DECIMAL(10, 2) NOT NULL,
    Resultado VARCHAR(200) NOT NULL,
    UsuarioId INT NOT NULL,
    DataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id) ON DELETE CASCADE
);

-- Índices para melhorar performance
CREATE INDEX idx_usuario_email ON Usuario(Email);
CREATE INDEX idx_aposta_usuario ON Aposta(UsuarioId);
CREATE INDEX idx_aposta_data ON Aposta(DataCriacao);
```

### 2. Dados de Exemplo (Opcional)
```sql
-- Usuários de exemplo (senhas: admin123, 123456, maria123)
INSERT INTO Usuario (Nome, Email, Senha) VALUES 
('Administrador', 'admin@consciousbet.com', '$2a$11$N9qo8uLOickgx2ZMRZoMye.Uo5dHW.Z5pC4HQDVrXr7lZXz3nOFGi'),
('João Silva', 'joao@email.com', '$2a$11$K5qw9rZMkTv3G8nPLxR1DeW5pV8rHc3qYsN2oW4gFrT7uP9eR2tBm'),
('Maria Santos', 'maria@email.com', '$2a$11$M7sY1wQcVnP8HzR2NxB4FeR3gT7uI9oP2qW5eY8rT3nL6vB9dC1Kj');

-- Apostas de exemplo
INSERT INTO Aposta (Valor, Resultado, UsuarioId) VALUES 
(50.00, 'Vitória do Palmeiras', 2),
(100.00, 'Empate - Corinthians x Santos', 2),
(25.50, 'Mais de 2.5 gols', 3),
(75.00, 'Vitória do Flamengo', 3);
```

## 📖 Como Usar

### 1. Executar a Aplicação
- Abra o projeto no Visual Studio
- Compile e execute (F5)
- A tela principal será exibida com opções de menu

### 2. Gerenciar Usuários
- Clique em "Gerenciar Usuários"
- Use "Novo" para limpar campos
- Preencha os dados e clique "Salvar (Novo)"
- Selecione uma linha para editar ou excluir
- Use "Atualizar" para salvar alterações
- Use "Excluir" para remover (com confirmação)

### 3. Gerenciar Apostas
- Clique em "Gerenciar Apostas"
- Selecione um usuário no combo box
- Preencha valor e resultado
- Use "Salvar" para nova aposta
- Selecione linha para editar/excluir
- Use "Estatísticas" para ver dados do usuário

## 📁 Estrutura do Projeto

```
ConsciousBet/
├── DAO/                    # Data Access Objects
│   ├── ApostaDAO.cs       # CRUD de apostas
│   └── UsuarioDAO.cs      # CRUD de usuários
├── Model/                 # Classes de modelo
│   ├── Aposta.cs         # Entidade Aposta
│   └── Usuario.cs        # Entidade Usuario
├── UI/                   # Interface do usuário
│   ├── Form1.cs          # Tela principal
│   ├── ApostasForm.cs    # Gerenciar apostas
│   ├── UsuariosForm.cs   # Gerenciar usuários
│   └── LoginForm.cs      # Tela de login (opcional)
├── Utils/                # Utilitários
│   ├── Database.cs       # Conexão com banco
│   ├── FileManager.cs    # Manipulação de JSON
│   └── PasswordHelper.cs # Criptografia de senhas
└── Program.cs            # Ponto de entrada
```

## 🔒 Segurança

- **Senhas Criptografadas**: Utiliza BCrypt com salt automático
- **Validação de Entrada**: Verificação de dados antes de persistir
- **SQL Injection Protection**: Uso de parâmetros nas queries
- **Validação de Email**: Verificação de formato e unicidade

---
---
## 📊 Diagramas do Projeto

### Arquitetura
[🔗 Ver Arquitetura](documentos/img/diagrama.png)

---

## 👤 Autores

- **Irana Pereira** – RM98593
- **Lucas Vinicius** – RM98480
- **Mariana Melo** – RM98121
- **Mateus Iago** – RM550270

---

**Nota**: Este projeto foi desenvolvido como trabalho acadêmico para demonstrar conhecimentos em desenvolvimento C#, banco de dados e arquitetura de software.
