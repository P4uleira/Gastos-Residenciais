import type { OverallTotals, UserTotalsRequest } from "../models/Summary";
import { api } from "./axios";

export async function getUserTotalsAsync(): Promise<UserTotalsRequest[]> {
    const response = await api.get<UserTotalsRequest[]>("/transaction/totals");
    return response.data;
}

export async function getOverallTotals(): Promise<OverallTotals> {
    const response = await api.get<OverallTotals>("/transaction/overall_totals");
    return response.data;
}