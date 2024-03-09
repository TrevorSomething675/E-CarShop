import styles from "./Header.module.css";
import {Link} from "react-router-dom";
/*import icon from "./cars.svg";*/
/*<img src={icon} className={styles.iconHeader}></img>*/

const Header = () => {
    return <header className={styles.header}>
        <div className={styles.headerSection}>
            <div className={`${styles.headerItem}, ${styles.headerLogo}`}>
                <Link to="/Home/Info">
                    E-Car Shop
                </Link>
            </div>
            <div className={styles.headerItem}>
                <Link to="/Cars">
                    Машины
                </Link>
            </div>
            <div className={styles.headerItem}>
                <Link to="/CreateCar">
                    <i className="bi bi-plus-circle"></i>
                    Добавить машину
                </Link>
            </div>
            <div className={styles.headerItem}>
                <Link to="/Users">
                    <i className="bi bi-people"></i>
                    Пользователи
                </Link>
            </div>
            <div className={styles.headerItem}>
                <Link to="Info">
                    <i className="bi bi-info-circle"></i>
                    О нас
                </Link>
            </div>
        </div>
        <div className={styles.headerSection}>
            <div className={styles.headerItem}>
                <Link to="/Register">
                    Регистрация
                </Link>
            </div>
            <div className={styles.headerItem}>
                <Link to="/Login">
                    Логин
                </Link>
            </div>
        </div>
    </header>
}

export default Header