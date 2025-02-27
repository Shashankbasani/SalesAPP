import React from "react";
import SalesChart from "./Components/SalesChart";
import SalesCrud from "./Components/SalesCrud";
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';


function App() {
    return (
        // <div>
        //     <h1>Sales & Inventory Analysis</h1>
        //     <SalesChart />
        // </div>
        <Router>
     
        
        <Routes>
            <Route path="/" element={<SalesChart />} />
            <Route path="/sales-crud" element={<SalesCrud />} />
        </Routes>
    </Router>
    );
}

export default App;
