import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getUsers, createUser, deleteUser } from "../../api/user.api";
import type { UserResponse } from "../../models/User";
import InputText from "../../components/InputText";
import Button from "../../components/Button";

export function Users() {
  const [users, setUsers] = useState<UserResponse[]>([]);
  const [name, setName] = useState("");
  const [age, setAge] = useState<number>(0);
  const [loading, setLoading] = useState(false);

  async function loadUsers() {
    setLoading(true);
    const response = await getUsers();
    setUsers(response);
    setLoading(false);
  }

  async function handleCreate() {
    if (!name.trim() || age <= 0){
      alert("Nome e Idade são obrigátorios")
      return ;
    }

    await createUser({
      userName: name,
      userAge: age,
    });

    setName("");
    setAge(0);
    loadUsers();
  }

  async function handleDelete(id: string) {
    if (!confirm("Deseja realmente excluir este usuário?"))
      return;

    await deleteUser(id);
    loadUsers();
  }

  useEffect(() => {
    loadUsers();
  }, []);

  return (
    <div className="container">
      <h1 className="title">Usuários</h1>

      <div className="card" style={{ marginBottom: 30 }}>
        <h3 style={{ marginBottom: 15 }}>
          Criar Usuário
        </h3>

        <div style={{ display: "grid", gridTemplateColumns: "1fr 1fr auto", gap: 12, }} >
          <InputText placeholder="Nome do usuário" value={name} onChange={(e) => setName(e.target.value)}/>

          <InputText type="number"  placeholder="Idade" value={age} onChange={(e) => setAge(Number(e.target.value)) }/>

          <Button onClick={handleCreate}> Criar </Button>
        </div>
      </div>

      <div className="card">
        <h3 style={{ marginBottom: 15 }}>
          Usuários Cadastrados
        </h3>

        {loading && <p>Carregando...</p>}

        {!loading && users.length === 0 && (
          <p>Nenhum usuário cadastrado.</p>
        )}

        <ul>
          {users.map((u) => (
            <li key={u.idUser} style={{display: "flex", justifyContent: "space-between",alignItems: "center", }}>
              <span><strong>{u.userName}</strong>{" "} ({u.userAge} anos) </span>

              <Button onClick={() => handleDelete(u.idUser) } style={{  background: "#ff4d4f", color: "#fff", border: "none", padding: "6px 12px", cursor: "pointer", borderRadius: 6, }} >
                Excluir
              </Button>
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
