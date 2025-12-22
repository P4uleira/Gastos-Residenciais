export enum TransactionTypeEnum{
    Despesa = 0,
    Receita = 1
}

export interface TransactionResponse{
    idTransaction: string;
    transactionDescription: string;
    transactionAmount: number;
    transactionType: TransactionTypeEnum;
    categoryId: string;
    userId: string;
}

export interface TransactionRequest{
    transactionDescription: string;
    transactionAmount: number;
    transactionType: TransactionTypeEnum;
    categoryId: string;
    userId: string;
}