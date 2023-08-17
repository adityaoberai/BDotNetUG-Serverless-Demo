# Azure Functions + .NET 7 Isolated Worker Demo

## Description

This is a demo function that showcases .NET 7 Isolated Worker Azure Functions

## Setup

* Install [Azure Functions Core Tools 4.x](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local?pivots=programming-language-csharp)
* Install [.NET 7](https://dotnet.microsoft.com/en-us/download)
* Clone the repository
* Enter the cloned repository's directory
* Run `dotnet restore`
* Run `func start`

## Methods

### Add `POST /api/todos/add`

* Example Request Body

```json
{
    "name": "Create sample for BDotNETUG Meetup",
    "isComplete": true
}
```

* Example Response

```json
{
    "Id": 1,
    "Name": "Create sample for BDotNETUG Meetup",
    "IsComplete": true
}
```

### Get All `GET /api/todos/getall`

* Example Response

```json
[
    {
        "Id": 1,
        "Name": "Create sample for BDotNETUG Meetup",
        "IsComplete": true
    },
    {
        "Id": 2,
        "Name": "Deliver session at meetup",
        "IsComplete": false
    }
]
```