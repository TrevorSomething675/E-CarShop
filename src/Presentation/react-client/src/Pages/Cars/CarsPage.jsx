import PaginationPanel from "./../../Components/PaginationPanel/PaginationPanel.jsx";
import Cars from "./../../Components/Cars/Cars.jsx";
import styles from "./CarsPage.module.css";
import {useState} from 'react';


const CarsPage = () => {
    const HandlePageChange = (event) => {
        setPageNumber(event.target.value);
    }
    const [pageNumber, setPageNumber] = useState(1);

    return <>
        <Cars pageNumber={pageNumber}/>
        <PaginationPanel srcUrl="Cars/GetAll" onPageChange={HandlePageChange}/>
    </>
}

export default CarsPage;