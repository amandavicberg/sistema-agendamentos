import ClientsView from "@/views/ClientsView.vue";
import LoginView from "@/views/LoginView.vue";
import RegisterView from "@/views/RegisterView.vue";
import ServicesView from "@/views/ServicesView.vue";
import { createRouter, createWebHistory } from "vue-router";
import DashboardView from "../views/DashboardView.vue";
import LandingView from '@/views/LandingView.vue'

const routes = [
  { path: "/", redirect: "/landing" },
  { path: '/landing', component: LandingView },
  { path: "/login", component: LoginView },
  { path: "/register", component: RegisterView },
  { path: "/dashboard", component: DashboardView },
  { path: "/clients", component: ClientsView },
  { path: "/services", component: ServicesView },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
