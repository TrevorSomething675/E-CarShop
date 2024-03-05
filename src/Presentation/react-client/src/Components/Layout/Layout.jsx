import {Outlet as Outlet} from "react-router-dom";
import Header from "../Header/Header.jsx";
import Footer from "../Footer/Footer.jsx";
import styles from "./Layout.css";

const Layout = () =>{
    return <div>
        <Header />
        <main>
            <Outlet />
        </main>

        <Footer />
    </div>
}

export default Layout;