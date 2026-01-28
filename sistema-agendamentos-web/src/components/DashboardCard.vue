<script setup>
defineProps({
  title: String,
  value: [String, Number],
  icon: String,
  color: {
    type: String,
    default: "primary"
  }
});
</script>

<template>
  <div class="dashboard-card shadow-sm rounded-4 p-4 h-100">
    <div class="d-flex justify-content-between align-items-center mb-3">
      <div>
        <p class="text-muted mb-1 small fw-semibold">{{ title }}</p>
        <h3 class="fw-bold mb-0">{{ value }}</h3>
      </div>

      <div :class="`icon-circle bg-${color} bg-opacity-10 text-${color}`">
        <i :class="icon"></i>
      </div>
    </div>
  </div>
</template>

<style scoped>
.dashboard-card {
  background: rgba(255, 255, 255, 0.75);
  backdrop-filter: blur(8px);
  border: 1px solid rgba(255, 255, 255, 0.4);
  transition: all 0.25s ease;
}

.dashboard-card:hover {
  transform: translateY(-3px);
  box-shadow: 0 12px 28px rgba(0, 0, 0, 0.08);
}

.icon-circle {
  width: 46px;
  height: 46px;
  border-radius: 14px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.3rem;
}
</style>
