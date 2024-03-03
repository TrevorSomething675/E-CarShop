import {Link, Route, Routes, Router, BrowserRouter} from "react-router-dom";
import Header from "./Components/Header/Header.jsx";
import NotFoundPage from "./Pages/NotFound/NotFoundPage.jsx";
import CarsPage from "./Pages/Cars/CarsPage.jsx";
import AuthPage from "./Pages/Auth/AuthPage.jsx";
import Layout from "./Components/Layout/Layout.jsx";



const App = () =>{
  return (
    <BrowserRouter>
      <div className="App">
          <Routes>
            <Route path="/" element={<Layout />}>
              <Route index element={<CarsPage />} />
              <Route path="Auth" element={<AuthPage />} />
              <Route path="*" element={<NotFoundPage />} />
            </Route>
          </Routes>
      </div>    
    </BrowserRouter>
  );
}

export default App;