<h1 align="center">Jogo de Xadrez de Comando ♟️</h1>

## 1. Visão Geral

Este projeto consiste na implementação de um jogo de xadrez jogável através do console do Windows, desenvolvido em C#. O objetivo é criar uma versão simplificada do jogo de xadrez que permita dois jogadores competirem entre si diretamente no console, utilizando comandos de texto para mover as peças no tabuleiro.

<br>

## 2. Funcionalidades Principais

1. **Tabuleiro e Peças de Xadrez:**
   - Representação de um tabuleiro de xadrez 8x8.
   - Implementação das peças de xadrez: peões, torres, cavalos, bispos, rainhas e reis, cada uma com seus movimentos específicos.

2. **Interface de Usuário no Console:**
   - Exibição do tabuleiro no console.
   - Sistema de entrada de comandos para os jogadores realizarem movimentos (ex: `e2 e4` para mover uma peça de e2 para e4).

3. **Regras do Xadrez:**
   - Validação dos movimentos das peças de acordo com as regras do xadrez.
   - Detecção de xeque e xeque-mate.
   - Implementação de outras regras como roque, promoção de peões e en passant.

4. **Controle de Turnos:**
   - Alternância entre os turnos dos jogadores (branco e preto).
   - Indicação visual de qual jogador deve fazer o próximo movimento.

5. **Mensagens e Feedback:**
   - Mensagens informativas sobre movimentos inválidos.
   - Notificações sobre xeque e xeque-mate.
   - Atualização dinâmica do tabuleiro após cada movimento.

<br>

## 3. Instalação

Para executar o projeto de xadrez no console em C#, você precisará configurar o ambiente de desenvolvimento e baixar o projeto do GitHub.

**Passo 1: Baixar e Instalar o Visual Studio**

- Vá para [visualstudio.microsoft.com](https://visualstudio.microsoft.com/).
- Clique em "Download Visual Studio".
- Escolha a edição "Community" que é gratuita e clique em "Free Download".
- Execute o instalador baixado.

**Passo 2: Clonar o Repositório do Projeto no GitHub**

- Abra o Git Bash ou o terminal do Git.
- Navegue até o diretório onde deseja clonar o projeto.
- Execute o comando:
    ```sh
    git clone https://github.com/JonathanBarr0s/Jogo-de-Xadrez.git
    ```

**Passo 3: Abrir o Projeto no Visual Studio**

   - Inicie o Visual Studio após a instalação.
   - Clique em "Abrir um projeto ou solução".
   - Navegue até o diretório onde você clonou o repositório.
   - Selecione o arquivo da solução (`.sln`) e clique em "Abrir".

**Passo 4: Executar o Projeto**

   - Inicie o projeto apertando `Ctrl+F5`.
   - O console abrirá e você verá a interface do jogo de xadrez no console.

<br>

## 4. Como Jogar

Uma vez que você tenha instalado o Visual Studio, clonado o repositório do GitHub, e tenha o projeto de xadrez de comando em execução, você pode começar a jogar seguindo estas instruções:

#### Passo a Passo para Jogar

1. **Inicialize o Jogo:**
   - Ao executar o projeto, o console exibirá o tabuleiro de xadrez com a configuração inicial das peças.
   - O jogador com as peças brancas faz o primeiro movimento.

2. **Entendendo o Tabuleiro:**
   - O tabuleiro é representado por uma grade 8x8 com colunas de 'a' a 'h' e linhas de '1' a '8'.
   - Cada casa é identificada por uma combinação de uma letra (coluna) e um número (linha).

   ```
     a b c d e f g h
   8 T C B D R B C T 8
   7 P P P P P P P P 7
   6 · · · · · · · · 6
   5 · · · · · · · · 5
   4 · · · · · · · · 4
   3 · · · · · · · · 3
   2 P P P P P P P P 2
   1 T C B D R B C T 1
     a b c d e f g h
   ```

3. **Comandos de Movimento:**
   - Para mover uma peça, você deve digitar o comando no formato "origem destino".
   - Por exemplo, para mover um peão da casa `e2` para `e4`, digite `e2` e pressione Enter, depois digite `e4` e pressione Enter.

4. **Regras de Movimentação:**
   - Certifique-se de que o movimento é válido de acordo com as regras do xadrez.
   - O jogo validará o movimento. Se for inválido, uma mensagem de erro será exibida e você poderá tentar novamente.

#### Comandos Especiais e Regras

1. **Xeque e Xeque-Mate:**
   - O console notificará se um jogador coloca o rei adversário em xeque.
   - Se for xeque-mate, o jogo terminará e declarará o vencedor.

2. **Roque:**
   - Para fazer o roque, você pode usar um comando especial se implementado, por exemplo: `e1 g1` para o roque pequeno ou `e1 c1` para o roque grande com as brancas.
   
3. **Promoção de Peão:**
   - Quando um peão atinge a última linha (linha 8 para brancas, linha 1 para pretas), neste jogo, o peão é substituído por uma Rainha.

4. **En Passant:**
   - Captura especial de peão que pode ser executada conforme as regras do xadrez. O jogo deve reconhecer e permitir essa captura automaticamente.

<br>

## 5. Regras do Jogo

Se você deseja aprender ou revisar as regras do jogo de xadrez, acesse o site Chess clicando [aqui](https://www.chess.com/pt-BR/como-jogar-xadrez).

<br>

## 6. Vídeo do Projeto em Execução

https://github.com/JonathanBarr0s/Jogo-de-Xadrez/assets/132490863/13687425-abf3-4fc7-b331-606eacd8289a