# MotoRental API

Este projeto é uma API para gerenciamento de locações de motocicletas, desenvolvida em **ASP.NET Core** com **MongoDB** e suporte a upload de arquivos.

## Pré-requisitos

Certifique-se de que você possui os seguintes softwares instalados:

- [.NET SDK 9.0](https://dotnet.microsoft.com/pt-br/download)
- [MongoDB](https://www.mongodb.com/try/download/community) 
## Rodando o Projeto Localmente

### 1. Clone o Repositório
Clone o projeto para o seu ambiente local:
```bash
git clone https://github.com/salgeee/DesafioBackEnd.git
cd desafiobackend
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
POST /locacao: Criar uma nova locação.
PUT /locacao/{id}/devolucao: Registrar a devolução da moto.
GET /locacao/{id}: Registrar a devolução da moto.
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
  "identifier": "moto123",
  "year": 2024,
  "model": "Moto Sport",
  "plate": "ABC-1234"
}
```

POST /locacao
```
{
  "id_deliveryman": "string",
  "id_motor": "string",
  "start_date": "2024-12-04T12:37:00.725Z",
  "end_date": "2024-12-04T12:37:00.725Z",
  "end_forecast_date": "2024-12-04T12:37:00.725Z",
  "plan": 7
}
```
PUT /locacao/{id}/devolucao
```
{
  "return_date": "2024-12-04T12:37:00.725Z",
}
```
POST /entregadores
```
{
  "identifier": "string",
  "name": "Roberto Carlos",
  "cnpj": "123813412421",
  "birth_date": "2024-12-04T02:06:45.448Z",
  "cnh_number": "1231414",
  "cnh_type": "A",
  "image_cnh": ""
}
```
POST /entregadores/{id}/cnh

![image](https://github.com/user-attachments/assets/b11a2960-5956-4c90-9a4b-98a35cafb351)


## Tecnologias Utilizadas
ASP.NET Core 7.0

MongoDB

Swagger (Swashbuckle)

Docker

