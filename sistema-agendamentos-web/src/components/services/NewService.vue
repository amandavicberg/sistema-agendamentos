<script setup>
import { ref } from "vue";

const emit = defineEmits(["close", "saved"]);

const nome = ref("");
const preco = ref("");
const duracaoMinutos = ref("");

function salvar() {
  emit("saved", {
    nome: nome.value,
    preco: Number(preco.value),
    duracaoMinutos: Number(duracaoMinutos.value),
  });
}
</script>

<template>
  <div class="modal-backdrop-custom">
    <div class="modal-card">
      <h5 class="mb-3">💖 New Service</h5>

      <input v-model="nome" class="form-control mb-2" placeholder="Service name" />
      <input v-model="preco" type="number" class="form-control mb-2" placeholder="Price" />
      <input v-model="duracaoMinutos" type="number" class="form-control mb-4" placeholder="Duration (minutes)" />

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
