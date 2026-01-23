import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:5250/api"
});

api.interceptors.request.use(config => {
  if (!config.url.includes("/auth")) {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
  }
  return config;
});

export default api;
