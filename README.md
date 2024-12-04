# MotoRental API

Este projeto é uma API para gerenciamento de locações de motocicletas, desenvolvida em **ASP.NET Core** com **MongoDB** e suporte a upload de arquivos.

## Pré-requisitos

Certifique-se de que você possui os seguintes softwares instalados:

- [.NET SDK 7.0+](https://dotnet.microsoft.com/pt-br/download)
- [MongoDB](https://www.mongodb.com/try/download/community) ou serviço compatível
- [Docker](https://www.docker.com/) (opcional, para subir o MongoDB localmente)

## Rodando o Projeto Localmente

### 1. Clone o Repositório
Clone o projeto para o seu ambiente local:
```bash
git clone https://github.com/salgeee/motorental-api.git
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

A aplicação estará disponível http://localhost:5000/swagger



## EndPoints Disponíveis

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
 Exemplos:

POST /motos
``` 
{
  "id": "moto123",
  "year": 2024,
  "model": "Moto Sport",
  "plate": "ABC-1234"
}
```

POST /locacoes
```
{
  "id_deliveryman": "entregador123",
  "id_motor": "moto123",
  "start_date": "2024-01-01",
  "end_forecast_date": "2024-01-07",
  "plan": 7
}
```


## Tecnologias Utilizadas
ASP.NET Core 7.0

MongoDB

Swagger (Swashbuckle)

Docker

