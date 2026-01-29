<template>
  <header class="header">
    <div class="brand">Bergamasco Clean✨</div>

    <nav class="nav">
      <RouterLink to="/login" class="link">Entrar</RouterLink>
      <RouterLink to="/register" class="btn">Cadastrar</RouterLink>
      <router-link to="/clients" class="nav-link">Clientes</router-link>
      <router-link to="/services" class="nav-link">Serviços</router-link>
    </nav>
  </header>
</template>

<script setup>
import { RouterLink } from "vue-router";
</script>

<style scoped>
.header {
  height: 72px;
  padding: 0 2rem;
  display: flex;
  align-items: center;
  justify-content: space-between;
  background: linear-gradient(135deg, #fff, #f9f5ff);
  border-bottom: 1px solid #eee;
  position: sticky;
  top: 0;
  z-index: 50;
}

.brand {
  font-size: 1.4rem;
  font-weight: 700;
  color: #6f42c1;
  letter-spacing: 0.5px;
}

.nav {
  display: flex;
  align-items: center;
  gap: 1.2rem;
}

.link {
  text-decoration: none;
  font-weight: 500;
  color: #555;
  transition: 0.2s;
}

.link:hover {
  color: #6f42c1;
}

.btn {
  background: linear-gradient(135deg, #9f7aea, #6f42c1);
  color: white;
  padding: 0.45rem 1.1rem;
  border-radius: 999px;
  font-weight: 600;
  text-decoration: none;
  box-shadow: 0 4px 12px rgba(159, 122, 234, 0.35);
  transition: 0.25s ease;
}

.btn:hover {
  transform: translateY(-1px);
  box-shadow: 0 6px 16px rgba(159, 122, 234, 0.45);
}
</style>
