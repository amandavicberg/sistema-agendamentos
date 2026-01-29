<script setup>
import { ref, onMounted } from "vue";
import { getServices, createServices } from "@/api/service";
import NewService from "@/components/services/NewService.vue";

const servicos = ref([]);
const showModal = ref(false);
const loading = ref(true);

const loadServicos = async () => {
  loading.value = true;
  servicos.value = await getServicos();
  loading.value = false;
};

onMounted(loadServicos);

async function salvarServico(payload) {
  await createServico(payload);
  showModal.value = false;
  loadServicos();
}
</script>

<template>
  <div class="container py-4">
    <div class="d-flex justify-content-between align-items-center mb-3">
      <h2>💜 Services</h2>
      <button class="btn btn-primary" @click="showModal = true">
        + New Service
      </button>
    </div>

    <p v-if="loading">Loading services...</p>

    <p v-else-if="servicos.length === 0">
      ✨ No services yet.
    </p>

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
      v-if="showModal"
      @close="showModal = false"
      @saved="salvarServico"
    />
  </div>
</template>
