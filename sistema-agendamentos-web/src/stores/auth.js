import { defineStore } from "pinia";
import api from "@/api/http";
import { useUserStore } from "./user";

export const useAuthStore = defineStore("auth", {
  state: () => ({
    token: localStorage.getItem("token"),
    email: localStorage.getItem("email"),
  }),

  actions: {
    async login(email, password) {
      const { data } = await api.post("/auth/login", {
        email,
        password,
      });

      this.token = data.token;
      this.email = data.email;
      localStorage.setItem("token", data.token);
      localStorage.setItem("email", data.email);

      const userStore = useUserStore();
      await userStore.fetchProfile();
    },

    async register(payload) {
      const { data } = await api.post("/auth/register", payload);

      this.token = data.token;
      this.email = data.email;
      localStorage.setItem("token", data.token);
      localStorage.setItem("email", data.email);

      const userStore = useUserStore();
      await userStore.fetchProfile();
    },

    logout() {
      this.token = null;
      this.email = null;
      localStorage.clear();

      const userStore = useUserStore();
      userStore.clear();
    },
  },
});
