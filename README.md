# TasksManager API

API REST desenvolvida em ASP.NET Core para gestão de tarefas, com suporte a operações CRUD e filtros por status e data de vencimento. Este projeto foi construído como parte de um teste técnico, com foco em boas práticas de desenvolvimento, organização de código e simplicidade.

## 🚀 Tecnologias e ferramentas utilizadas

- ASP.NET Core 6
- Entity Framework Core (InMemory)
- Swagger
- Injeção de dependência
- Padrão Repositório
- Boas práticas SOLID

## 📚 Funcionalidades implementadas

- [x] Criar nova tarefa
- [x] Listar todas as tarefas
- [x] Atualizar uma tarefa existente
- [x] Deletar uma tarefa
- [x] Filtro por status (`Pendente`, `EmProgresso`, `Concluida`)
- [x] Filtro por data de vencimento (ex: `?dueDate=2025-05-04`)
- [x] Documentação via Swagger

## 📁 Estrutura do projeto
TasksManager/
├── Controllers/
│   └── TaskController.cs
├── Models/
│   └── TaskItem.cs
├── Repositories/
│   ├── ITaskRepository.cs
│   └── TaskRepository.cs
├── Database/
│   └── AppDbContext.cs
├── Program.cs

### 📄Acesse a Documentação depois de executar o projeto
[https://localhost:5001/swagger](https://localhost:7106/swagger/index.html)

🧑‍💻 Desenvolvido por Gabriel João
