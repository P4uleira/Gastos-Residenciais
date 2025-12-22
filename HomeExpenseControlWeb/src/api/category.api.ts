import { api } from "./axios";
import type { CategoryRequest, CategoryResponse } from "../models/Category";

export async function getCategories(): Promise<CategoryResponse[]> {
  const response = await api.get<CategoryResponse[]>("/category");
  return response.data;
}

export async function getCategoryById(id: string): Promise<CategoryResponse> {
  const response = await api.get<CategoryResponse>(`/category/${id}`);
  return response.data;
}

export async function createCategory(data: CategoryRequest): Promise<CategoryResponse> {
  const response = await api.post<CategoryResponse>("/category", data);
  return response.data;
}