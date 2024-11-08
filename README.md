# OdontoPrev - Sistema de Gerenciamento e Detecção de Fraudes :computer:

## 📋 Definição do Projeto
### 🎯 Objetivo do Projeto
O objetivo deste projeto é desenvolver uma aplicação para a OdontoPrev, que gerencia operações diárias envolvendo Pacientes, Dentistas, Clínicas, Agendamentos, Tabela de Preços e Contas a Receber/Pagar. Além disso, o sistema detectará automaticamente possíveis fraudes financeiras e administrativas, facilitando a gestão e prevenindo atividades fraudulentas.

### 📐 Escopo
As funcionalidades principais incluem:

- **Gerenciamento de Pacientes, Dentistas e Clínicas, Agendamento, Contas, Tabela Preço e Fraude**: Cadastrar, visualizar, atualizar e excluir informações.
- **Agendamentos**: Registrar consultas entre pacientes e dentistas.
- **Contas a Receber/Pagar**: Gerenciar os pagamentos de consultas e procedimentos.
- **Detecção de Fraudes**: Identificar comportamentos suspeitos, como múltiplos agendamentos em períodos curtos e valores anormais em contas.

### 📝 Requisitos Funcionais
- CRUD completo para Pacientes, Dentistas, Clínicas, Agendamentos, Contas, Tabela Preço e Fraude.
- Consultas e visualização de relatórios de fraudes.

### 🛠️ Requisitos Não Funcionais
- Uso de **Clean Architecture** para modularidade e baixo acoplamento.
- Tratamento de erros e validação de dados.


## 🏛️ Desenho da Arquitetura
### Clean Architecture
O sistema segue os princípios da Clean Architecture, garantindo código organizado e modular. Cada camada possui responsabilidades bem definidas, facilitando a manutenção e escalabilidade.

### 🔍 Camadas da Aplicação

#### Apresentação
- Interface de usuário para interação com os serviços da aplicação.
- Design da home desenvolvido para melhor experiência do usuário.
- Separação da lógica de apresentação da lógica de negócio para simplificar futuras mudanças.

#### Aplicação
- Implementa os serviços e casos de uso, conectando a interface de usuário às regras de negócio.

#### Domínio
- Modelos principais do sistema, como Paciente, Dentista, Clínica, Agendamento, Contas a Receber/Pagar, Tabela Preço e Fraude.

#### Infraestrutura
- Gerencia o acesso aos dados com **Entity Framework Core** para mapeamento de entidades e conexão ao banco de dados.
- **Migrations** para criação de tabelas.
- **Task e Async** aplicados em componentes do programa para melhor desempenho.
- Uso do pacote **Oracle** para acesso ao banco de dados.

---

## ⚙️ Instruções de Instalação e Configuração

### Pré-requisitos
- .NET Core SDK
- Entity Framework Core
- Banco de Dados Oracle e driver
- Visual Studio / Visual Studio Code

### Passo a Passo

# OdontoPrev - Sistema de Gerenciamento e Detecção de Fraudes

## Instruções de Instalação e Configuração

1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/ThaiisRibeiro/ProjetoChallangeOdontoprevSprint2
   cd ProjetoChallangeOdontoprevSprint2
   ```

2. **Configuração do Banco de Dados:**
   - Crie o banco de dados no Oracle.
   - Configure a string de conexão no arquivo `Context` e `Program` da aplicação:
     
     ```csharp
     private string GetStringConectionConfig()
     {
         string strCon = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=;Password=;";
         return strCon;
     }
     ```

3. **Aplicação das Migrations:**
   - Execute as migrations para criar as tabelas necessárias:
     ```bash
     Add-Migration Nome_do_seu_BD
     Update-Database Nome_do_seu_BD
     ```

4. **Executar a Aplicação:**
   - Inicie o servidor com:
     ```bash
     dotnet run
     ```

---

## 🛠️ Tecnologias Utilizadas
- **.NET Core** para desenvolvimento back-end.
- **Entity Framework Core** para mapeamento de dados.
- **Oracle Database** para armazenamento.
- **Clean Architecture** para modularidade e manutenção do código.

---

Desenvolvido para facilitar a gestão e prevenir fraudes, promovendo eficiência e segurança para a OdontoPrev.

