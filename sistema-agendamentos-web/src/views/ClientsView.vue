<script setup>
import { ref, onMounted } from "vue";
import { getClients, createClient } from "@/api/client";
import NewClient from "@/components/clients/NewClient.vue";

const clientes = ref([]);
const showNewModal = ref(false);
const modalErrors = ref([]);

const loadClientes = async () => {
  clientes.value = await getClients();
};

onMounted(loadClientes);

async function salvarCliente(payload) {
  try {
    await createClient(payload);
    showNewModal.value = false;
    modalErrors.value = [];
    loadClientes();
  } catch (err) {
    const apiErrors = err.response?.data?.errors;
    modalErrors.value = apiErrors
      ? Object.values(apiErrors).flat()
      : ["Erro ao cadastrar cliente"];
  }
}
</script>

<template>
  <div class="container py-4">
    <div class="d-flex justify-content-between align-items-center mb-3">
      <h2>💖 Clients</h2>
      <button class="btn btn-primary" @click="showNewModal = true">
        + New Client
      </button>
    </div>

    <p v-if="clientes.length === 0">✨ No clients yet.</p>

    <table v-else class="table table-hover">
      <thead>
        <tr>
          <th>Name</th>
          <th>Email</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="c in clientes" :key="c.id">
          <td>{{ c.nome }}</td>
          <td>{{ c.email }}</td>
          <td>{{ c.telefone }}</td>
        </tr>
      </tbody>
    </table>

    <NewClient
      v-if="showNewModal"
      :errors="modalErrors"
      @close="showNewModal = false"
      @saved="salvarCliente"
    />
  </div>
</template>
