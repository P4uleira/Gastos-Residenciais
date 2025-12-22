# Gastos-Residenciais

## Autor
- [@p4uleira](https://www.github.com/P4uleira)
  
## Deploy

Para realizar o deploy deste projeto, siga os passos abaixo:

- Faça primeiramente o clone do projeto. Serão criadas duas pastas:  
  - `HomeExpenseControl` → Back-End  
  - `HomeExpenseControlWeb` → Front-End

- **Criação do banco de dados:**  
  - Abra a solução no Visual Studio.  
  - Em seguida, abra o projeto `HomeExpenseControl.Api` e ajuste a string de conexão com seu banco de dados. O caminho está apresentado na imagem abaixo:  
  <img width="1919" height="499" alt="image" src="https://github.com/user-attachments/assets/9f101515-abd0-4bc8-a4b2-d4b653433a03" />  
  **Exemplo de string de conexão:**  Data Source=<usuário>;Database=HouseholdExpenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False


- Caso seja a primeira vez executando o projeto, faça o **rebuild** para que as dependências necessárias sejam instaladas. O caminho está apresentado na imagem abaixo:  
<img width="1096" height="343" alt="image" src="https://github.com/user-attachments/assets/d5a38e20-fa06-4cad-86f1-2e8edc23832b" />

- Após os passos acima, seu ambiente de Back-End estará preparado. Basta executar o projeto; pela configuração feita no Entity Framework, o banco será gerado e atualizado automaticamente.

---

- **Execução do Front-End (Web):**  
- Abra a pasta `HomeExpenseControlWeb` que foi clonada do GitHub.  
- Abra o terminal nesta pasta. O caminho está apresentado na imagem abaixo:  
<img width="819" height="574" alt="image" src="https://github.com/user-attachments/assets/c499bc80-597d-434b-84f4-a698fa3f8bbb" />

- Com o terminal aberto, instale todas as dependências do projeto (incluindo Axios e Vite):  

```bash
npm install           # Instala todas as dependências
npm run dev           # Inicia o projeto, será gerado um link no terminal

> **Observação:** É necessário ter o Node.js instalado para utilizar o npm.

Após a execução do comando `npm run dev`, será gerado um link no terminal. Clique com **Ctrl + botão esquerdo** para abrir o projeto no navegador.

---

## Tecnologias

- .NET 9.0  
- Entity Framework 9.0.11  
- Banco de dados de teste: SQL Server  
- React + TypeScript (Vite + Axios)  

### Estrutura em DDD (Api, Domain, Infra)

- **Domain:** responsável pelo controle das entidades e suas funcionalidades (distribuído em repositório e serviço que controla as ações das entidades).  
- **Infra:** responsável pelo gerenciamento do banco de dados (migrações, execução direta das queries da API, etc).  
- **Api:** responsável pela comunicação com o Front-End, recebendo solicitações e retornando os dados via Domain.

---

## Regras de negócio

- Usuários menores de 18 anos não podem criar transações do tipo **receita**.  
- Não é permitido criar uma transação com características incompatíveis.  
- O usuário deve ter idade válida (zero não é permitido).  
- O valor da transação não pode ser negativo.
