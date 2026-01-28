import { defineStore } from "pinia";
import api from "@/api/http";

export const useUserStore = defineStore("user", {
  state: () => ({
    profile: null,
  }),

  actions: {
    async fetchProfile() {
      const { data } = await api.get("/users/me");
      this.profile = data;
    },

    clear() {
      this.profile = null;
    },
  },
});
