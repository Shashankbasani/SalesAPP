import axios from "axios";

const API_URL = "https://localhost:7001/api/sales";

export const getSalesData = async () => {
    try {
        const response = await axios.get(`${API_URL}/GetSales`);
        console.log("hello data");
        console.log(response);
        return response.data;
    } catch (error) {
        console.error("Error fetching sales data", error);
        return [];
    }
};


export const addSale = async (sale) => {
    const response = await axios.post(`${API_URL}/AddSale`, sale, {
        headers: { "Content-Type": "application/json" },
    });
    return response.data;
};

export const updateSale = async (sale) => {
    const response = await axios.put(`${API_URL}/UpdateSale`, sale,{
        headers: { "Content-Type": "application/json" },
    });
    return response.data;
};

export const deleteSale = async (id) => {
    const response = await axios.delete(`${API_URL}/DeleteSale/${id}`);
    return response.data;
};

