<template>
  <div class="container py-5">
    <h2>Bem-vinda, diva do backend 💻✨</h2>
    <button @click="logout" class="btn btn-outline-danger mt-3">
      Sair
    </button>
  </div>
</template>

<script setup>
import { useAuthStore } from "@/stores/auth";
import { useRouter } from "vue-router";

const auth = useAuthStore();
const router = useRouter();

function logout() {
  auth.logout();
  router.push("/login");
}
</script>
