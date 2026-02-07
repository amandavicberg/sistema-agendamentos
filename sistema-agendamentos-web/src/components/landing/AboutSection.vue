<template>
  <section class="about">
    <div class="container">
      <div class="text">
        <h2>Sobre a Bergamasco Clean</h2>
        <p>
          A Bergamasco Clean nasceu em família, com um propósito simples:
          entregar limpeza com confiança, respeito e cuidado real pelo espaço do cliente.
        </p>
        <p>
          Trabalhamos com nossos próprios produtos profissionais, utensílios adequados
          e seguimos exatamente o que o cliente pede. Nada além. Nada aquém.
        </p>
      </div>

      <div class="highlight">
        <span>✨</span>
        <h3>Nosso diferencial</h3>
        <ul>
          <li>✔️ Pontualidade</li>
          <li>✔️ Produtos profissionais</li>
          <li>✔️ Zelo com cada detalhe</li>
          <li>✔️ Atendimento humano</li>
        </ul>
      </div>
    </div>
  </section>
</template>

<style scoped>
.about {
  padding: 5rem 1.5rem;
  background: linear-gradient(135deg, #f0fdfa, #ecfeff);
}

.container {
  max-width: 1100px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(280px, 1fr));
  gap: 3rem;
  align-items: center;
}

.text h2 {
  font-size: 2rem;
  font-weight: 800;
  color: #0b1f3a;
}

.text p {
  margin-top: 1rem;
  color: #334155;
  line-height: 1.6;
}

.highlight {
  background: white;
  border-radius: 1.25rem;
  padding: 2rem;
  box-shadow: 0 12px 28px rgba(0, 0, 0, 0.05);
}

.highlight span {
  font-size: 1.8rem;
}

.highlight h3 {
  margin-top: 0.5rem;
  font-weight: 700;
  color: #0b1f3a;
}

.highlight ul {
  margin-top: 1rem;
  list-style: none;
  padding: 0;
}

.highlight li {
  margin-bottom: 0.5rem;
  color: #475569;
}
</style>
