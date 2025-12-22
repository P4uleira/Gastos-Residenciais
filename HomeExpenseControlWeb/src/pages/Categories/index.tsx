import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {  getCategories,  createCategory,} from "../../api/category.api";
import {  CategoryPurposeEnum,  type CategoryResponse,} from "../../models/Category";
import InputText from "../../components/InputText";
import Button from "../../components/Button";
import SelectorGroup from "../../components/Selector/SelectorGroup";
import SelectorOption from "../../components/Selector/SelectorOption";

export function Category() {
  const [categories, setCategories] = useState<CategoryResponse[]>([]);
  const [description, setDescription] = useState("");
  const [purpose, setPurpose] = useState<CategoryPurposeEnum>(CategoryPurposeEnum.Despesa);
  const [loading, setLoading] = useState(false);

  async function loadCategories() {
    setLoading(true);
    const response = await getCategories();
    setCategories(response);
    setLoading(false);
  }

  async function handleCreate() {
    if (!description.trim()) return;

    await createCategory({
      categoryDescription: description,
      categoryPurpose: purpose,
    });

    setDescription("");
    setPurpose(CategoryPurposeEnum.Despesa);
    loadCategories();
  }

  useEffect(() => {
    loadCategories();
  }, []);

  function renderPurpose(purpose: CategoryPurposeEnum) {
    switch (purpose) {
      case CategoryPurposeEnum.Despesa:
        return "Despesa";
      case CategoryPurposeEnum.Receita:
        return "Receita";
      case CategoryPurposeEnum.Ambas:
        return "Ambas";
      default:
        return "-";
    }
  }

  return (
    <div className="container">
      <h1 className="title">Categorias</h1>

      <div className="card" style={{ marginBottom: 30 }}>
        <h3 style={{ marginBottom: 15 }}>Criar Categoria</h3>

        <div style={{ display: "flex", gap: 10, flexWrap: "wrap" }}>
          <InputText placeholder="Descrição da categoria" value={description} onChange={(e) => setDescription(e.target.value)} />

          <SelectorGroup value={purpose} onChange={(e) => setPurpose(Number(e.target.value) as CategoryPurposeEnum) }>
            <SelectorOption value={CategoryPurposeEnum.Despesa} label="Despesa" />
            <SelectorOption value={CategoryPurposeEnum.Receita} label="Receita" />
            <SelectorOption value={CategoryPurposeEnum.Ambas} label="Ambas" />
          </SelectorGroup>

          <Button onClick={handleCreate}>
            Criar
          </Button>
        </div>
      </div>

      <div className="card">
        <h3 style={{ marginBottom: 15 }}>Categorias Cadastradas</h3>

        {loading && <p>Carregando...</p>}

        {!loading && categories.length === 0 && (
          <p>Nenhuma categoria cadastrada.</p>
        )}

        <ul>
          {categories.map((c) => (
            <li key={c.idCategory} style={{ marginBottom: 8 }}>
              <strong>{c.categoryDescription}</strong> —{" "}
              {renderPurpose(c.categoryPurpose)}
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