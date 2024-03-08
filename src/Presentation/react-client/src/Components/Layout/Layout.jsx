import {Outlet as Outlet} from "react-router-dom";
import Header from "../Header/Header.jsx";
import Footer from "../Footer/Footer.jsx";
import styles from "./Layout.css";

const Layout = () =>{
    return <>
        <Header />
        <main className="container-fluid">
            <Outlet />
        </main>

        <Footer />
    </>
}

export default Layout;