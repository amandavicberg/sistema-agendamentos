import api from "./http";

export const getAppointments = async () => {
  const { data } = await api.get("/agendamento");
  return data;
};

export const createAppointment = async (payload) => {
  const { data } = await api.post("/agendamento", payload);
  return data;
};
