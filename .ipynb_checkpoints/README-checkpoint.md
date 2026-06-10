# 🌴 Alegoria da Caverna 3D — Computação Gráfica (Projeto 3)

## 📌 Descrição

Este projeto foi desenvolvido para a disciplina de **Computação Gráfica** e consiste na construção de uma cena 3D interativa inspirada na **Alegoria da Caverna**, de Platão.

A cena combina dois espaços principais: um **ambiente externo**, representado por uma praia/ilha com céu, mar, areia, palmeiras, rochas e conchas; e um **ambiente interno**, representado por uma caverna com prisioneiros, guardas, fogueira, muro e projeção de sombras.

O Projeto 3 expande a cena anterior com a implementação de **iluminação ambiente, difusa e especular**, utilizando diferentes fontes de luz controláveis pelo teclado.

---

## 🎯 Objetivo do Projeto

O objetivo do projeto é aplicar conceitos de iluminação em uma cena 3D interativa, utilizando o pipeline moderno do OpenGL.

A cena foi projetada para demonstrar:

* Iluminação ambiente, difusa e especular;
* Fontes de luz internas e externas;
* Controle independente das luzes por teclado;
* Alteração da intensidade da luz ambiente;
* Alteração dos coeficientes de reflexão difusa e especular;
* Materiais próprios para cada objeto;
* Separação entre iluminação do ambiente externo e interno;
* Animações e transformações geométricas aplicadas aos objetos.

---

## 🌍 Estrutura da Cena

A cena é dividida em dois ambientes principais.

---

## 🏝️ Ambiente Externo — Praia / Ilha

### Variações do Ambiente Externo

#### Céu diurno

<p align="center">
  <img src="images/cena_azul.png" width="700">
</p>

#### Nascer do sol

<p align="center">
  <img src="images/cena_nascer.png" width="700">
</p>

#### Pôr do sol

<p align="center">
  <img src="images/cena_por.png" width="700">
</p>

#### Noite

<p align="center">
  <img src="images/cena_noite.png" width="700">
</p>

O ambiente externo representa a realidade fora da caverna. Ele contém:

* Areia texturizada;
* Mar texturizado;
* Palmeiras com animação de vento;
* Rochas distribuídas pela ilha;
* Conchas espalhadas pela areia;
* Céu com skybox;
* Sol representado por um objeto 3D;
* Alteração visual do céu conforme o ângulo do sol.

O **sol** atua como a fonte de luz externa da cena. Ele possui translação baseada em uma trajetória circular, simulando a passagem do dia. Sua cor também varia conforme o ângulo:

* Nascer do sol: luz avermelhada;
* Meio do dia: luz branca;
* Pôr do sol: luz avermelhada;
* Noite: céu noturno.

A luz do sol foi configurada para afetar os objetos do ambiente externo.

---

## 🕳️ Ambiente Interno — Caverna

### Ambiente Interno

#### Fogueira acesa

<p align="center">
  <img src="images/ambiente_interno_fogo.png" width="700">
</p>

#### Fogueira apagada

<p align="center">
  <img src="images/ambiente_interno_sem_fogo.png" width="700">
</p>

O ambiente interno representa a caverna da alegoria. Ele contém:

* Estrutura da caverna;
* Fogueira com efeito visual de pulsação;
* Prisioneiros;
* Guardas;
* Muro de pedra;
* Pedras próximas à fogueira;
* Estátuas de animais associadas às sombras;
* Sombras projetadas na parede da caverna.

A caverna possui duas fontes principais de iluminação interna:

1. **Fogueira** — fonte de luz quente, alaranjada, responsável por iluminar a caverna e representar a luz limitada percebida pelos prisioneiros.
2. **Luz da filosofia** — fonte de luz azulada que sai da câmera, representando a iluminação pelo conhecimento.

A luz da filosofia pode ser ligada e desligada pelo teclado. Quando ativada, ela ilumina a cena a partir da direção da câmera, simbolizando o momento em que um prisioneiro passa a ser iluminado pela razão e deixa de depender apenas das sombras projetadas pela fogueira.

---

## 💡 Sistema de Iluminação

O projeto implementa iluminação com três componentes principais:

### 🌗 Luz Ambiente

A luz ambiente ilumina a cena de forma geral, simulando uma iluminação mínima presente no ambiente.

