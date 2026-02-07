<template>
  <section id="services" class="services">
    <h2>Nossos serviços</h2>
    <p class="subtitle">Limpeza profissional, com carinho de casa.</p>

    <div class="grid">
      <div class="card">
        <span>🏠</span>
        <h3>Faxina Residencial</h3>
        <p>
          Limpeza completa com produtos profissionais e atenção a cada detalhe.
        </p>
      </div>

      <div class="card">
        <span>🏖️</span>
        <h3>Casas de Temporada</h3>
        <p>
          Preparação impecável para entrada de hóspedes ou pós-locação.
        </p>
      </div>

      <div class="card">
        <span>🛥️</span>
        <h3>Embarcações Internas</h3>
        <p>
          Higienização cuidadosa de ambientes internos náuticos.
        </p>
      </div>
    </div>
  </section>
</template>

<style scoped>
.services {
  padding: 5rem 1.5rem;
  background: white;
  text-align: center;
}

h2 {
  font-size: 2.2rem;
  font-weight: 800;
  color: #0b1f3a;
}

.subtitle {
  margin-top: 0.75rem;
  color: #475569;
}

.grid {
  margin-top: 3rem;
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(240px, 1fr));
  gap: 1.5rem;
}

.card {
  background: #f8fafc;
  border-radius: 1.25rem;
  padding: 2rem 1.5rem;
  transition: 0.3s;
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.04);
}

.card:hover {
  transform: translateY(-6px);
  box-shadow: 0 18px 32px rgba(0, 0, 0, 0.08);
}

.card span {
  font-size: 2rem;
}

.card h3 {
  margin-top: 1rem;
  font-weight: 700;
  color: #0b1f3a;
}

.card p {
  margin-top: 0.5rem;
  color: #475569;
  font-size: 0.95rem;
}
</style>
