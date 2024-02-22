# API-Produto

# API-Produto

Este é um projeto de API para gerenciamento de produtos.

## Funcionalidades

### ProdutoController

O `ProdutoController` é responsável por lidar com as operações relacionadas aos produtos. Ele possui as seguintes funcionalidades:

- `Get`: Retorna todos os produtos cadastrados.
- `Get/{id}`: Retorna um produto específico com base no seu ID.
- `Get/nome/{name}`: Retorna todos os produtos que possuem um determinado nome.
- `Get/ordenado/{field}`: Retorna todos os produtos ordenados por um campo específico.
- `Post`: Cria um novo produto.
- `Put/{id}`: Atualiza um produto existente com base no seu ID.
- `Delete/{id}`: Exclui um produto existente com base no seu ID.

###

## Funcionalidades Adicionais

- Configuração do banco de dados em memória.
- .Net 8.
- EF Code-First.
- Configuração do Swagger para documentação da API.
- Testes unitários.
- Testes de integração.
- Seed de dados com 5 exemplos.

## Arquitetura

A arquitetura do projeto é baseada no modelo DDD (Domain-Driven Design). Ela é composta por 6 camadas:

- `Presentation`: Camada responsável por lidar com as requisições HTTP e retornar as respostas.
- `Domain`: Camada responsável por lidar com as entidades.
- `Service`: Camada responsável por lidar com as regras de negócio.
- `Repository`: Camada responsável por lidar com a persistência de dados.
- `CrossCutting`: Camada responsável por lidar com as configurações gerais do projeto, como enums, exceções, etc.
- `Tests`: Camada responsável por lidar com os testes unitários e de integração.

