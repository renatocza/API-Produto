# API-Produto

# API-Produto

Este � um projeto de API para gerenciamento de produtos.

## Funcionalidades

### ProdutoController

O `ProdutoController` � respons�vel por lidar com as opera��es relacionadas aos produtos. Ele possui as seguintes funcionalidades:

- `Get`: Retorna todos os produtos cadastrados.
- `Get/{id}`: Retorna um produto espec�fico com base no seu ID.
- `Get/nome/{name}`: Retorna todos os produtos que possuem um determinado nome.
- `Get/ordenado/{field}`: Retorna todos os produtos ordenados por um campo espec�fico.
- `Post`: Cria um novo produto.
- `Put/{id}`: Atualiza um produto existente com base no seu ID.
- `Delete/{id}`: Exclui um produto existente com base no seu ID.

###

## Funcionalidades Adicionais

- Configura��o do banco de dados em mem�ria.
- .Net 8.
- EF Code-First.
- Configura��o do Swagger para documenta��o da API.
- Testes unit�rios.
- Testes de integra��o.
- Seed de dados com 5 exemplos.

## Arquitetura

A arquitetura do projeto � baseada no modelo DDD (Domain-Driven Design). Ela � composta por 6 camadas:

- `Presentation`: Camada respons�vel por lidar com as requisi��es HTTP e retornar as respostas.
- `Domain`: Camada respons�vel por lidar com as entidades.
- `Service`: Camada respons�vel por lidar com as regras de neg�cio.
- `Repository`: Camada respons�vel por lidar com a persist�ncia de dados.
- `CrossCutting`: Camada respons�vel por lidar com as configura��es gerais do projeto, como enums, exce��es, etc.
- `Tests`: Camada respons�vel por lidar com os testes unit�rios e de integra��o.

