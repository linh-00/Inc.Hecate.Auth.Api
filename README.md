# Hecate - API de Autenticação

Hecate é uma API desenvolvida em **.NET** para gestão e autenticação de usuários, seguindo os princípios da **Arquitetura em Cebola (Onion Architecture)**. O projeto é modular, permitindo integração tanto com **SQL Server** quanto com **MongoDB**.

## Tecnologias Utilizadas

- **.NET 8**
- **SQL Server** (padrão)
- **MongoDB** (opcional)
- **JWT (JSON Web Token)** para autenticação segura
- **Arquitetura Onion** para maior escalabilidade e manutenção

## Estrutura do Projeto

```
Hecate
├── Domain          # Camada de Domínio com entidades e interfaces
├── Application     # Camada de Aplicação com regras de negócio
├── DAL             # Camada de Infraestrutura com acesso a dados (DAL)
├── API		    # Camada de Apresentação (Controllers e Endpoints)
└── Tests           # Testes unitários e de integração
```

## Configuração do Ambiente

### 1. Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/hecate.git
cd hecate
```

### 2. Configurar a Base de Dados

- **SQL Server**: Configure a string de conexão no arquivo `appsettings.json`
- **MongoDB**: Altere a configuração conforme a necessidade

Exemplo para SQL Server:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HecateDB;User Id=sa;Password=SuaSenha;"
}
```

### 3. Executar as Migrações (para SQL Server)

```bash
dotnet ef database update
```

### 4. Executar a API

```bash
dotnet run --project ./Presentation
```

## Endpoints

### Autenticação

- **POST** `/api/auth/login` - Realiza login e retorna um token JWT
- **POST** `/api/auth/register` - Cadastra um novo usuário

### Usuários

- **GET** `/api/users` - Lista todos os usuários (somente para admins)
- **GET** `/api/users/{id}` - Obtém detalhes de um usuário

## Exemplo de Requisição JWT

```http
POST /api/auth/login
Content-Type: application/json

{
    "email": "alinnelauren@hotmail.com",
    "password": "123456"
}
```

**Resposta:**

```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR..."
}
```

## Melhorias Futuras

-

## Contribuição

Contribuições são bem-vindas! Para colaborar:

1. Realize um fork do repositório
2. Crie uma branch para sua feature (`git checkout -b feature/nome-feature`)
3. Commit suas alterações (`git commit -m "feat: descrição clara da feature"`)
4. Envie um Pull Request

## Licença

Este projeto está licenciado sob a **MIT License**.