Ela pode ser ligada ou desligada e sua intensidade pode ser aumentada ou diminuída pelo teclado.

---

### 🌞 Luz Externa — Sol

O sol é a fonte de luz do ambiente externo.

Características:

* Possui translação ao longo de uma trajetória circular;
* Sua posição muda com o ângulo controlado pelo teclado;
* Sua cor varia de acordo com o horário simulado;
* Afeta os objetos externos, como areia, mar, palmeiras, rochas e conchas;
* É representado visualmente por um modelo 3D.

---

### 🔥 Luz Interna — Fogueira

A fogueira é uma das fontes de luz internas.

Características:

* Possui cor quente, próxima ao laranja/vermelho;
* Ilumina objetos internos da caverna;
* Pode ser ligada e desligada pelo teclado;
* O fogo visual possui efeito de pulsação por escala variável;
* Serve como referência para as sombras projetadas na parede da caverna.

---

### 🧠 Luz Interna — Filosofia

A luz da filosofia é a segunda fonte interna da cena.

Ela representa simbolicamente a iluminação pelo conhecimento na Alegoria da Caverna.

Características:

* Sai da posição da câmera;
* Aponta na mesma direção em que o observador está olhando;
* Possui coloração azulada;
* Pode ser ligada ou desligada pelo teclado;
* Ilumina a cena interna como um feixe de luz;
* Representa a passagem da visão limitada das sombras para a compreensão da realidade.

---

## 🧱 Materiais dos Objetos

Cada objeto da cena possui seus próprios parâmetros de iluminação, incluindo:

* Componente ambiente;
* Coeficiente de reflexão difusa;
* Coeficiente de reflexão especular;
* Brilho especular.

Os materiais são definidos manualmente no código e não dependem de parâmetros prontos vindos de arquivos `.mtl`.

Isso permite que diferentes objetos reajam de formas diferentes às fontes de luz. Por exemplo:

* O mar possui maior reflexão especular;
* As rochas possuem brilho mais baixo;
* As estátuas possuem maior componente especular;
* A areia possui reflexão difusa mais forte;
* O fogo visual não recebe iluminação, pois ele representa a própria fonte emissiva.

---

## 🌌 Skybox Dinâmico

O céu da cena utiliza um conjunto de texturas aplicadas às faces de um cubo, formando um skybox.

Foram usados diferentes conjuntos de texturas para representar variações do céu:

* Céu noturno;
* Céu do nascer do sol;
* Céu azul diurno;
* Céu do pôr do sol.

A textura do céu é escolhida de acordo com o ângulo do sol, criando uma transição visual entre diferentes momentos do dia.

---

## 👥 Modelos Utilizados

O projeto utiliza múltiplos modelos `.obj`, todos com textura aplicada.

Modelos presentes na cena:

* Caverna;
* Muro;
* Pedras;
* Fogueira;
* Fogo;
* Prisioneiro;
* Guarda;
* Estátua de cavalo;
* Estátua de ibex;
* Palmeira;
* Rocha;
* Concha;
* Sol.aaaaaaaaaaaaa
---

## 🎮 Controles

O usuário pode interagir com o cenário usando teclado e mouse.

---

### 🧭 Movimentação da Câmera

| Tecla / Ação    | Função                        |
| --------------- | ----------------------------- |
| W               | Move a câmera para frente     |
| S               | Move a câmera para trás       |
| A               | Move a câmera para a esquerda |
| D               | Move a câmera para a direita  |
| Mouse           | Controla a direção da câmera  |
| Scroll do mouse | Altera o campo de visão       |

---

### 🌞 Controle do Sol

| Tecla | Função                    |
| ----- | ------------------------- |
| ↑     | Avança o ângulo do sol    |
| ↓     | Retrocede o ângulo do sol |

O movimento do sol altera sua posição e também influencia a aparência do céu.

---

### 💡 Controle das Luzes

| Tecla | Função                          |
| ----- | ------------------------------- |
| 1     | Liga/desliga a luz do sol       |
| 2     | Liga/desliga a luz da fogueira  |
| 3     | Liga/desliga a luz ambiente     |
| 4     | Liga/desliga a luz da filosofia |

Cada fonte de luz possui controle independente.

---

### 🌗 Intensidade da Luz Ambiente

