import api from "./http";

export const getServices = async () => {
  const { data } = await api.get("/servico");
  return data;
};

export const createServices = async (payload) => {
  const { data } = await api.post("/servico", payload);
  return data;
};

export const updateService = async (id, payload) => {
  const { data } = await api.put(`/servico/${id}`, payload);
  return data;
};

export const deleteService = async (id) => {
  await api.delete(`/servico/${id}`);
};