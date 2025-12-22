import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {  getUserTotalsAsync,  getOverallTotals,} from "../../api/summary.api";
import type {  UserTotalsRequest,  OverallTotals,} from "../../models/Summary";

export function Summary() {
  const [userTotals, setUserTotals] = useState<UserTotalsRequest[]>([]);
  const [overall, setOverall] = useState<OverallTotals | null>(null);
  const [loading, setLoading] = useState(false);

  async function loadSummary() {
    setLoading(true);

    const [usersResponse, overallResponse] =
      await Promise.all([
        getUserTotalsAsync(),
        getOverallTotals(),
      ]);

    setUserTotals(usersResponse);
    setOverall(overallResponse);

    setLoading(false);
  }

  useEffect(() => {
    loadSummary();
  }, []);

  return (
    <div className="container">
      <h1 className="title">Resumo Financeiro</h1>

      <div className="card" style={{ marginBottom: 30 }}>
        <h3 style={{ marginBottom: 15 }}> Totais por Usuário </h3>

        {loading && <p>Carregando...</p>}

        {!loading && userTotals.length === 0 && (
          <p>Nenhum dado encontrado.</p>
        )}

        <ul>
          {userTotals.map((u) => (
            <li key={u.userName} style={{display: "grid", gridTemplateColumns: "1.5fr 1fr 1fr 1fr", gap: 10, padding: "8px 0", borderBottom: "1px solid #eee",}} >
              <strong>{u.userName}</strong>
              <span>+ R$ {u.totalIncome}</span>
              <span>- R$ {u.totalExpense}</span>
              <span>
                Saldo:{" "}
                <strong style={{ color: u.balance >= 0 ? "green" : "red", }} >
                  R$ {u.balance}
                </strong>
              </span>
            </li>
          ))}
        </ul>
      </div>

      {overall && (
        <div className="card">
          <h3 style={{ marginBottom: 15 }}>
            Total Geral
          </h3>

          <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr 1fr", gap: 20, textAlign: "center", }} >
            <div>
              <strong>Receitas</strong>
              <p style={{ color: "green" }}>
                R$ {overall.totalIncome}
              </p>
            </div>

            <div>
              <strong>Despesas</strong>
              <p style={{ color: "red" }}>
                R$ {overall.totalExpense}
              </p>
            </div>

            <div>
              <strong>Saldo</strong>
              <p style={{ color: overall.balance >= 0 ? "green" : "red", }}>  R$ {overall.balance}</p>
            </div>
          </div>
        </div>
      )}

      <Link to="/" className="back">
        ← Voltar
      </Link>
    </div>
  );
}
