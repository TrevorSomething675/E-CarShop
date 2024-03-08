import DiContainer from "./../../Extensions/DI-container.js";
import { useEffect } from "react";
import styles from "./Car.css";
import axios from "axios";

const Car = ({name, description, price}) =>{
    useEffect(() => {
    });

    return <div className="col-xxl-3 col-xl-4 col-md-6 col-sm-12 ">
    <div className="product-container m-1 p-1">
        <div>
            {name}
        </div>
        <h1>
        </h1>
        <div className="product-description text-break">
            {description}
        </div>
        <div>
            {price}
        </div>
    </div>
</div>
}

export default Car;