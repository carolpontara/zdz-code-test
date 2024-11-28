
# 🛠️ Teste Técnico ZDZCode 

Olá!  
Primeiramente, agradeço pela oportunidade de participar deste processo seletivo. Abaixo, apresento uma descrição detalhada do desenvolvimento do projeto proposto.

## 💡 Ideia do Projeto: Sistema de Histórico de Manutenção de Equipamentos

A solução foi planejada para gerenciar o histórico de manutenções de equipamentos, contemplando:

- Cadastro de equipamentos com informações como nome, tipo e número de série.
- Registro de manutenções, incluindo data, custo e técnico responsável.
- Consulta do histórico de manutenções para cada equipamento.

Esta escolha se baseou em uma situação do meu dia a dia que enfrentamos na faculdade na parte de manutenções dos servidores.

## 🚀 Como Rodar o Projeto

### Front-end
Para rodar o front-end desse projeto, siga os seguintes passos:

```bash
cd ./zdz-code-test
yarn build
yarn dev
```

## 📊 1ª Etapa: Modelagem de Dados

### Ferramenta Utilizada
Para modelar o banco de dados, utilizei o **draw.io**, uma ferramenta que conheço e utilizo frequentemente por sua facilidade e recursos visuais.

### Modelo de Dados
No modelo apresentado, os tipos de relações entre as tabelas são as seguintes:

**Equipamentos → Manutenções**  
- **Tipo**: 1 para N (Um para Muitos)  
- **Justificativa**: Cada equipamento pode ter várias manutenções, mas cada manutenção está vinculada a apenas um equipamento.

**Técnicos → Manutenções**  
- **Tipo**: 1 para N (Um para Muitos)  
- **Justificativa**: Um técnico pode ser responsável por várias manutenções, mas cada manutenção está vinculada a apenas um técnico.

![Modelo de Dados](image.png)

*Legenda:*  
- Linhas representam os relacionamentos entre as tabelas.
- **FK**: Chave estrangeira.
- **PK**: Chave primária.

## 🎨 2ª Etapa: Protótipo de Interface

As interfaces foram projetadas para serem simples e intuitivas, utilizando as tecnologias solicitadas: **Vue.js 3**, **Nuxt.js** e **Vuetify**.

Para o design das interfaces, utilizei como referência o logo da ZDZ. Com isso, fui montando as telas, criando esboços e compondo a interface final.

### Componentes Desenvolvidos
- **Tela de Histórico de Registros**: Exibe informações sobre equipamentos e manutenções realizadas.
- **Tabela de Equipamentos**: Lista os equipamentos cadastrados com detalhes como nome, tipo e número de série.
- **Tabela de Manutenções**: Exibe o histórico de manutenções, incluindo detalhes como data, descrição, equipamento associado, técnico responsável e custo.

### Funcionalidades Implementadas
- **Cadastro de Equipamentos**: Adiciona novos equipamentos ao sistema.
- **Registro de Manutenções**: Permite o registro de manutenções com a inclusão do técnico e do custo.
- **Consulta de Histórico**: Permite visualizar o histórico de manutenções de um equipamento específico.

## ⚙️ Tecnologias Utilizadas
- **Front-end**: Vue.js 3, Nuxt.js, Vuetify
- **Back-end**: API com suporte a operações CRUD (por exemplo, utilizando ASP.NET Core, Node.js, etc.)
- **Banco de Dados**: Banco relacional (exemplo: SQL Server, MySQL, ou PostgreSQL)

## 📈 Estrutura do Projeto
O projeto foi estruturado em componentes modulares para facilitar a escalabilidade e a manutenção. Segue um resumo da estrutura de diretórios:

```
zdz-code-test/
├── components/         # Componentes reutilizáveis
├── pages/              # Páginas principais
│   └── index.vue       # Página inicial
├── layouts/            # Layouts do Nuxt
├── store/              # Gerenciamento de estado
├── assets/             # Arquivos estáticos (ex.: imagens, fontes)
├── middleware/         # Middlewares de navegação
└── plugins/            # Plugins Nuxt
```

## 📝 Considerações Finais

Este projeto representa um sistema de gerenciamento de manutenção de equipamentos, com foco na usabilidade e na eficiência. A ideia central é criar uma solução prática para ajudar empresas a manterem o histórico de suas manutenções de forma organizada e acessível.

Espero que este projeto atenda às expectativas e agradeço pela consideração.



