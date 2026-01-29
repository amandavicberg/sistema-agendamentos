<script setup>
import { ref, onMounted } from "vue";
import { getClients } from "@/api/client";
import { getServices } from "@/api/service";
import { createAppointment } from "@/api/appointment";

const emit = defineEmits(["close", "saved"]);

const clientes = ref([]);
const servicos = ref([]);

const clienteId = ref("");
const servicoId = ref("");
const dataHora = ref("");

onMounted(async () => {
  clientes.value = await getClients();
  servicos.value = await getServices();
});

async function salvar() {
  await createAppointment({
    clienteId: clienteId.value,
    servicoId: servicoId.value,
    dataHora: dataHora.value,
  });

  emit("saved");
  emit("close");
}
</script>

<template>
  <div class="modal-backdrop-custom">
    <div class="modal-card">
      <h5 class="mb-3">✨ New Appointment</h5>

      <select v-model="clientId" class="form-select mb-3">
        <option disabled value="">Select a client</option>
        <option v-for="c in clients" :key="c.id" :value="c.id">
          {{ c.nome }}
        </option>
      </select>

      <select v-model="serviceId" class="form-select mb-3">
        <option disabled value="">Select a service</option>
        <option v-for="s in services" :key="s.id" :value="s.id">
          {{ s.nome }}
        </option>
      </select>

      <input
        type="datetime-local"
        v-model="dateTime"
        class="form-control mb-4"
      />

      <div class="d-flex justify-content-end gap-2">
        <button class="btn btn-outline-secondary" @click="$emit('close')">
          Cancel
        </button>
        <button class="btn btn-primary" @click="salvar">
          Save
        </button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.modal-backdrop-custom {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.4);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 999;
}

.modal-card {
  background: white;
  padding: 1.5rem;
  border-radius: 16px;
  width: 380px;
}
</style>
