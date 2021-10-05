Sobre o projeto:
-> Para rodar esse projeto é necessário instalar o .NET Core 5 SDK que pode ser encontrado no link https://dotnet.microsoft.com/download
-> No Visual Code navegue pelo terminal até a pasta MATC84.API e para rodar a aplicação utilize o comando "dotnet run" ou "dotnet watch run"
-> Você pode realizar a atividade utilizando o Swagger ou o Postman, que pode ser encontrado no link https://www.postman.com/downloads/

Sobre a atividade:

-> Para criar (POST) uma pessoa é necessário já existir um seminário e vincular esse seminário a pessoa através do SeminarioId.
-> Caso um seminário seja deletado (DELETE), todas as pessoas pertencententes ao seminário também serão deletadas
-> Para atualizar (PUT) uma pessoa, os campos não alterados devem estar presentes no JSON.
-> Na busca de pessoas (GET), a busca por mátricula, compara se a matrícula informada é exatamente igual às matrículas existentes na base
-> As buscas por nome ou tema, compara apenas se os nomes ou temas na base possuem o nome ou tema informado.
