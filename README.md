# 🎮 Gaming Health Dashboard

API REST para análise de saúde mental e hábitos de jogadores, construída com **C# .NET 8**, **Clean Architecture**, **Dapper** e **Oracle 18c XE**.

---

## Sobre o projeto

O Gaming Health Dashboard é uma API que consulta e expõe dados de **10 milhões de jogadores**, organizados em 6 domínios: perfil, hábitos de jogo, saúde, social, desempenho e dados financeiros/tecnológicos.

O projeto foi criado com foco em aprendizado progressivo — começando simples e crescendo com novas funcionalidades conforme meu estudo avança.

---

## Tecnologias

| Tecnologia | Versão | Uso |
|---|---|---|
| .NET | 8.0 | Framework principal |
| ASP.NET Core Web API | 8.0 | Camada de API |
| Dapper | 2.x | Acesso ao banco de dados |
| Oracle.ManagedDataAccess.Core | 23.x | Driver Oracle |
| Swashbuckle (Swagger) | 6.x | Documentação da API |
| Oracle Database XE | 18c | Banco de dados |

---

## Arquitetura

O projeto segue os princípios da **Clean Architecture**, separando responsabilidades em 4 camadas independentes:

```
GamingHealth/
│
├── GamingHealth.Domain/
│   ├── Entities/
│   │   ├── Player.cs
│   │   ├── GamingHabits.cs
│   │   ├── Health.cs
│   │   ├── Social.cs
│   │   ├── Performance.cs
│   │   └── FinancialTech.cs
│   └── Interfaces/
│       └── IPlayerRepository.cs
│
├── GamingHealth.Application/
│   ├── DTOs/
│   │   └── PlayerDto.cs
│   │   └── PlayerDetailDto.cs
│   └── UseCases/
│       ├── ListPlayers/
│       │   └── ListPlayersUseCase.cs
│       └── GetPlayerById/
│           └── GetPlayerByIdUseCase.cs
│
├── GamingHealth.Infrastructure/
│   ├── Data/
│   │   └── OracleDbContext.cs
│   └── Repositories/
│       └── PlayerRepository.cs
│
└── GamingHealth.API/
    ├── Controllers/
    │   └── PlayersController.cs
    ├── appsettings.json
    └── Program.cs
```

### Fluxo de uma requisição

```
HTTP Request
    → PlayersController
        → Use Case (ExecuteAsync)
            → IPlayerRepository
                → PlayerRepository (Dapper + Oracle)
                    → Entidade preenchida
                → Mapeamento Entidade → DTO
            → DTO retornado
        → Ok(dto)
    → JSON Response
```

### Regra de dependência

```
API  →  Application  →  Domain
              ↑
       Infrastructure
```

O **Domain** não depende de ninguém. Todas as dependências apontam para dentro.

---

## Modelagem do banco de dados

O CSV original com 40 colunas foi normalizado em **6 tabelas**:

```
PLAYER (tabela central)
├── GAMING_HABITS  → hábitos de jogo
├── HEALTH         → saúde física e mental
├── SOCIAL         → interações sociais
├── PERFORMANCE    → desempenho acadêmico e profissional
└── FINANCIAL_TECH → gastos e qualidade de internet
```

Todas as tabelas filhas possuem `player_id` como **chave primária e estrangeira** referenciando `PLAYER`.

