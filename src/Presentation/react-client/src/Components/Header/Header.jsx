import styles from "./Header.css";
import {Link} from "react-router-dom";

const Header = () => {
    return <header>
        <div className="header-section">
            <div className="header-item header-logo">
                <Link to="/Home/Info">
                    E-Car Shop
                </Link>
            </div>
            <div className="header-item">
                <Link to="/Cars">
                    Машины
                </Link>
            </div>
            <div className="header-item">
                <Link to="/CreateCar">
                    Добавить машину
                </Link>
            </div>
            <div className="header-item">
                <Link to="/Users">
                    Пользователи
                </Link>
            </div>
            <div className="header-item">
                <Link to="Info">
                    О нас
                </Link>
            </div>
        </div>
        <div className="header-section">
            <div className="header-item">
                <Link to="/Register">
                    Регистрация
                </Link>
            </div>
            <div className="header-item">
                <Link to="/Login">
                    Логин
                </Link>
            </div>
        </div>
    </header>
}

export default Header