| Tecla | Função                                |
| ----- | ------------------------------------- |
| Z     | Diminui a intensidade da luz ambiente |
| X     | Aumenta a intensidade da luz ambiente |

---

### 🟡 Reflexão Difusa

| Tecla | Função                    |
| ----- | ------------------------- |
| C     | Diminui a reflexão difusa |
| B     | Aumenta a reflexão difusa |

---

### ✨ Reflexão Especular

| Tecla | Função                       |
| ----- | ---------------------------- |
| N     | Diminui a reflexão especular |
| M     | Aumenta a reflexão especular |

---

### 🌬️ Outras Interações

| Tecla | Função                                      |
| ----- | ------------------------------------------- |
| V     | Liga/desliga o vento das palmeiras          |
| F     | Liga/desliga o fogo visual da fogueira      |
| P     | Alterna entre modo sólido e malha poligonal |
| ←     | Move os guardas em uma direção              |
| →     | Move os guardas na direção oposta           |
| R     | Reseta a posição dos guardas                |
| ESC   | Fecha a janela                              |

---

## 🔄 Transformações Geométricas

O projeto aplica transformações geométricas nos objetos da cena por meio de matrizes `model`.

### Translação

Utilizada para posicionar os objetos no mundo 3D e também para movimentar elementos da cena, como:

* Sol em trajetória circular;
* Guardas dentro da caverna;
* Posicionamento individual dos objetos.

### Escala

Utilizada para ajustar o tamanho dos modelos e criar efeitos animados, como:

* Pulsação do fogo;
* Ajuste proporcional de modelos importados;
* Variação de tamanho das palmeiras.

### Rotação

Utilizada para orientar objetos na cena e criar animações, como:

* Inclinação das palmeiras pelo vento;
* Orientação de guardas, prisioneiros e estátuas;
* Ajuste da posição visual dos modelos importados.

---

## 🌬️ Animações

O projeto possui animações simples baseadas no tempo.

### Palmeiras

As palmeiras balançam usando uma função seno, simulando o efeito do vento.

### Fogueira

A chama da fogueira possui pulsação por variação de escala, também usando função seno.

### Sol

O sol se desloca por uma trajetória circular, simulando diferentes momentos do dia.

---

## 🕯️ Sombras

A cena também inclui projeção de sombras na parede da caverna.

As sombras são calculadas a partir de uma matriz de projeção planar, utilizando a posição da fogueira como referência de luz.

Quando a luz da filosofia está desligada, as sombras aparecem na parede, reforçando a ideia da percepção limitada dos prisioneiros. Quando a luz da filosofia é ativada, as sombras deixam de dominar a cena, representando a superação da ilusão pela razão.

---

## ✅ Requisitos Atendidos

| Requisito                               | Implementação                                   |
| --------------------------------------- | ----------------------------------------------- |
| Fonte externa com translação            | Sol em movimento circular                       |
| Fonte externa afeta ambiente externo    | Sol aplicado aos objetos externos               |
| Duas fontes internas                    | Fogueira e luz da filosofia                     |
| Fontes internas afetam ambiente interno | Luzes internas aplicadas aos objetos da caverna |
| Interruptores independentes             | Teclas 1, 2, 3 e 4                              |
| Controle da luz ambiente                | Teclas Z e X                                    |
| Controle da reflexão difusa             | Teclas C e B                                    |
| Controle da reflexão especular          | Teclas N e M                                    |
| Materiais próprios por objeto           | Parâmetros `ka`, `kd`, `ks` e `shininess`       |
| Pipeline moderno                        | Uso de VBOs, shaders e matrizes                 |

---

## 🧠 Interpretação Conceitual

A cena foi construída como uma representação interativa da Alegoria da Caverna.

A fogueira representa a fonte limitada de luz que gera as sombras percebidas pelos prisioneiros. O sol representa a realidade exterior à caverna. Já a luz da filosofia representa o conhecimento, saindo da perspectiva do observador e iluminando a cena interna.

Assim, o projeto une os requisitos técnicos de iluminação em Computação Gráfica com a simbologia da alegoria filosófica.

---

## 👩‍💻 Autoria

* Kaylaine Bessa da Silva
* Giovanna Lopes de Andrade
* Disciplina: Computação Gráfica — SCC0250

---