---

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Oracle Database 18c XE](https://www.oracle.com/database/technologies/xe-downloads.html)
- [Oracle SQL Developer](https://www.oracle.com/database/sqldeveloper/) (recomendado)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou superior

---

## Configuração

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/gaming-health-dashboard.git
cd gaming-health-dashboard
```

### 2. Configure o banco de dados

Conecte no Oracle como `SYSDBA` e execute:

```sql
ALTER SESSION SET CONTAINER = XEPDB1;

CREATE USER dbagh IDENTIFIED BY sua_senha;
GRANT CONNECT, RESOURCE TO dbagh;
GRANT QUOTA UNLIMITED ON USERS TO dbagh;
```

Execute os scripts na ordem:

```
1. scripts/create_tables_dbagh.sql   → cria as 6 tabelas
2. scripts/import_data_dbagh.sql     → importa os dados
```

### 3. Configure a connection string

Abra `GamingHealth.API/appsettings.json` e atualize:

```json
{
  "ConnectionStrings": {
    "OracleConnection": "User Id=dbagh;Password=sua_senha;Data Source=localhost:1521/XEPDB1;"
  }
}
```

### 4. Execute o projeto

```bash
cd GamingHealth.API
dotnet run
```

Ou no Visual Studio: defina `GamingHealth.API` como **Startup Project** e pressione **F5**.

A API estará disponível em `https://localhost:{porta}/swagger`.

---

## Endpoints

### Players

| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/players` | Lista jogadores com paginação |
| GET | `/api/players/{id}` | Retorna detalhes completos de um jogador |

### GET /api/players

Parâmetros de query:

| Parâmetro | Tipo | Padrão | Descrição |
|---|---|---|---|
| `page` | int | 1 | Página atual |
| `pageSize` | int | 20 | Itens por página (máx. 100) |

Exemplo de resposta:

```json
{
  "players": [
    {
      "playerId": 5,
      "age": 33,
      "gender": "Male",
      "income": 8648,
      "bmi": 23.4
    }
  ],
  "totalCount": 1010000,
  "page": 1,
  "pageSize": 20,
  "totalPages": 50500
}
```

### GET /api/players/{id}

Exemplo de resposta:

```json
{
  "playerId": 250,
  "age": 13,
  "gender": "Female",
  "income": 75127,
  "bmi": 25.88,
  "gamingHabits": {
    "dailyGamingHours": 4.04,
    "weeklySessions": 16,
    "yearsGaming": 4,
    "weekendGamingHours": 5.63,
    "multiplayerRatio": 0.57,
    "violentGamesRatio": 0.28,
    "mobileGamingRatio": 0.58,
    "nightGamingRatio": 0.54,
    "competitiveRank": 93,
    "headsetUsage": 0,
    "esportsInterest": 5
  },
  "health": {
    "sleepHours": 7.19,
    "caffeineIntake": 0.4,
    "exerciseHours": 5.16,
    "stressLevel": 3,
    "anxietyScore": 6.02,
    "depressionScore": 1.7,
    "screenTimeTotal": 11,
    "eyeStrainScore": 8.34,
    "backPainScore": 3.95
  },
  "social": { ... },
  "performance": { ... },
  "financialTech": { ... }
}
```

---

## Roadmap

### ✅ Fase 1 — Base (concluída)
- [x] Modelagem e normalização do banco de dados
- [x] Importação de 10 milhões de registros via staging
- [x] Estrutura Clean Architecture com 4 projetos
- [x] Conexão Oracle com Dapper
- [x] `GET /api/players` com paginação
- [x] `GET /api/players/{id}` com dados de todas as tabelas
- [x] Documentação via Swagger

### 🔄 Fase 2 — Crescendo
- [ ] Filtros por gênero, faixa de idade e nível de vício
- [ ] Use Case `GetDashboardStats` com médias gerais
- [ ] `GET /api/dashboard`

### 📋 Fase 3 — Evoluindo
- [ ] Autenticação com JWT
- [ ] Cache com Redis
- [ ] Testes unitários com xUnit

### 🚀 Fase 4 — Avançado
- [ ] Frontend com Blazor ou React
- [ ] Gráficos interativos
- [ ] Exportação de relatórios em PDF e Excel

---

## Decisões técnicas

**Por que Dapper e não Entity Framework?**
Dapper oferece mais controle sobre as queries SQL, melhor performance em grandes volumes de dados e curva de aprendizado mais suave para quem está aprendendo a base antes de usar abstrações mais pesadas.

**Por que staging para importação do CSV?**
Importar tudo como `VARCHAR2` primeiro evita erros de conversão durante a carga. A conversão de tipos acontece de forma controlada no `INSERT SELECT`, onde é possível tratar `NLS_NUMERIC_CHARACTERS` e outros problemas de formatação.

**Por que separar entidades de DTOs?**
Entidades representam o modelo do banco de dados. DTOs representam o contrato da API. Separá-los permite evoluir o banco e a API de forma independente sem quebrar um ao outro.

---

## Dataset

O dataset utilizado é o `gaming_mental_health_10M_40features.csv`, contendo **10 milhões de registros** sintéticos com 40 features sobre hábitos de jogo e saúde mental de jogadores.

---

## Autor

Rafael — projeto de estudo de C#, .NET e Clean Architecture.
