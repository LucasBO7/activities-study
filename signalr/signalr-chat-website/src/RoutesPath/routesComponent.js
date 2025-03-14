import { BrowserRouter, Routes, Route } from "react-router-dom";
import { LoginPage } from "../Pages/LoginPage.Jsx";

export const RoutesComponent = () => {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route element={<LoginPage />} path="/login" exact />
        </Routes>
      </BrowserRouter>
    </div>
  );
};
