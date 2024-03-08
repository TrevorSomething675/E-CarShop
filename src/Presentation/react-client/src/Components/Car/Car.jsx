import DiContainer from "./../../Extensions/DI-container.js";
import { useEffect } from "react";
import styles from "./Car.css";
import axios from "axios";

const Car = ({Id, Name, Description, Price, Images}) =>{
    useEffect(() => {
        console.log(Images[0]);
    });

    return <div className="col-xxl-3 col-xl-4 col-md-6 col-sm-12 ">
    <div className="product-container m-1 p-1">
        <img src={`data:image/png;base64,${Images[0].Base64String}`} />
        <div>
            {Id}
        </div>
        <div>
            {Name}
        </div>
        <h1>
        </h1>
        <div className="product-description text-break">
            {Description}
        </div>
        <div>
            {Price}
        </div>
    </div>
</div>
}

export default Car;