# 🌴 Ilha 3D Interativa — Computação Gráfica (Projeto 2)

## 📌 Descrição

Este projeto foi desenvolvido para a disciplina de Computação Gráfica e consiste na construção de um cenário 3D interativo inspirado na Alegoria da Caverna de Platão.

A cena combina um ambiente interno (caverna) e um ambiente externo (praia), permitindo ao usuário explorar livremente o espaço utilizando uma câmera controlada por teclado e mouse.

---

## 🎯 Objetivo do Projeto

Explorar um ambiente 3D navegável, permitindo ao usuário interagir com a cena por meio da câmera e visualizar diferentes transformações aplicadas aos objetos.

---

## 🌍 Estrutura da Cena

### 🏝️ Ambiente Externo (Ilha)

![Ambiente externo](images/cena-geral.png)

* Palmeiras com animação de vento 🌬️
* Rochas espalhadas
* Conchas na areia
* Céu com Skybox 🌌
* Mar e terreno texturizado

### 🕳️ Ambiente Interno (Caverna)

![Ambiente interno](images/ambiente-interno.png)

* Estrutura da caverna
* Fogueira com efeito de pulsação 🔥
* Prisioneiros
* Guardas
* Muro de pedra
* Objetos de animais nas pontas das lanças

---

## 🧩 Modelos Utilizados

O projeto utiliza múltiplos modelos `.obj` distintos, todos com textura:

* Palmeira
* Rocha
* Concha
* Caverna
* Prisioneiro
* Fogueira
* Guardas

> ✔ Todos os modelos são independentes (sem múltiplos objetos no mesmo arquivo)
> ✔ Texturas aplicadas corretamente
> ✔ Escala e posicionamento ajustados manualmente

---

## 🎮 Controles

O usuário pode interagir com o cenário por meio do teclado e do mouse:

🧭 Movimentação da câmera
  W → move para frente
  S → move para trás
  A → move para a esquerda
  D → move para a direita
  Mouse → controla a direção da câmera
  Scroll do mouse → zoom (altera o campo de visão)
  
🌍 Interações no cenário
  P → alterna entre modo sólido e malha poligonal (wireframe)
  F → liga/desliga o fogo da fogueira
  V → ativa/desativa o vento (animação das palmeiras)
  
🗿 Guardas (movimento dentro da caverna)
  → (seta direita) → move os guardas para frente
  ← (seta esquerda) → move os guardas para trás
  R → reseta a posição dos guardas

---

## 🔄 Transformações

O projeto aplica as três transformações principais:

* **Translação** → posicionamento dos objetos na cena e também para movimentar dinamicamente os guardas, controlados pelo usuário via teclado
* **Escala** → ajuste proporcional dos modelos e também aplicada dinamicamente no fogo, criando um efeito de pulsação por meio de variação senoidal ao longo do tempo
* **Rotação** → aplicada na orientação dos objetos e na animação das palmeiras, simulando o efeito de vento (podendo ser ativado/desativado)

---

## 🌬️ Animações

* Palmeiras com movimento oscilatório usando função seno
* Fogueira com efeito de pulsação (escala variável)

---

## 🛠️ Tecnologias Utilizadas

* Python
* OpenGL (PyOpenGL)
* GLFW
* GLM (PyGLM)
* Pillow (carregamento de texturas)

---

## ⚠️ Observações

* O projeto utiliza apenas o **pipeline moderno do OpenGL**
* Não foram utilizados efeitos de iluminação (conforme especificação)
* A câmera é limitada ao ambiente da cena

---

## 👩‍💻 Autoria

* Kaylaine Bessa da Silva
* Giovanna Lopes de Andrade
* Disciplina: Computação Gráfica — SCC0250

---
