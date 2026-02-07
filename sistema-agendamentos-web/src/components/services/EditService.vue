<script setup>
import { ref, watch } from "vue";

const props = defineProps({
  service: Object,
});

const emit = defineEmits(["close", "updated"]);

const nome = ref("");
const preco = ref("");
const duracaoMinutos = ref("");

watch(
  () => props.service,
  (c) => {
    if (!c) return;
    nome.value = c.nome;
    preco.value = c.preco;
    duracaoMinutos.value = c.duracaoMinutos;
  },
  { immediate: true }
);

function salvar() {
  emit("updated", {
    ...props.service,
    nome: nome.value,
    preco: Number(preco.value),
    duracaoMinutos: Number(duracaoMinutos.value),
  });
}
</script>

<template>
  <div class="modal-backdrop-custom">
    <div class="modal-card">
      <h5 class="mb-3">✨ Edit Service</h5>

      <input v-model="nome" class="form-control mb-2" placeholder="Name" />
      <input v-model="email" class="form-control mb-2" placeholder="Email" />
      <input v-model="telefone" class="form-control mb-4" placeholder="Phone" />

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
