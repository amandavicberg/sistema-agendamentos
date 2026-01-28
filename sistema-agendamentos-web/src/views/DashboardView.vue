<script setup>
import DashboardCard from "@/components/DashboardCard.vue";
</script>

<template>
  <div class="container py-4">
    <h2 class="fw-bold mb-4">Dashboard ✨</h2>

    <div class="row g-4">
      <div class="col-md-4">
        <DashboardCard
          title="Agendamentos hoje"
          value="12"
          icon="bi bi-calendar-check"
          color="primary"
        />
      </div>

      <div class="col-md-4">
        <DashboardCard
          title="Clientes ativos"
          value="87"
          icon="bi bi-people"
          color="success"
        />
      </div>

      <div class="col-md-4">
        <DashboardCard
          title="Faturamento do mês"
          value="R$ 4.280"
          icon="bi bi-cash-stack"
          color="pink"
        />
      </div>
    </div>
  </div>
</template>
