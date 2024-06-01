# Cartão Vacinal - Vinicius Pecorari
O objetivo deste sistema é permitir o gerenciamento das vacinações de um usuário. Para alcançar esse objetivo, foi desenvolvida uma API em C# que fornece diversos serviços para facilitar o registro, consulta e exclusão de informações relacionadas às vacinas administradas.

## Escopo
Na imagem abaixo temos a UML das entidades utilizadas no projeto:
![Modelagem](https://github.com/viniciuspecorari/Assets/blob/main/vaccination-card-uml.jpg)

### Suas relações são:
* Um usuário possui uma ou mais vacinações
* Uma vacinação é aplicada em um usuário
* Uma vacinação é composta por uma dose de uma vacina
* Uma vacina pode ser utilizada em várias vacinações
* Uma dose pode ser aplicada em várias vacinações

## Validações e Regras de Negócio
1. Ao deletar um usuário, todas suas vacinações também serão deletadas
2. Não é possível vacinar um usuário com a mesma dose de uma vacina mais de uma vez
3. O registro das vacinações devem seguir a ordem das doses

## Estrutura do Projeto
Abaixo temos uma imagem que mostra todo funcionamento das camadas do projeto:
![Comunicação do interna](https://github.com/viniciuspecorari/Assets/blob/main/architeture-application.jpg)

### Stacks Utilizadas
* C#
* .NET 8
* SSMS (SQL Server)
* Entity FrameWork (ORM)
* MediatR
* CQRS Pattern
* Repository Pattern
* Injeção de Dependência
* JWT Tokens
* Swagger

## Setup
Para que o projeto possa rodar na sua máquina, certifique-se de ter o SDK do **.NET 8** e o **SSMS (SQL Server)** instalado na sua máquina. Clone este repositório e siga os passos abaixo:

### Banco de Dados
1. Criar um database SQL Server com o nome "VaccinationCard"
2. No AppSettings > ConnectionStrings: Configurar o nome do Server
3. No AppSettings > ConnectionStrings: Configurar o User Id
4. No AppSettings > ConnectionStrings: Configurar o Password

### Dependências
1. Instalar todas as dependências do projeto (Se precisar)

### Migrations e Seeds
1. Dentro do diretório raiz do projeto, abrir o cmd e rodar o comando `dotnet ef database update -v` para criar todas as estruturas do banco e também inicializar a tabela Doses

**Agora é só testar!**

## Rotas
Abaixo uma descrição sobre todas as rotas presentes na aplicação. Confira também a collection da api no postman [clicando aqui](https://drive.google.com/file/d/1lyAz5Ji0F0-2CihCw_Udlrb2HFPq1zhl/view?usp=sharing)


### Auth
1. `[POST]/api/Auth`
* Utilize essa rota para obter o bearer de autenticação da API.
* Campos solicitados: credential. Utilize a credencial `client_credentials` 
* Para poder executar as demais rotas, adicione o bearer no **Authorize** do Swagger ou no Authorization Header da aplicação que estiver usando para testar. Exemplo: Bearer TOKEN

### Dose
1. `[GET]/api/Dose`
* Utilize essa rota para listar as doses disponiveis no sistema

### User
1. `[POST]/api/User`
* Utilize essa rota para cadastrar um usuário.
* Campos solicitados: Nome

2. `[DELETE]/api/User`
* Utilize essa rota para deletar um usuário e suas vacinações
* Campos solicitados: UserId

### Vaccination
1. `[POST]/api/Vaccination`
* Utilize essa rota para registrar uma vacinação de um usuário
* Campos solicitados: UserId, VaccineId e DoseId

2. `[GET]/api/Vaccination`
* Utilize esta rota para recuperar todas as vacinações de um usuário
* Campos solicitados: UserId

3. `[DELETE]/api/Vaccination`
* Utilize esta rota para deletar a vacinação de um usuário
* Campos solicitados: VaccinationId

### Vaccine
1. `[GET]/api/Vaccine`
* Utilize esta rota para listar todas as vacinas cadastradas

3. `[POST]/api/Vaccination`
* Utilize esta rota para cadastrar uma vacina
* Campos solicitados: Nome
