import PaginationPanel from "./../../Components/PaginationPanel/PaginationPanel.jsx";
import Cars from "./../../Components/Cars/Cars.jsx";
import styles from "./CarsPage.module.css";

const HandlePageChange = () =>{
    console.log(1234);
}

const CarsPage = () => {
    return <>
        <Cars />
        <PaginationPanel srcUrl="Cars/GetAll"/>
    </>
}

export default CarsPage;