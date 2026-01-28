<template>
  <form @submit.prevent="submit" class="card">
    <h2>Entrar</h2>
    <p class="subtitle">Bem-vinda de volta, diva do backend 💻</p>

    <div class="field">
      <label>Email</label>
      <input v-model="email" type="email" placeholder="seu@email.com" />
    </div>

    <div class="field">
      <label>Senha</label>
      <input v-model="password" type="password" placeholder="••••••••" />
    </div>

    <AlertMessage v-if="error" :message="error" type="error" />

    <LoadingButton :loading="loading" class="btn-primary">
      Entrar
    </LoadingButton>

    <p class="footer">
      Não tem conta?
      <RouterLink to="/register">Criar agora</RouterLink>
    </p>
  </form>
</template>

<script setup>
import { ref } from "vue";
import AlertMessage from "@/components/AlertMessage.vue";
import LoadingButton from "@/components/LoadingButton.vue";

const emit = defineEmits(["submit"]);

const email = ref("");
const password = ref("");
const error = ref("");
const loading = ref(false);

async function submit() {
  loading.value = true;
  error.value = "";

  try {
    emit("submit", { email: email.value, password: password.value });
  } catch (err) {
    error.value = "Erro ao tentar login";
  } finally {
    loading.value = false;
  }
}
</script>

<style scoped>
.card {
  width: 380px;
  padding: 2.2rem;
  border-radius: 20px;
  background: white;
  box-shadow: 0 20px 50px rgba(0, 0, 0, 0.08);
  display: flex;
  flex-direction: column;
  gap: 1.2rem;
}

h2 {
  margin: 0;
  font-size: 1.6rem;
  color: #6f42c1;
}

.subtitle {
  margin-top: -0.4rem;
  font-size: 0.9rem;
  color: #777;
}

.field {
  display: flex;
  flex-direction: column;
  gap: 0.3rem;
}

label {
  font-size: 0.8rem;
  color: #666;
}

input {
  padding: 0.65rem 0.8rem;
  border-radius: 10px;
  border: 1px solid #ddd;
  outline: none;
  transition: 0.2s;
}

input:focus {
  border-color: #9f7aea;
  box-shadow: 0 0 0 3px rgba(159, 122, 234, 0.15);
}

.btn-primary {
  margin-top: 0.5rem;
}

.footer {
  font-size: 0.8rem;
  text-align: center;
  color: #666;
}

.footer a {
  color: #6f42c1;
  font-weight: 600;
  text-decoration: none;
}
</style>
