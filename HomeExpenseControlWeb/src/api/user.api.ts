import { api } from "./axios";
import type { UserRequest, UserResponse } from "../models/User";

export async function getUsers(): Promise<UserResponse[]> {
  const response = await api.get<UserResponse[]>("/user");
  return response.data;
}

export async function getUserById(id: string): Promise<UserResponse> {
  const response = await api.get<UserResponse>(`/user/${id}`);
  return response.data;
}

export async function createUser(data: UserRequest): Promise<UserResponse> {
  const response = await api.post<UserResponse>("/user", data);
  return response.data;
}

export async function deleteUser(id: string): Promise<void> {
  await api.delete(`/user/${id}`);
}