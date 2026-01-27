import { defineStore } from "pinia";

export const useAuthStore = defineStore("auth", {
  state: () => ({
    token: localStorage.getItem("token"),
    email: localStorage.getItem("email"),
  }),

  actions: {
    async login(email, password) {
      // LOGIN FAKE DEV MODE
      console.log("Tentando login fake:", email, password); // <--- debug
      if (email === "admin@bergamasco.com" && password === "123456") {
        this.token = "fake-jwt-token";
        this.email = email;
        localStorage.setItem("token", this.token);
        localStorage.setItem("email", email);
        return;
      }

      throw new Error("Email ou senha inválidos");
    },

    logout() {
      this.token = null;
      this.email = null;
      localStorage.clear();
    }
  }
});