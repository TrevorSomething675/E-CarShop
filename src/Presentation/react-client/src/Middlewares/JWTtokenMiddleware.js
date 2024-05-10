import axios from "axios";
import DiContainer from "../Extensions/DI-container";

const $api = axios.create({
    //withCredentials: true,
    baseURL: DiContainer.CarShopUrl
});

$api.interceptors.request.use((config)=>{
    config.headers.Authorization = "jija";
    return config;
});
//`Bearer ${localStorage.getItem('accessToken')}`;

export default $api;