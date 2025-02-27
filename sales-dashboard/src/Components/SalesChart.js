import React, { useState, useEffect } from "react";
import { Bar, Line, Scatter } from "react-chartjs-2";
import { Chart, CategoryScale, LinearScale, BarElement, LineElement, PointElement, Title, Tooltip, Legend } from "chart.js";
import { getSalesData } from "../api";
import { Button } from '@mui/material';
import { useNavigate } from "react-router-dom";

Chart.register(CategoryScale, LinearScale, BarElement, LineElement, PointElement, Title, Tooltip, Legend);

const SalesChart = () => {
    const [chartData, setChartData] = useState({ labels: [], datasets: [] });
    const navigate = useNavigate();
    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getSalesData();
                const labels = data.map(item => item.month);
                setChartData({
                    labels,
                    datasets: [
                        {
                            label: "New Vehicle Sales",
                            type: "bar",
                            data: data.map(item => item.newVehicleSales),
                            backgroundColor: "rgba(75, 192, 192, 0.8)",
                            stack: "sales",
                            barThickness: "flex",
                            categoryPercentage: 0.8,
                            barPercentage: 0.9,
                        },
                        {
                            label: "Used Vehicle Sales",
                            type: "bar",
                            data: data.map(item => item.usedVehicleSales),
                            backgroundColor: "rgba(153, 102, 255, 0.8)",
                            stack: "sales",
                            barThickness: "flex",
                            categoryPercentage: 0.8,
                            barPercentage: 0.9,
                        },
                        {
                            label: "New Vehicle Inventory",
                            type: "line",
                            data: data.map(item => item.inventoryLevels),
                            borderColor: "rgba(255, 159, 64, 1)",
                            borderWidth: 3,
                            yAxisID: "y1",
                        },
                        {
                            label: "Appointment Set Rate (%)",
                            type: "line",
                            data: data.map(item => item.appointmentSetRate),
                            borderColor: "rgba(255, 99, 132, 1)",
                            borderWidth: 3,
                            yAxisID: "y2",
                        },
                        {
                            label: "Appointment Close Rate (%)",
                            type: "scatter",
                            data: data.map(item => ({ x: item.month, y: item.appointmentCloseRate })),
                            backgroundColor: "rgba(54, 162, 235, 0.9)",
                            pointRadius: 10,
                            yAxisID: "y2",
                        },
                    ],
                });
            } catch (error) {
                console.error("Error fetching sales data:", error);
            }
        };
        fetchData();
    }, []);

    return (
        <div className="p-8 max-w-7xl mx-auto">
            <h1 className="text-center text-3xl font-bold mb-6">Multi-Axis Sales and Inventory Trend Analysis</h1>
            <div className="bg-white shadow-xl p-6 rounded-lg" style={{ height: "600px" }}>
                <Button onClick={() => navigate('/sales-crud')} className="mb-4">Manage Chart</Button>
                <Bar data={chartData} options={{
                    maintainAspectRatio: false,
                    responsive: true,
                    plugins: { legend: { position: "bottom" } },
                    scales: {
                        x: { 
                            title: { display: true, text: "Months", font: { size: 16 } },
                            ticks: { autoSkip: false, maxRotation: 45, minRotation: 0 },
                        },
                        y: { stacked: true, title: { display: true, text: "Vehicle Sales", font: { size: 16 } }, beginAtZero: true },
                        y1: { position: "right", title: { display: true, text: "Inventory Levels", font: { size: 16 } }, grid: { drawOnChartArea: false }, beginAtZero: true },
                        y2: { position: "right", title: { display: true, text: "Rates (%)", font: { size: 16 } }, grid: { drawOnChartArea: false }, beginAtZero: true },
                    },
                }} />
            </div>
        </div>
    );
};

export default SalesChart;
