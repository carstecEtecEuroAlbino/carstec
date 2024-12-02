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


## Tecnologias Utilizadas
- **C#** com Windows Forms para a interface do usuário.
- **MySQL** para o gerenciamento do banco de dados.
- **Visual Studio** como IDE principal.

## Como Rodar o Projeto

### Pré-requisitos
- .NET Framework (para rodar o projeto em C#)
- MySQL (para rodar o banco de dados)
- Ambiente de desenvolvimento (Visual Studio, VS Code ou outra IDE de sua preferência)

### Passos
1. **Clone o repositório**
   Abra o terminal ou prompt de comando e execute:
   ```bash
   git clone https://github.com/usuario/carstec.git
2. Certifique-se de que o MySQL está instalado e rodando no seu sistema.
3. **Importe o Banco de Dados**:
   - No diretório do projeto, na pasta "Banco de dados" você encontrará um arquivo SQL (`carstec.sql`).
   - Acesse seu gerenciador de banco de dados (MySQL Workbench, phpMyAdmin, etc.).
   - Crie um banco de dados com o nome `carstec`.
   - Importe o arquivo SQL para popular o banco de dados com as tabelas e dados necessários.
4. Abra o projeto no Visual Studio e compile-o para gerar o executável.
5. Execute o sistema e aproveite suas funcionalidades.

# Histórias de Usuário

## Módulo do Cliente

1. **Visualizar Veículos Disponíveis**  
   *Como cliente, quero visualizar uma lista de veículos disponíveis para locação, para escolher o que melhor atende às minhas necessidades.*

2. **Agendar Locação de Veículo**  
   *Como cliente, quero agendar a locação de um veículo, para garantir que ele estará disponível na data e horário que preciso.*

3. **Cancelar Agendamento**  
   *Como cliente, quero cancelar um agendamento antes da data da locação, caso não precise mais do veículo.*

4. **Verificar Histórico de Locação**  
   *Como cliente, quero visualizar meu histórico de locações passadas e agendamentos futuros, para acompanhar meus registros e planejar futuras locações.*

7. **Sair da Conta**  
   *Como cliente, quero sair da minha conta, para proteger minhas informações quando terminar de usar o sistema.*

---

## Módulo do Administrador

1. **Visualizar Lista de Veículos**  
   *Como administrador, quero visualizar todos os veículos cadastrados no sistema, para acompanhar quais estão disponíveis para locação.*

2. **Adicionar Novo Veículo**  
   *Como administrador, quero adicionar novos veículos ao sistema, para ampliar a frota disponível para locação.*

3. **Editar Informações de Veículo**  
   *Como administrador, quero editar as informações de um veículo (modelo, ano, etc.), para manter o sistema atualizado.*

4. **Remover Veículo**  
   *Como administrador, quero remover veículos que não estão mais disponíveis para locação, para evitar confusão na lista de veículos.*

5. **Visualizar Lista de Agendamentos**  
   *Como administrador, quero visualizar todos os agendamentos feitos pelos clientes, para monitorar as locações ativas e futuras.*

6. **Alterar Informações de Agendamento**  
   *Como administrador, quero alterar informações de um agendamento (datas, status, etc.), caso o cliente solicite ou haja necessidade.*

7. **Cancelar Agendamento**  
   *Como administrador, quero cancelar um agendamento, caso o cliente desista ou não cumpra os requisitos para a locação.*

8. **Visualizar Lista de Clientes**  
   *Como administrador, quero visualizar todos os clientes cadastrados no sistema, para acompanhar quem utiliza o serviço.*

9. **Editar Informações de Cliente**  
   *Como administrador, quero editar informações do perfil de um cliente (nome, telefone, etc.), caso necessário.*

10. **Excluir Cliente**  
    *Como administrador, quero excluir um cliente do sistema, caso ele não seja mais ativo ou tenha violado as políticas da empresa.*

11. **Visualizar Lista de Administradores**  
    *Como administrador, quero visualizar todos os administradores cadastrados no sistema, para monitorar a equipe de gerenciamento.*

12. **Adicionar Novo Administrador**  
    *Como administrador, quero cadastrar novos administradores, para ampliar a equipe de gerenciamento.*

13. **Editar Informações de Administrador**  
    *Como administrador, quero alterar informações do perfil de um administrador, para manter os registros atualizados.*

14. **Excluir Administrador**  
    *Como administrador, quero excluir um administrador do sistema, caso ele não faça mais parte da equipe.*


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
- [x] Cadastro de veículos no módulo administrador.

### [João Felipe Francisco Moreira](https://github.com/joaofelipe80)
- [x] Criação do banco de dados.
- [x] Agendamento de veículos no módulo do cliente.
- [x] Alterar agenda no módulo do administrador.
- [x] Excluir agenda no módulo do administrador.
- [x] Exclusão do administrador.
      
### [Venicius Ferraz de Aráujo](https://github.com/venicius-braco)
- [x] Alteração dos carros no módulo do administrador.
- [x] Exclusão dos carros no módulo do administrador.
- [x] Alteração do cliente no módulo cliente.
- [x] Alteração do cliente no módulo administrador.
- [x] Exclusão do cliente no módulo administrador.

---
