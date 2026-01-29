import api from "./http";

export const getServices = async () => {
  const { data } = await api.get("/servico");
  return data;
};

export const createServices = async (payload) => {
  const { data } = await api.post("/servico", payload);
  return data;
};
