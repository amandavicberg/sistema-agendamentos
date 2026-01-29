<script setup>
import { ref } from "vue";
import { useAuthStore } from "@/stores/auth";
import { useRouter } from "vue-router";

const nome = ref("");
const email = ref("");
const password = ref("");
const confirmPassword = ref("");

const loading = ref(false);
const errorMessage = ref("");

const auth = useAuthStore();
const router = useRouter();

async function handleRegister() {
  errorMessage.value = "";

  if (password.value !== confirmPassword.value) {
    errorMessage.value = "As senhas não coincidem";
    return;
  }

  loading.value = true;
  try {
    await auth.register({
      nome: nome.value,
      email: email.value,
      password: password.value
    });
    router.push("/");
  } catch (err) {
    errorMessage.value = err.response?.data || "Erro ao cadastrar";
  } finally {
    loading.value = false;
  }
}
</script>

<template>
  <div class="card shadow-lg p-4 rounded-4" style="width: 420px">
    <h3 class="text-center fw-bold text-primary mb-1">
      Criar conta ✨
    </h3>
    <p class="text-center text-muted mb-4">
      Comece sua jornada Bergamasco Clean 💖
    </p>

    <input
      v-model="nome"
      type="text"
      class="form-control mb-3"
      placeholder="Nome completo"
    />

    <input
      v-model="email"
      type="email"
      class="form-control mb-3"
      placeholder="Email"
    />

    <input
      v-model="password"
      type="password"
      class="form-control mb-3"
      placeholder="Senha"
    />

    <input
      v-model="confirmPassword"
      type="password"
      class="form-control mb-3"
      placeholder="Confirmar senha"
    />

    <button
      @click="handleRegister"
      class="btn btn-primary w-100 py-2"
      :disabled="loading"
    >
      <span v-if="loading">Criando conta...</span>
      <span v-else>Cadastrar</span>
    </button>

    <p v-if="errorMessage" class="text-danger text-center mt-3">
      {{ errorMessage }}
    </p>

    <div class="text-center mt-3">
      <router-link to="/login">Já tenho conta</router-link>
    </div>
  </div>
</template>
