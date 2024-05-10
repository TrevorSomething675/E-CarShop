import $api from "../../Middlewares/JWTtokenMiddleware.js";
import DiContainer from "../../Extensions/DI-container.js";
import { useEffect, useState } from "react";
import Car from "./../Car/Car.jsx";
import styles from "./Cars.module.css";
import axios from "axios";

const Cars = ({pageNumber}) =>{
    useEffect(() => {
        $api.get('Cars/GetPageCars', {
            headers:{
                pageNumber
            }
        })
        .then((response) => {
            setCars(response.data.result);
        })
        .catch(() => {
            console.log("Ошибка при получении данных");
        });
    }, [pageNumber]);

    const [cars, setCars] = useState([]);

    return <>
        <div className="row"> 
            {cars.map((car) =>(
                <Car key={car.Id} {...car}/>
            ))}
        </div>
    </>
}

export default Cars;