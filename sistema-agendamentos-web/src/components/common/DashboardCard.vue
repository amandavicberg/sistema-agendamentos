<script setup>
defineProps({
  title: String,
  value: Number,
  color: {
    type: String,
    default: "primary",
  },
});
</script>

<template>
  <div class="card shadow-sm border-0 rounded-4 h-100">
    <div class="card-body text-center">
      <h6 class="text-muted mb-2">{{ title }}</h6>
      <h3 class="fw-bold" :class="`text-${color}`">{{ value }}</h3>
    </div>
  </div>
</template>