import HeaderStyles from "./Header.css";
import {Link} from "react-router-dom";

const Header = () => {
    return <div>
        <h2>Header</h2>

        <ul>
            <li>
                <Link to="/Auth">Auth</Link>
            </li>
            <li>
                <Link to="/Cars">Cars</Link>
            </li>
        </ul>
    </div>
}

export default Header