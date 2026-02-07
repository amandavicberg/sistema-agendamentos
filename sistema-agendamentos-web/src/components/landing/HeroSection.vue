<template>
  <section class="hero">
    <div class="content">
      <h1>
        Bergamasco Clean
        <span>Confiança que limpa, cuidado que fica.</span>
      </h1>
      <p>
        Faxinas residenciais, casas de temporada e embarcações internas com zelo,
        pontualidade e produtos profissionais.
      </p>

      <div class="buttons">
        <a
          href="https://wa.me/5524992228265"
          target="_blank"
          class="btn primary"
        >
          Agendar agora 💬
        </a>
        <a href="#services" class="btn outline">
          Ver serviços ✨
        </a>
      </div>
    </div>
  </section>
</template>

<style scoped>
.hero {
  min-height: 100vh;
  background: linear-gradient(135deg, #0b1f3a, #0e2a47);
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  padding: 3rem 1.5rem;
}

.content {
  max-width: 720px;
}

h1 {
  font-size: 3rem;
  font-weight: 800;
  line-height: 1.2;
}

h1 span {
  display: block;
  font-size: 1.3rem;
  margin-top: 0.75rem;
  font-weight: 500;
  color: #6ee7e0;
}

p {
  margin-top: 1.5rem;
  font-size: 1.15rem;
  opacity: 0.9;
}

.buttons {
  margin-top: 2rem;
  display: flex;
  gap: 1rem;
  justify-content: center;
  flex-wrap: wrap;
}

.btn {
  padding: 0.85rem 1.6rem;
  border-radius: 999px;
  font-weight: 600;
  text-decoration: none;
  transition: 0.25s;
}

.primary {
  background: #2dd4bf;
  color: #083344;
}

.primary:hover {
  background: #14b8a6;
  transform: translateY(-2px);
}

.outline {
  border: 2px solid white;
  color: white;
}

.outline:hover {
  background: white;
  color: #0b1f3a;
}
</style>
