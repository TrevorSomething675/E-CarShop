import {Outlet as Outlet} from "react-router-dom";
import Header from "../Header/Header.jsx";
import Footer from "../Footer/Footer.jsx";
import styles from "./Layout.module.css";

const Layout = () =>{
    return <>
        <Header />

        <main className={`${styles.main} container-fluid d-flex`}>
            <Outlet />
        </main>

        <Footer />
    </>
}

export default Layout;