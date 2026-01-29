<script setup>
import { ref, onMounted } from "vue";
import { getAppointments } from "@/api/appointment";
import NewAppointment from "@/components/appointments/NewAppointment.vue";

const appointments = ref([]);
const loading = ref(true);

const loadAppointments = async () => {
  loading.value = true;
  appointments.value = await getAppointment();
  loading.value = false;
};

onMounted(loadAppointments);
</script>

<template>
  <div class="container py-4">
    <div class="d-flex justify-content-between align-items-center mb-3">
      <h2>📅 Appointments</h2>
      <NewAppointment @saved="loadAppointments" />
    </div>

    <p v-if="loading">Loading appointments...</p>

    <p v-else-if="appointments.length === 0">
      ✨ No appointments yet. Create your first one.
    </p>

    <table v-else class="table table-hover align-middle">
      <thead>
        <tr>
          <th>Date</th>
          <th>Status</th>
          <th>Client</th>
          <th>Service</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="a in appointments" :key="a.id">
          <td>{{ new Date(a.dataHora).toLocaleString() }}</td>
          <td>
            <span class="badge bg-secondary">{{ a.status }}</span>
          </td>
          <td>{{ a.clienteNome }}</td>
          <td>{{ a.servicoNome }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
