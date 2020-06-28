# Introdução 
Irei desenvolver um simples projeto utilizando Asp.Net Core com duas APIs que se comunicam para obter o resultado de um cálculo.
A primeira API deve conter o valor de juros (um valor fixo inicialmente), enquanto a segunda API deve receber em um dos seus endpoints, o valor e o prazo no qual o juros deverá ser calculado.
A segunda API deve consumir o valor de juros da primeira e apresentar o resultante.

# Ferramentas e Stacks
Pretendo utilizar ASP.NET Core 3.1 para as APIs, Docker para distribuição, .NetStandard 2.1 para os testes unitários e Swagger para documentação da API.
A ideia é trabalhar utilizando so cartões do boards em uma visão de scrum com git flow para os fontes.

# Iniciando
1.	Clone o repositório para sua máquina.
2.	Navegue no Package Manager do seu Visual Studio ou no prompt do seu VSCode para a raiz do projeto.
3.  Execute `dotnet restore .\WebApi.TaxaDeJuros` para garantir que todos os pacotes desse projeto estejam restaurados.
3.	Faça o mesmo para o comando `dotnet restore .\WebApi.CalculadoraDeJuros` para garantir que todos os pacotes do segundo projeto estejam restaurados.

# Build and Test
1.  Execute `dotnet test .\tests\WebApi.CalculadoraDeJuros.Tests\WebApi.CalculadoraDeJuros.Tests.csproj` da raiz do seu projeto no seu PackageManger ou no Promp do seu VScode para executar o pacote de testes desse projeto.
2.  Faça o mesmo executando o comando `dotnet test .\tests\WebApi.TaxaDeJuros.Tests\WebApi.TaxaDeJuros.Tests.csproj` para rodar os testes desse outro projeto.


