import { api } from "./axios";
import type {
  TransactionRequest,
  TransactionResponse,
} from "../models/Transaction";

export async function getTransactions(): Promise<TransactionResponse[]> {
  const response = await api.get<TransactionResponse[]>("/transaction");
  return response.data;
}

export async function getTransactionById(id: string): Promise<TransactionResponse> {
  const response = await api.get<TransactionResponse>(`/transaction/${id}`);
  return response.data;
}

export async function createTransaction(data: TransactionRequest): Promise<TransactionResponse> {
  const response = await api.post<TransactionResponse>("/transaction", data);
  return response.data;
}