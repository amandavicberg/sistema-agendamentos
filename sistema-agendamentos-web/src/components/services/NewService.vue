<script setup>
import { ref } from "vue";

const props = defineProps({
  errors: {
    type: Array,
    default: () => [],
  },
});

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

      <input v-model="nome" class="form-control mb-2" placeholder="Name" />
      <input v-model="preco" class="form-control mb-2" placeholder="Price" />
      <input v-model="duracaoMinutos" class="form-control mb-2" placeholder="Duration (minutes)" />

      <ul v-if="errors?.length" class="text-danger mb-3">
        <li v-for="(e, i) in errors" :key="i">{{ e }}</li>
      </ul>

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
