import DiContainer from "../../Extensions/DI-container";
import styles from "./PaginationPanel.module.css";
import { useEffect, useState } from "react";
import axios from "axios";

const PaginationPanel = ({srcUrl, onPageChange}) =>{
    useEffect(() => {
        axios.get(`${DiContainer.CarShopUrl}${srcUrl}`)
        .then((response) => {
            setPageNumbers(CreatePaggingModel(response.data.result.length, 8));
        })
    }, []);
    const [pageNumbers, setPageNumbers] = useState([]);

    return <>
        <div className={`${styles.paginnationPanel}`}>
            {pageNumbers.map((page) => {
                return <button className={styles.paggingButton} key={page} onClick={onPageChange} value={page}>
                    {page}
                </button>
            })}
        </div>
    </>
}

const CreatePaggingModel = (items, totalItemsInPage) => {
    let pageNumber = Math.ceil(items / totalItemsInPage);
    let pageNumbers = [];
    for(let i = 1; i <= pageNumber; i++){
        pageNumbers.push(i);
    }
    return pageNumbers;
}

export default PaginationPanel;