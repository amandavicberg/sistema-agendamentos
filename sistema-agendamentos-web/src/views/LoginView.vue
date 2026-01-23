<script setup>
import { ref } from "vue";
import { useAuthStore } from "@/stores/auth";
import { useRouter } from "vue-router";

const email = ref("");
const password = ref("");
const auth = useAuthStore();
const router = useRouter();

async function handleLogin() {
  try {
    await auth.login(email.value, password.value);
    router.push("/");
  } catch (err) {
    console.error("ERRO LOGIN:", err.response?.data || err);
    alert("Email ou senha inválidos");
  }
}
</script>

<template>
  <div class="d-flex vh-100 justify-content-center align-items-center bg-light">
    <div class="card shadow p-4 rounded-4" style="width: 380px;">
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

      <button @click="handleLogin" class="btn btn-primary w-100">
        Entrar
      </button>
    </div>
  </div>
</template>
