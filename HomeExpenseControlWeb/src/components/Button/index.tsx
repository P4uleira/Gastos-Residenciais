
import React from "react";
import styles from "../Button/Button.module.css";


const Button = ({ children, ...rest }: React.ButtonHTMLAttributes<HTMLButtonElement>) => {
  return (
    <button className={(styles.botao)} {...rest}>
      {children}
    </button>
  );
};

export default Button;