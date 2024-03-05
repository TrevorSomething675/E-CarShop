import DiContainer from "../../Extensions/DI-container.js";
import { useEffect, useState } from "react";
import Car from "./../Car/Car.jsx";
import styles from "./Cars.css";
import axios from "axios";

const Cars = () =>{
    useEffect(() => {
        console.log(DiContainer.CarShopUrl);
        var cars = axios.get(`${DiContainer.CarShopUrl}Cars/GetAll`);
        console.log(cars);
    })
    const [cars, setCars] = useState([]);

    return <div>
        <Car />
        <Car />
    </div>
}

export default Cars;