import DiContainer from "../../Extensions/DI-container.js";
import PagginationPanel from "../PagginationPanel/PagginationPanel.jsx"
import { useEffect, useState } from "react";
import Car from "./../Car/Car.jsx";
import styles from "./Cars.module.css";
import axios from "axios";

const Cars = () =>{
    useEffect(() => {
        axios.get(`${DiContainer.CarShopUrl}Cars/GetPageCars`)
        .then((response) => {
            setCars(response.data.result);
        })
        .catch(() => {
            console.log("Ошибка при получении данных");
        });
    }, []);

    const [cars, setCars] = useState([]);

    return <>
        {cars.map((car) =>(
            <Car key={car.Id} {...car}/>
        ))}
        <PagginationPanel srcUrl='Cars/GetAll' />
    </>
}

export default Cars;