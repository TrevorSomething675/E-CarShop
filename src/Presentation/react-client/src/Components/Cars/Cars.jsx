import DiContainer from "../../Extensions/DI-container.js";
import { useEffect, useState } from "react";
import Car from "./../Car/Car.jsx";
import styles from "./Cars.css";
import axios from "axios";

const Cars = () =>{
    useEffect(() => {
        console.log(DiContainer.CarShopUrl);
        axios.get(`${DiContainer.CarShopUrl}Cars/GetAll`)
        .then((response) => {
            console.log(response.data.result);
            setCars(response.data.result);
        })
        .catch(() => {
            console.log("Ошибка при получении данных");
        });
    }, []);

    const [cars, setCars] = useState([]);

    return <>
        {cars.map((car) =>(
            <Car key={car.id} {...car}/>
        ))}
    </>
}

export default Cars;