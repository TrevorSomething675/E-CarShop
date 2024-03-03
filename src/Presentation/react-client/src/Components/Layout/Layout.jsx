import {Outlet as Outlet} from "react-router-dom";
import Header from "../Header/Header.jsx";
import Footer from "../Footer/Footer.jsx";
import LayoutStyles from "./Layout.css";

const Layout = () =>{
    return <div>
        <Header />

        <Outlet />

        <Footer />
    </div>
}

export default Layout;