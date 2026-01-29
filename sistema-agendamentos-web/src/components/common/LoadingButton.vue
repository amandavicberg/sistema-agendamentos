<script setup>
defineProps({
  loading: {
    type: Boolean,
    default: false
  }
})
</script>

<template>
  <button
    class="btn btn-primary w-100"
    :disabled="loading"
    @click="$emit('click')"
  >
    <span v-if="loading">Carregando...</span>
    <span v-else>
      <slot />
    </span>
  </button>
</template>
