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
│   └── Authentication # Implementação completa de autenticação com expiração de token
└── IoC             # Implementação da Inversão de Controle (IoC)
```

## Configuração do Ambiente

### 1. Clonar o Repositório

```bash
git clone https://github.com/linh-00/hecate.git
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

- **POST** `/api/v1/authenticate/login` - Realiza login e retorna um token JWT
- **POST** `/api/v1/authenticate/register` - Cadastra um novo usuário

### Usuários

- **GET** `/api/v1/users` - Lista todos os usuários (somente para admins)
- **GET** `/api/v1/users/{id}` - Obtém detalhes de um usuário

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
    
      "AccessToken":   "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJlbWFpbCI6ImFsaW5uZWxhdXJlbkBob3RtYWlsLmNvbSIsImp0aSI6IjlkNDExZTBkLWM1N2QtNGU4ZC04OGE4LTUxNjA1MThhM2Q0MiIsImV4cCI6MTc0MjY2OTM5Nn0.hMcJXrR9p6LWrO3qmBZa_Ce5_F3f7vElxweIS14XfLo",
      "Expiration": "2025-03-22T18:49:56.8574573Z"

}
```

## Melhorias Futuras

* **Autorização de Usuários:** Implementar um sistema de autorização baseado em roles ou claims, permitindo controlar o acesso a diferentes recursos da API com base nas permissões do usuário.
* **Testes Automatizados:** Adicionar testes automatizados (unitários e de integração) para garantir a qualidade e o correto funcionamento da aplicação.
* **Documentação da API:** Gerar documentação da API utilizando Swagger ou outras ferramentas, facilitando o consumo da API por outros desenvolvedores.
* **Monitoramento e Logging:** Implementar monitoramento e loggi

## Contribuição

Contribuições são bem-vindas! Para colaborar:

1. Realize um fork do repositório
2. Crie uma branch para sua feature (`git checkout -b feature/nome-feature`)
3. Commit suas alterações (`git commit -m "feat: descrição clara da feature"`)
4. Envie um Pull Request

## Licença

Este projeto está licenciado sob a **MIT License**.

