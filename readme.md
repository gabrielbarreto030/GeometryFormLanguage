# Desafio Técnico - Refatoração de Código em C#

Este projeto apresenta uma solução refatorada para um desafio técnico focado na melhoria da manutenção e escalabilidade de um sistema de geração de relatórios de formas geométricas em múltiplos idiomas.

## Visão Geral

O desafio original envolvia um código que se tornou difícil de manter e estender para novas formas ou idiomas devido a uma estrutura procedural com lógica centralizada e muitos condicionais (`if`/`switch`). A refatoração buscou transformar este código em um sistema flexível, modular e alinhado com princípios de Orientação a Objetos.

## Tecnologias Utilizadas

*   **Linguagem:** C#
*   **Framework:**
    *   .NET Framework 4.8.2 (Branch `v1`)
    *   .NET 6 (Branch `v2`)
*   **IDE:** Visual Studio 2022
*   **Framework de Testes:**
    *   NUnit (Originalmente, na Branch `v1`)
    *   xUnit (Após migração, na Branch `v2`)

## Estrutura do Projeto e Branches

O projeto está organizado em duas branches principais para demonstrar o processo de refatoração e modernização:

*   **`v1` Branch:**
    *   Implementa a refatoração inicial com design Orientado a Objetos.
    *   Adiciona a linguagem Italiana e as formas Retângulo/Trapézio.
    *   Mantém as tecnologias legadas (.NET Framework 4.8.2 e NUnit).

*   **`v2` Branch:**
    *   Baseada na `v1`.
    *   Migra o projeto para .NET 6.
    *   Migra o framework de testes para xUnit.

## Etapas de Desenvolvimento Realizadas

1.  **Refatoração do Código:** Transformação do código legado em um design orientado a objetos utilizando polimorfismo e princípios SOLID.
2.  **Adição da Linguagem Italiana:** Implementação de um novo formatador para relatórios em Italiano.
3.  **Adição das Formas Retângulo e Trapézio:** Criação de classes dedicadas para representar e calcular essas novas formas.
4.  **Alteração para xUnit:** Migração completa do framework de testes de NUnit para xUnit.
5.  **Alteração para .NET 6:** Atualização do projeto para a plataforma .NET 6.

## Abordagem da Solução: Polimorfismo e Orientação a Objetos

A refatoração foi guiada por princípios chave da Orientação a Objetos e **SOLID** para melhorar a manutenibilidade e a extensibilidade:

*   **Princípio da Responsabilidade Única (SRP):** A lógica de cálculo (área, perímetro) e a responsabilidade de "saber seu nome" foram movidas para as classes de formas (`Square`, `Circle`, etc.). O gerador de relatório (`ShapeReportGenerator`) passou a ter a única responsabilidade de orquestrar a geração e formatação do relatório.
*   **Princípio Open/Closed (OCP):** Utilizando uma interface (`IGeometricShape`) e um design baseado em estratégias para localização (`ILanguageFormatter`), o sistema está aberto para extensão (adicionar novas formas ou idiomas implementando a interface), mas fechado para modificação (não é necessário alterar o código central do `ShapeReportGenerator` para incluir novas formas ou idiomas).
*   **Polimorfismo:** O `ShapeReportGenerator` interage com as formas através da interface `IGeometricShape`, permitindo que o código funcione de forma uniforme com qualquer tipo de forma, delegando a lógica específica para a implementação correta em tempo de execução.

Essa abordagem facilita a adição futura de novas formas ou idiomas com baixo impacto no código existente.

## Como Construir e Rodar

Para construir e executar o projeto e os testes:

1.  Clone o repositório:
    ```bash
    git clone https://github.com/gabrielbarreto030/GeometryFormLanguage.git
    ```
2.  Abra a solução (`.sln`) no Visual Studio 2022.
3.  Selecione a branch que deseja explorar (`v1` ou `v2`). Utilize `git checkout v1` ou `git checkout v2` no terminal, na pasta do repositório.
4.  O Visual Studio deve restaurar automaticamente as dependências NuGet ao abrir a solução ou construir. Caso contrário, clique com o botão direito na solução no Solution Explorer e selecione "Restore NuGet Packages".
5.  Construa a solução (`Build -> Build Solution` ou `Ctrl+Shift+B`).
6.  **Execute os testes:**
    *   Abra o Test Explorer (`Test -> Test Explorer`).
    *   Clique em "Run All Tests".

Todos os testes (incluindo os originais adaptados e os novos para Italiano, Retângulo e Trapézio) devem passar, validando o comportamento da refatoração e das novas funcionalidades.

## Decisões de Design e Notas Adicionais

*   **Formatação Decimal:** A formatação dos valores decimais (`#.##`) foi configurada nos formatadores de idioma para coincidir com a saída esperada nos testes originais (utilizando vírgula em Castellano e Italiano, ponto em Inglês). Em um cenário de produção, seria mais comum depender da cultura local ou usar formatação invariante para consistência.
*   **Separação de Formas:** Retângulo (`Rectangle`) e Trapézio (`Trapezoid`) foram implementados como classes distintas que implementam `IGeometricShape`. Embora um Retângulo seja um tipo de Trapézio, suas necessidades de parâmetros no construtor e clareza no modelo de domínio justificam a separação, alinhando-se com a responsabilidade única de cada classe.
*   **Organização do Código:** O código foi estruturado em pastas lógicas (`Shapes/`, `Localization/`, `Interfaces/`, `Classes/`) para melhorar a organização e separar as diferentes responsabilidades do sistema.
*   **Atualização de Versão e Testes:** A migração para .NET 6 e xUnit (na branch `v2`) demonstra a capacidade de trabalhar com tecnologias modernas e frameworks de teste amplamente utilizados, o que é relevante para o desenvolvimento de software atual. A utilização de branches separadas reflete uma abordagem organizada para gerenciar mudanças significativas.

## Agradecimentos

Agradeço a oportunidade de participar deste desafio técnico e aplicar conceitos de refatoração e design de software.

