<script setup>
defineProps({
  message: String
});
</script>

<template>
  <div v-if="message" class="alert alert-danger text-center mt-3">
    {{ message }}
  </div>
</template>