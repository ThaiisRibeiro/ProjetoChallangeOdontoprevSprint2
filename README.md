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
- Responsividade e eficiência no processamento de fraudes.

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

1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/usuario/odontoprev-sistema-fraudes.git
   cd odontoprev-sistema-fraudes
   ```

2. **Configuração do Banco de Dados:**
   - Crie o banco de dados no Oracle.
   - Configure a string de conexão no arquivo `appsettings.json` da aplicação:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=Oracle_DB;User Id=usuario;Password=senha;"
     }
     ```

3. **Aplicação das Migrations:**
   - Execute as migrations para criar as tabelas necessárias:
     ```bash
     dotnet ef database update
     ```

4. **Executar a Aplicação:**
   - Inicie o servidor com:
     ```bash
     dotnet run
     ```

5. **Acessar a Aplicação:**
   - Acesse a aplicação via navegador no endereço `http://localhost:5000`.

---

## 🌐 Interface
- **Interface de Monitoramento de Fraudes**: Exibe em tempo real informações sobre comportamentos suspeitos.
- **Interface de Configuração de Alertas**: Permite a configuração de alertas automáticos para atividades suspeitas.
- **Interface de Controle de Acesso**: Login e gestão de permissões de usuários.

---

## 🛠️ Tecnologias Utilizadas
- **.NET Core** para desenvolvimento back-end.
- **Entity Framework Core** para mapeamento de dados.
- **Oracle Database** para armazenamento.
- **Clean Architecture** para modularidade e manutenção do código.

---

Desenvolvido para facilitar a gestão e prevenir fraudes, promovendo eficiência e segurança para a OdontoPrev.
