<template>
  <div class="page">
    <div class="left">
      <h1>Sistema de Agendamentos</h1>
      <p>
        Organize seus clientes, horários e seu caos emocional profissional em
        um só lugar.
      </p>
    </div>

    <LoginForm @submit="handleLogin" />
  </div>
</template>

<script setup>
import LoginForm from "@/components/LoginForm.vue";
import { useAuthStore } from "@/stores/auth";
import { useRouter } from "vue-router";

const auth = useAuthStore();
const router = useRouter();

async function handleLogin({ email, password }) {
  await auth.login(email, password);
  router.push("/");
}
</script>

<style scoped>
.page {
  min-height: 100vh;
  display: grid;
  grid-template-columns: 1fr 420px;
  align-items: center;
  padding: 0 6vw;
  background: linear-gradient(135deg, #faf7ff, #fdfcff);
}

.left h1 {
  font-size: 2.8rem;
  color: #6f42c1;
  margin-bottom: 0.8rem;
}

.left p {
  max-width: 420px;
  font-size: 1.05rem;
  color: #666;
}
</style>
