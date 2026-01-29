import api from "./http";

export const getClients = async () => {
  const { data } = await api.get("/cliente");
  return data;
};

export const createClient = async (payload) => {
  const { data } = await api.post("/cliente", payload);
  return data;
};

export const updateClient = async (id, payload) => {
  const { data } = await api.put(`/cliente/${id}`, payload);
  return data;
};

export const deleteClient = async (id) => {
  await api.delete(`/cliente/${id}`);
};
