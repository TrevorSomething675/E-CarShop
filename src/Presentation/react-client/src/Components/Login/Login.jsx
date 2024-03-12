import styles from "./Login.module.css";

const Login = () => {
    return <>
        <form className={styles.formContainer}>
            <h2 className={styles.formHeader}>Вход</h2>
            <div className={styles.formBody}>
                <label className={styles.formLabel}>Логин:</label><input className={styles.formInput}/>
                <label className={styles.formLabel}>Пароль:</label><input className={styles.formInput}/>
                <div>
                    <button className={styles.formButton}>Забыли пароль?</button>
                </div>
                <button className={styles.submitFormButton}>Войти</button>
            </div>
        </form>

        <div className={styles.formFooter}>
            <button className={styles.formFooterButton}>Создать аккаунт</button>
            <div className={styles.description}>
                После регистрации вы получите доступ ко всем автомобилям и дополнительным возможностям
            </div>
        </div>
    </>
}

export default Login;