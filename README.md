
# <img src="https://duckhuntapi.azurewebsites.net/imagefile?id=23" alt="csharp" height="30"/> Projeto DuckHuntAPI
Bem vindo ao repositório do projeto DuckHuntAPI. Este é um projeto back-end para estudo de banco de dados, programação, ferramentas ORM e padrões de projeto. A API fornece dados do jogo Duck Hunt como imagens, animações e cenários.

A API está publica e pode ser acessada a partir do domínio base [duckhuntapi.azurewebsites.net](https://duckhuntapi.azurewebsites.net/).

## Tecnologias utilizadas

### Back-End
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" alt="csharp" width="60" height="60"/> <img src="https://seeklogo.com/images/A/ASP_NET-logo-33FF43AF35-seeklogo.com.png" alt="csharp" width="120"/> <img src="https://nhibernate.info/images/NHLogoSmall.gif" alt="csharp" height="60"/> 

### Banco de dados
<img src="https://p.kindpng.com/picc/s/403-4036315_microsoft-sql-server-logo-sql-server-logo-svg.png" alt="csharp" width="180"/>

### Deploy
<img src="https://img.icons8.com/fluent/512/azure-1.png" alt="csharp" width="60" height="60"/>

# Manual da API

## SoftBan
O cliente pode fazer 1000 requisições por dia à API, após isso ele é banido temporariamente pelo periodo de um dia no qual as suas requisições não serão respondidas.

## Animation
Animation é um objeto json com os campos id, name e framesImageLink preenchidos com um número inteiro que identifica o objeto, o nome da animação e um array ordenado com os links para as imagens de sprites da animação em formato png. O objeto representa as animações do jogo.

### End-points do objeto:

#### [GET] duckhuntapi.azurewebsites.net/api/animation
Retorna um array com todos os objetos animation disponíveis.

#### [GET] duckhuntapi.azurewebsites.net/api/animation/{id}
Retorna o objeto animation com o id correspondente.

Por exemplo, duckhuntapi.azurewebsites.net/api/animation/1 retorna:
```json
{
  "id": 1,
  "name": "Jumping",
  "framesImageLink": [
    "https://duckhuntapi.azurewebsites.net/imagefile?id=1",
    "https://duckhuntapi.azurewebsites.net/imagefile?id=2"
  ]
}
```

#### [GET] duckhuntapi.azurewebsites.net/api/animation/byName/{name}
Retorna um array contendo os objetos animation de name correspondente.
Por exemplo, duckhuntapi.azurewebsites.net/api/animation/byName/Hit retorna:
```json
[
    {
        "id": 7,
        "name": "Hit",
        "framesImageLink": [
            "https://duckhuntapi.azurewebsites.net/imagefile?id=15",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=16"
        ]
    },
    {
        "id": 11,
        "name": "Hit",
        "framesImageLink": [
            "https://duckhuntapi.azurewebsites.net/imagefile?id=26",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=27"
        ]
    },
    {
        "id": 15,
        "name": "Hit",
        "framesImageLink": [
            "https://duckhuntapi.azurewebsites.net/imagefile?id=37",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=38"
        ]
    },
    {
        "id": 18,
        "name": "Hit",
        "framesImageLink": [
            "https://duckhuntapi.azurewebsites.net/imagefile?id=45"
        ]
    }
]
```

#### [GET] duckhuntapi.azurewebsites.net/api/animation/{id}/images
Retorna o array composto pelos links das imagens do objeto animation de id correspondente.

Por exemplo, duckhuntapi.azurewebsites.net/api/animation/1/images retorna:
```json
[
    "https://duckhuntapi.azurewebsites.net/imagefile?id=1",
    "https://duckhuntapi.azurewebsites.net/imagefile?id=2"
]
```

## Character
Character é um objeto json com os campos id, name, images e animations preenchidos com um número inteiro que identifica o objeto, o nome do personagem, um array com os links para as imagens do personagem disponiveis e um array com as animações do personagem. O objeto representa os personagens do jogo.

### End-points do objeto:

#### [GET] duckhuntapi.azurewebsites.net/api/character
Retorna um array com todos os objetos character disponíveis.

#### [GET] duckhuntapi.azurewebsites.net/api/character/{id}
Retorna o objeto character de id correspondente.

Por exemplo, duckhuntapi.azurewebsites.net/api/character/1 retorna:
```json
{
    "id": 1,
    "name": "PurpleBird",
    "images": [
        {
            "id": 12,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=12"
        },
        {
            "id": 13,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=13"
        },
        {
            "id": 14,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=14"
        },
        {
            "id": 15,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=15"
        },
        {
            "id": 16,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=16"
        },
        {
            "id": 17,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=17"
        },
        {
            "id": 18,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=18"
        },
        {
            "id": 19,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=19"
        },
        {
            "id": 20,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=20"
        },
        {
            "id": 21,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=21"
        },
        {
            "id": 22,
            "ImageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=22"
        }
    ],
    "animations": [
        {
            "name": "DiagonalFly",
            "framesImageLink": [
                "https://duckhuntapi.azurewebsites.net/imagefile?id=12",
                "https://duckhuntapi.azurewebsites.net/imagefile?id=13",
                "https://duckhuntapi.azurewebsites.net/imagefile?id=14"
            ]
        },
        {
            "name": "Hit",
            "framesImageLink": [
                "https://duckhuntapi.azurewebsites.net/imagefile?id=15",
                "https://duckhuntapi.azurewebsites.net/imagefile?id=16"
            ]
        },
        {
            "name": "HorizontalFly",
            "framesImageLink": [
                "https://duckhuntapi.azurewebsites.net/imagefile?id=17",
                "https://duckhuntapi.azurewebsites.net/imagefile?id=18",
                "https://duckhuntapi.azurewebsites.net/imagefile?id=19"
            ]
        },
        {
            "name": "VerticalFly",
            "framesImageLink": [
                "https://duckhuntapi.azurewebsites.net/imagefile?id=20",
                "https://duckhuntapi.azurewebsites.net/imagefile?id=21",
                "https://duckhuntapi.azurewebsites.net/imagefile?id=22"
            ]
        }
    ]
}
```

#### [GET] duckhuntapi.azurewebsites.net/api/character/{id}/images
Retorna as imagens do objeto character com o id correspodente.

Por exemplo, duckhuntapi.azurewebsites.net/api/character/1/images retorna:
```json
[
    {
        "id": 12,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=12"
    },
    {
        "id": 13,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=13"
    },
    {
        "id": 14,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=14"
    },
    {
        "id": 15,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=15"
    },
    {
        "id": 16,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=16"
    },
    {
        "id": 17,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=17"
    },
    {
        "id": 18,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=18"
    },
    {
        "id": 19,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=19"
    },
    {
        "id": 20,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=20"
    },
    {
        "id": 21,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=21"
    },
    {
        "id": 22,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=22"
    }
]
```

#### [GET] duckhuntapi.azurewebsites.net/api/character/{id}/animations
Retorna as animações do character com id correspondente.

Por exemplo, duckhuntapi.azurewebsites.net/api/character/1/animations retorna:
```json
[
    {
        "id": 6,
        "name": "DiagonalFly",
        "framesImageLink": [
            "https://duckhuntapi.azurewebsites.net/imagefile?id=12",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=13",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=14"
        ]
    },
    {
        "id": 7,
        "name": "Hit",
        "framesImageLink": [
            "https://duckhuntapi.azurewebsites.net/imagefile?id=15",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=16"
        ]
    },
    {
        "id": 8,
        "name": "HorizontalFly",
        "framesImageLink": [
            "https://duckhuntapi.azurewebsites.net/imagefile?id=17",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=18",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=19"
        ]
    },
    {
        "id": 9,
        "name": "VerticalFly",
        "framesImageLink": [
            "https://duckhuntapi.azurewebsites.net/imagefile?id=20",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=21",
            "https://duckhuntapi.azurewebsites.net/imagefile?id=22"
        ]
    }
]
```

#### [GET] duckhuntapi.azurewebsites.net/api/character/byName/{characterName} (Não implementado)

## Image
Image é um objeto json com os campos id e imageLng preenchidos com um número inteiro que identifica o objeto e um link para uma imagem respectivamente. O objeto representa as imagens do jogo.

### End-points do objeto:

#### [GET] duckhuntapi.azurewebsites.net/api/image
Retorna todos os objetos image disponíveis.

#### [GET] duckhuntapi.azurewebsites.net/api/image/{id}
Retorna o objeto image de id correspondente.

Por exemplo, https://duckhuntapi.azurewebsites.net/api/image/12 retorna:
```json
{
    "id": 12,
    "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=12"
}
```

#### [GET] duckhuntapi.azurewebsites.net/api/image/byCharacter/{characterName} (Não implementado)
#### [GET] duckhuntapi.azurewebsites.net/api/image/byScenery/{sceneryName} (Não implementado)

## Scenery
Scenery é um objeto json com os campos id, name, type e image preenchidos com um número inteiro que identifica o objeto, o nome do cenário, o tipo do cenário, podento ser NES ou ARCADE, e um objeto image da imagem do cenário. O objeto representa os cenários do jogo.

### End-points do objeto:

#### [GET] duckhuntapi.azurewebsites.net/api/scenery
Retorna todos os objetos scnery disponíveis.

#### [GET] duckhuntapi.azurewebsites.net/api/scenery/{id}
Retorna o objeto scenery de id correspondente.

Por exemplo, duckhuntapi.azurewebsites.net/api/scenery/1 retorna:
```json
{
    "id": 1,
    "name": "Bonus",
    "type": "Arcade",
    "image": {
        "id": 75,
        "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=75"
    }
}
```

#### [GET] duckhuntapi.azurewebsites.net/api/scenery/{id}/image
Retorna o image do objeto scenery de id correspondente.

Por exemplo, duckhuntapi.azurewebsites.net/api/scenery/1/image retorna:
```json
{
    "id": 75,
    "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=75"
}
```

#### [GET] duckhuntapi.azurewebsites.net/api/scenery/byName/{name}
Retorna um array contendo os objetos scenery de nome correspondete.

Por exemplo, duckhuntapi.azurewebsites.net/api/scenery/byName/Level-1 retorna:
```json
[
    {
        "id": 0,
        "name": "Level-1",
        "type": "NES",
        "image": {
            "id": 74,
            "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=74"
        }
    }
]
```

#### [GET] duckhuntapi.azurewebsites.net/api/scenery/byType/{type}
Retorna um array contendo os objetos scenery de tipo correspondente.

Por exemplo, duckhuntapi.azurewebsites.net/api/scenery/byType/Arcade retorna:
```json
[
    {
        "id": 1,
        "name": "Bonus",
        "type": "Arcade",
        "image": {
            "id": 75,
            "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=75"
        }
    },
    {
        "id": 2,
        "name": "Sky-background",
        "type": "Arcade",
        "image": {
            "id": 76,
            "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=76"
        }
    },
    {
        "id": 3,
        "name": "Level-2",
        "type": "Arcade",
        "image": {
            "id": 77,
            "imageLink": "https://duckhuntapi.azurewebsites.net/imagefile?id=77"
        }
    }
]
```