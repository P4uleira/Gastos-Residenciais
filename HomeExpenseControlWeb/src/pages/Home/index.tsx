import { MenuCard } from "../../components/MenuCard";

export function Home() {
  return (
    <div className="full-center">
      <div className="menu-wrapper">
        <h1 className="title">Menu Principal</h1>

        <div className="menu-grid">
          <MenuCard title="Usuários" to="/users" />
          <MenuCard title="Categorias" to="/categories" />
          <MenuCard title="Transações" to="/transactions" />
          <MenuCard title="Relatório" to="/summaries" />
        </div>
      </div>
    </div>
  );
}