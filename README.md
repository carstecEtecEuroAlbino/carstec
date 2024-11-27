# Carstec

**Carstec** é um projeto desenvolvido por alunos da ETEC Euro Albino de Souza, simulando um sistema de aluguel de carros para uma empresa fictícia. O sistema possui módulos tanto para os clientes quanto para os administradores, permitindo o gerenciamento de veículos, clientes, agendamentos, e outras funcionalidades necessárias para o funcionamento de uma locadora de carros.

## Funcionalidades

### Módulo do Cliente
- **Lista de Veículos**: Visualização dos veículos disponíveis para locação.
- **Histórico de Agendas**: Acompanhamento de todos os agendamentos passados e futuros do cliente.
- **Agendamento de Veículos**: Realização de agendamentos para locação de veículos.
  
### Módulo do Administrador
- **Lista de Veículos**: Visualização dos veículos cadastrados na locadora.
- **Lista de Agendas**: Visualização de todos os agendamentos realizados pelos clientes.
- **Lista de Administradores**: Visualização dos administradores cadastrados no sistema.
- **Lista de Clientes**: Visualização dos clientes cadastrados na locadora.
- **Cadastro de Administradores e Clientes**: Permite o cadastro e gestão de administradores e clientes.

## Como Rodar o Projeto

### Pré-requisitos
- .NET Framework (para rodar o projeto em C#)
- MySQL (para rodar o banco de dados)
- Ambiente de desenvolvimento (Visual Studio, VS Code ou outra IDE de sua preferência)

### Passos
1. Clone o repositório do projeto no seu ambiente local.
2. Certifique-se de que o MySQL está instalado e rodando no seu sistema.
3. **Importe o Banco de Dados**:
   - No diretório do projeto, na pasta "Banco de dados" você encontrará um arquivo SQL (`carstec.sql`).
   - Acesse seu gerenciador de banco de dados (MySQL Workbench, phpMyAdmin, etc.).
   - Crie um banco de dados com o nome `carstec`.
   - Importe o arquivo SQL para popular o banco de dados com as tabelas e dados necessários.
4. Abra o projeto no Visual Studio e compile-o para gerar o executável.
5. Execute o sistema e aproveite suas funcionalidades.

## Alunos e Tarefas

### [Caio Raphael Rangel](https://github.com/caiopa3)
- [x] Criação do banco de dados.
- [x] Lista de veículos no módulo do cliente.
- [x] Histórico de agendas no módulo do cliente.
- [x] Lista de veículos no módulo do administrador.
- [x] Lista de agendas no módulo do administrador.
- [x] Lista de administradores no módulo do administrador.
- [x] Lista de clientes no módulo do administrador.
- [x] Sair da conta do cliente no módulo do cliente.

### [Giovani Depiéri Santos](https://github.com/Maracaruja)
- [x] Entrada do cliente.
- [x] Cadastro do cliente.
- [x] Cadastro do administrador.
- [x] Entrada do administrador.
- [ ] Cadastro de veículos no módulo administrador.

### [João Felipe Francisco Moreira](https://github.com/joaofelipe80)
- [x] Criação do banco de dados.
- [x] Agendamento de veículos no módulo do cliente.
- [x] Alterar agenda no módulo do administrador.
- [x] Excluir agenda no módulo do administrador.
- [x] Exclusão do administrador.
      
### [Venicius Ferraz de Aráujo](https://github.com/venicius-braco)
- [ ] Alteração dos carros no módulo do administrador.
- [ ] Exclusão dos carros no módulo do administrador.
- [ ] Alteração do cliente no módulo cliente.
- [x] Alteração do cliente no módulo administrador.
- [x] Exclusão do cliente no módulo administrador.

---
