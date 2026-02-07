<script setup>
import { ref, onMounted } from "vue";
import { getServices, createServices } from "@/api/service.js";
import NewService from "@/components/services/NewService.vue";

const servicos = ref([]);
const showNewModal = ref(false);
const modalErrors = ref([]);

const loadServicos = async () => {
  servicos.value = await getServices();
};

onMounted(loadServicos);

async function salvarServico(payload) {
  try {
    await createService(payload);
    showNewModal.value = false;
    modalErrors.value = [];
    loadServicos();
  } catch (err) {
    const apiErrors = err.response?.data?.errors;
    modalErrors.value = apiErrors
      ? Object.values(apiErrors).flat()
      : ["Erro ao cadastrar serviço"];
  }
}
</script>

<template>
  <div class="container py-4">
    <div class="d-flex justify-content-between align-items-center mb-3">
      <h2>💖 Services</h2>
      <button class="btn btn-primary" @click="showNewModal = true">
        + New Service
      </button>
    </div>

    <p v-if="servicos.length === 0">✨ No services yet.</p>

    <table v-else class="table table-hover">
      <thead>
        <tr>
          <th>Name</th>
          <th>Price</th>
          <th>Duration (min)</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="s in servicos" :key="s.id">
          <td>{{ s.nome }}</td>
          <td>{{ s.preco }}</td>
          <td>{{ s.duracaoMinutos }}</td>
        </tr>
      </tbody>
    </table>

    <NewService
      v-if="showNewModal"
      :errors="modalErrors"
      @close="showNewModal = false"
      @saved="salvarServico"
    />
  </div>
</template>
