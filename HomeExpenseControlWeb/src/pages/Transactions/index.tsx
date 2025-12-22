import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getTransactions, createTransaction } from "../../api/transaction.api";
import { getUsers } from "../../api/user.api";
import { getCategories } from "../../api/category.api";
import { TransactionTypeEnum, type TransactionResponse, } from "../../models/Transaction";
import type { UserResponse } from "../../models/User";
import { CategoryPurposeEnum, type CategoryResponse, } from "../../models/Category";
import InputText from "../../components/InputText";
import Button from "../../components/Button";
import SelectorGroup from "../../components/Selector/SelectorGroup";
import SelectorOption from "../../components/Selector/SelectorOption";

export function Transactions() {
  const [transactions, setTransactions] = useState<TransactionResponse[]>([]);
  const [users, setUsers] = useState<UserResponse[]>([]);
  const [categories, setCategories] = useState<CategoryResponse[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [description, setDescription] = useState("");
  const [amount, setAmount] = useState<number>(0);
  const [type, setType] = useState<TransactionTypeEnum>(TransactionTypeEnum.Despesa);
  const [userId, setUserId] = useState("");
  const [categoryId, setCategoryId] = useState("");

  async function loadData() {
    const [transactionList, userList, categoryList] = await Promise.all([ getTransactions(), getUsers(), getCategories(), ]);
    setTransactions(transactionList);
    setUsers(userList);
    setCategories(categoryList);
  }

  async function handleCreate() {
    setError(null);

    try {
      await createTransaction({
        transactionDescription: description,
        transactionAmount: amount,
        transactionType: type,
        userId,
        categoryId,
      });

      setDescription("");
      setAmount(0);
      setUserId("");
      setCategoryId("");

      loadData();
    } catch (err: any) {
      setError(
        err?.response?.data?.message ??
          err?.response?.data ??
          "Erro ao criar transação"
      );
    }
  }

  useEffect(() => {
    loadData();
  }, []);

  useEffect(() => {
    setCategoryId("");
  }, [type]);

  function renderType(type: TransactionTypeEnum) {
    return type === TransactionTypeEnum.Despesa
      ? "Despesa"
      : "Receita";
  }

  function filteredCategories() {
    return categories.filter((c) => {
      const purpose =
        typeof c.categoryPurpose === "string"
          ? Number(c.categoryPurpose)
          : c.categoryPurpose;

      return (
        purpose === CategoryPurposeEnum.Ambas ||
        (type === TransactionTypeEnum.Despesa &&
          purpose === CategoryPurposeEnum.Despesa) ||
        (type === TransactionTypeEnum.Receita &&
          purpose === CategoryPurposeEnum.Receita)
      );
    });
  }

  return (
    <div className="container">
      <h1 className="title">Transações</h1>

      <div className="card" style={{ marginBottom: 30 }}>
        <h3 style={{ marginBottom: 15 }}>Criar Transação</h3>

        {error && (
          <p style={{ color: "red", marginBottom: 10 }}>
            {error}
          </p>
        )}

        <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr", gap: 12, alignItems: "center", justifyContent: "center", }}>
          <SelectorGroup value={type} onChange={(e) => setType(Number(e.target.value) as TransactionTypeEnum)}>
            <SelectorOption value={TransactionTypeEnum.Despesa} label="Despesa" />
            <SelectorOption value={TransactionTypeEnum.Receita} label="Receita" /> 
          </SelectorGroup>
          
          <InputText placeholder="Descrição" value={description} onChange={(e) => setDescription(e.target.value)} />

          <InputText type="number" placeholder="Idade" value={amount} onChange={(e) => setAmount(Number(e.target.value))} />

          <SelectorGroup value={userId} onChange={(e) => setUserId(e.target.value)} >
            <SelectorOption value="" label="Selecione um usuário" />{users.map((u) => (<SelectorOption key={u.idUser} value={u.idUser} label={u.userName} />))}
          </SelectorGroup>

          <SelectorGroup value={categoryId} onChange={(e) => setCategoryId(e.target.value)} >
            <SelectorOption value="" label="Selecione uma categoria" /> {filteredCategories().map((c) => (<SelectorOption key={c.idCategory} value={c.idCategory} label={c.categoryDescription} /> ))}
          </SelectorGroup>  
        </div>

        <Button onClick={handleCreate}>
          Criar Transação
        </Button>
      </div>

      <div className="card">
        <h3 style={{ marginBottom: 15 }}>
          Transações Cadastradas
        </h3>

        {transactions.length === 0 && (
          <p>Nenhuma transação cadastrada.</p>
        )}

        <ul>
          {transactions.map((t) => (
            <li key={t.idTransaction}>
              <strong>{t.transactionDescription}</strong> — R$ {t.transactionAmount} —{" "} {renderType(t.transactionType)}
            </li>
          ))}
        </ul>
      </div>

      <Link to="/" className="back">
        ← Voltar
      </Link>
    </div>
  );
}
