import { createRouter, createWebHistory } from "vue-router";
import LoginView from "@/views/LoginView.vue";
import HomeView from "@/views/HomeView.vue";

const routes = [
  { path: "/login", component: LoginView },
  { path: "/", component: HomeView },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
