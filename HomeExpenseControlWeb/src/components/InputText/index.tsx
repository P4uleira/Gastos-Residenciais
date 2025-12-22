import React from "react";
import styles from "../InputText/InputText.module.css";

const InputText = ({ ...props }: React.InputHTMLAttributes<HTMLInputElement>) => {
    return (  
        <div className={styles.container}>     
            <input className={styles.InputText} {...props} />
        </div>
    )
};
  
export default InputText;

