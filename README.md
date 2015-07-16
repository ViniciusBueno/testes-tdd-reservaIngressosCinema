# testes-tdd-reservaIngressosCinema
Projeto de estudo para utilizar TDD.

# Considerações
- Este projeto está sendo desenvolvido em ASP.NET MVC, C#, MSTest e Moq usando o Visual Studio 2013.
- As funcionalidades do banco não serão desenvolvidas.
- Apenas as funcionalidades que envolvam regras de negócio significativas serão implementadas, conforme listadas no tópico a baixo.
- Na pasta "testes-tdd-reservaIngressosCinema\testes-tdd-reservaIngressosCinema\Documentacao" estão documentos para uma visão geral do projeto. São documentos simples com a ideia do projeto.

# Funcionalidades implementadas
- Ao incluir usuário sem perfil, incluir com o perfil cliente.
- Ao incluir um usuário sem um campo obrigatório, no caso o campo nome, validar e não incluir.
- Ao incluir um horário de uma sala que já possui este mesmo horário cadastrado, validar e não incluir.
- Ao reservar ingressos para uma sala já lotada, validar e não reservar. (Implementando)
