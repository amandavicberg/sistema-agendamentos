<script setup>
import { useAuthStore } from "@/stores/auth";
import { ref } from "vue";
import { useRouter } from "vue-router";

const email = ref("");
const password = ref("");
const auth = useAuthStore();
const router = useRouter();
const loading = ref(false);
const errorMessage = ref("");

async function handleLogin() {
  loading.value = true;
  errorMessage.value = "";
  try {
    await auth.login(email.value, password.value); // <-- deve chamar o store
    router.push("/");
  } catch (err) {
    errorMessage.value = err.message; // vai mostrar "Email ou senha inválidos"
  } finally {
    loading.value = false;
  }
}

</script>

<template>
  <div class="d-flex vh-100 justify-content-center align-items-center bg-light">
    <div class="card shadow p-4 rounded-4" style="width: 380px">
      <h3 class="text-center text-primary mb-4">Sistema de Agendamentos 💅</h3>

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

      <button
        @click="handleLogin"
        class="btn btn-primary w-100"
        :disabled="loading"
      >
        <span v-if="loading">Entrando..</span>
        <span v-else>Entrar</span>
      </button>

      <div class="mt-3 text-center">
        <router-link to="/register">Criar conta</router-link> |
        <router-link to="/forgot-password">Esqueci a senha</router-link>
      </div>

      <p v-if="errorMessage" class="text-danger text-center">
        {{ errorMessage }}
      </p>
    </div>
  </div>
</template>
