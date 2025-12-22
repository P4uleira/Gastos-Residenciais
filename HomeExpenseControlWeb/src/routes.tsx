import { Routes, Route } from "react-router-dom";
import { Users } from "./pages/Users";
import { Category } from "./pages/Categories";
import { Transactions } from "./pages/Transactions";
import { Summary } from "./pages/Summary"
import { Home } from "./pages/Home";

export function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/users" element={<Users />} />
      <Route path="/categories" element={<Category />} />
      <Route path="/transactions" element={<Transactions />} />
      <Route path="/summaries" element={<Summary />} />
    </Routes>
  );
}