import {Link, Route, Routes, Router, BrowserRouter} from "react-router-dom";
import "./Assets/GlobalStyles.css";
import Header from "./Components/Header/Header.jsx";
import NotFoundPage from "./Pages/NotFound/NotFoundPage.jsx";
import CarsPage from "./Pages/Cars/CarsPage.jsx";
import Layout from "./Components/Layout/Layout.jsx";
import LoginPage from "./Pages/Login/LoginPage.jsx";
import RegisterPage from "./Pages/Register/RegisterPage.jsx";
import UsersPage from "./Pages/Users/UsersPage.jsx";
import CreateCarPage from "./Pages/CreateCar/CreateCarPage.jsx";


const App = () =>{
  return (
    <BrowserRouter>
      <div className="App">
          <Routes>
            <Route path="/" element={<Layout />}>
              <Route path="Cars" element={<CarsPage />} />
              <Route path="Users" element={<UsersPage />}/>
              <Route path="CreateCar" element={<CreateCarPage />}/>
              <Route path="Login" element={<LoginPage />} />
              <Route path="Register" element={<RegisterPage />}/>
              <Route path="*" element={<NotFoundPage />} />
            </Route>
          </Routes>
      </div>    
    </BrowserRouter>
  );
}

export default App;