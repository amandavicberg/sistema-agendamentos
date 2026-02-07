<template>
  <section class="contact">
    <h2>Vamos deixar tudo brilhando?</h2>
    <p>Chama a gente e resolvemos isso rapidinho 👇</p>

    <div class="buttons">
      <a
        href="https://wa.me/5524992228265"
        target="_blank"
        class="btn primary"
      >
        WhatsApp 💬
      </a>

      <a
        href="https://www.instagram.com/bergamascoclean"
        target="_blank"
        class="btn outline"
      >
        Instagram 📸
      </a>

      <a
        href="https://www.facebook.com/BergamascoClean"
        target="_blank"
        class="btn outline"
      >
        Facebook 📘
      </a>
    </div>
  </section>
</template>

<style scoped>
.contact {
  padding: 5rem 1.5rem;
  background: #0b1f3a;
  color: white;
  text-align: center;
}

h2 {
  font-size: 2rem;
  font-weight: 800;
}

p {
  margin-top: 0.75rem;
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
  padding: 0.8rem 1.6rem;
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
