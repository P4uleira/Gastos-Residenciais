import { Link } from "react-router-dom";

interface MenuCardProps {
  title: string;
  to: string;
}

export function MenuCard({ title, to }: MenuCardProps) {
  return (
    <Link to={to} className="menu-card">
      {title}
    </Link>
  );
}