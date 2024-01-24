# Quick Task API



## Sumário

- [Começando](#começando)
  - [Pré-requisitos](#pré-requisitos)
  - [Instalação](#instalação)
- [Uso](#uso)
  - [Endpoints](#endpoints)
- [Testes](#testes)


## Começando

Side Project 

### Pré-requisitos

Aspnet Core 8.0

### Instalação

Guia passo a passo sobre como instalar e configurar o projeto.

```bash
# Exemplo de passos de instalação
git clone https://github.com/julianosaless/QuickTaskAPI.git
cd quicktaskapi
dotnet restore
dotnet build
dotnet test
dotnet run
```

# Uso
Explique como usar o seu projeto, forneça exemplos de código e descreva quaisquer opções de configuração.

Endpoints
http://localhost:5094

GET /api/v1/task: Obter uma lista de tarefas.
GET /api/v1/task/{id}: Obter detalhes de uma tarefa específica.
POST /api/v1/task: Criar uma nova tarefa.
PUT /api/v1/task/{id}: Atualizar uma tarefa existente.
DELETE /api/v1/task/{id}: Excluir uma tarefa.


### Payload
```bash

{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "title": "Add new Task",
  "description": "last deploy...",
  "startDate": "2024-01-24T18:00:06.291Z",
  "endDate": "2024-01-24T18:00:06.291Z",
  "isCompleted": "N"
}
```

#Testes
dotnet test