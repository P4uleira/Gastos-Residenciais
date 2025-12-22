export enum CategoryPurposeEnum{
    Despesa = 0,
    Receita = 1,
    Ambas = 2
}

export interface CategoryResponse{
    idCategory: string;
    categoryDescription: string;
    categoryPurpose: CategoryPurposeEnum;
}

export interface CategoryRequest{
    categoryDescription: string;
    categoryPurpose: CategoryPurposeEnum;
}