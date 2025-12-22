export interface UserTotalsRequest{
    userName: string
    totalIncome: number;
    totalExpense: number;
    balance: number;
}

export interface OverallTotals{
    totalIncome: number;
    totalExpense: number;
    balance: number;
}