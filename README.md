# MotoRental API

Este projeto é uma API para gerenciamento de locações de motocicletas, desenvolvida em **ASP.NET Core** com **MongoDB** e suporte a upload de arquivos.

## Pré-requisitos

Certifique-se de que você possui os seguintes softwares instalados:

- [.NET SDK 7.0+](https://dotnet.microsoft.com/download/dotnet/7.0)
- [MongoDB](https://www.mongodb.com/try/download/community) ou serviço compatível
- [Docker](https://www.docker.com/) (opcional, para subir o MongoDB localmente)

## Rodando o Projeto Localmente

### 1. Clone o Repositório
Clone o projeto para o seu ambiente local:
```bash
git clone https://github.com/SEU_USUARIO/motorental-api.git
cd motorental-api
```

### 2. Configurar Banco de Dados
```
{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "MotoRentalDB"
  }
}
```

### 3. Restaurar dependências
```
dotnet restore
```

### 4. Rodar o projeto 
```
dotnet run
```

### 5. Testar a API com Swagger
```
http://localhost:5000/swagger
```




## Testes com Postman(ou similares)

Entregadores
```
POST /entregadores: Cadastrar um novo entregador.
POST /entregadores/{id}/cnh: Enviar a CNH do entregador.
```
Locação
``` 
POST /locacoes: Criar uma nova locação.
PUT /locacoes/{id}/devolucao: Registrar a devolução da moto.
GET /locacoes/{id}: Registrar a devolução da moto.
```
Motos
``` 
POST /motos: Cadastrar uma nova moto
GET  /motos: Consultar motos existentes
PUT /motos/{id}/placa: Modificar a placa de uma moto
GET /motos/{id}: Consultar motos existentes por id
DELETE /motos/{id}: Remover uma moto
```

## Tecnologias Utilizadas
ASP.NET Core 7.0

MongoDB

Swagger (Swashbuckle)

Docker

