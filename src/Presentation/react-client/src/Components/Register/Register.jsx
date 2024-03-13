import styles from "./Register.module.css";
import {Link} from "react-router-dom";

const Register = () => {
    return <>
        <form className={styles.formContainer}>
            <h2 className={styles.formHeader}>Регистрация</h2>
            <div className={styles.formBody}>
            <label className={styles.formLabel}>Логин/почта:</label><input className={styles.formInput}/>
                <label className={styles.formLabel}>Пароль:</label><input className={styles.formInput}/>
                <label className={styles.formLabel}>Повторите пароль:</label><input className={styles.formInput}/>
                    <Link to="/Login" className={styles.formButton}>Уже зарегистрированы?</Link>
                    <button className={styles.submitFormButton}>Зарегистрироваться</button>
            </div>
        </form>
    </>
}

export default Register;