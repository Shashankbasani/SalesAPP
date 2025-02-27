import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { getSalesData, addSale, updateSale, deleteSale } from '../api';
import { Button, Card, CardContent, CardHeader, Input, Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

const SalesCrud = () => {
    const navigate = useNavigate();
    const [sales, setSales] = useState([]);
    const [formData, setFormData] = useState({
        month: '',
        newVehicleSales: '',
        usedVehicleSales: '',
        inventoryLevels: '',
        appointmentSetRate: '',
        appointmentCloseRate: ''
    });
    const [editMode, setEditMode] = useState(false);
    const [editId, setEditId] = useState(null);

    useEffect(() => {
        fetchSales();
    }, []);

    const fetchSales = async () => {
        const data = await getSalesData();
        setSales(data);
    };

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (editMode) {
            await updateSale(formData);
        } else {
            await addSale(formData); 
        }
        resetForm();
        fetchSales();
    };

    const handleEdit = (sale) => {
        setFormData({ ...sale });
        setEditMode(true);
        setEditId(sale.id);
    };

    const handleDelete = async (id) => {
        await deleteSale(id);
        fetchSales();
    };

    const resetForm = () => {
        setFormData({
            month: '',
            newVehicleSales: '',
            usedVehicleSales: '',
            inventoryLevels: '',
            appointmentSetRate: '',
            appointmentCloseRate: ''
        });
        setEditMode(false);
        setEditId(null);
    };

    return (
        <div className="p-6 max-w-4xl mx-auto">
            <Button onClick={() => navigate('/')} className="mb-4">Back to Chart</Button>
            <Card>
                <CardHeader title={editMode ? "Edit Sale" : "Add Sale"} />
                <CardContent>
                    <form onSubmit={handleSubmit} className="grid grid-cols-2 gap-4">
                        <Input type="text" name="month" value={formData.month} onChange={handleChange} placeholder="Month" required />
                        <Input type="number" name="newVehicleSales" value={formData.newVehicleSales} onChange={handleChange} placeholder="New Vehicle Sales" required />
                        <Input type="number" name="usedVehicleSales" value={formData.usedVehicleSales} onChange={handleChange} placeholder="Used Vehicle Sales" required />
                        <Input type="number" name="inventoryLevels" value={formData.inventoryLevels} onChange={handleChange} placeholder="Inventory Levels" required />
                        <Input type="number" step="0.1" name="appointmentSetRate" value={formData.appointmentSetRate} onChange={handleChange} placeholder="Appointment Set Rate" required />
                        <Input type="number" step="0.1" name="appointmentCloseRate" value={formData.appointmentCloseRate} onChange={handleChange} placeholder="Appointment Close Rate" required />
                        <Button type="submit" className="col-span-2">{editMode ? 'Update' : 'Add'} Sale</Button>
                        {editMode && <Button onClick={resetForm} className="col-span-2" color="secondary">Cancel</Button>}
                    </form>
                </CardContent>
            </Card>

            <div className="mt-6">
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Month</TableCell>
                            <TableCell>New Sales</TableCell>
                            <TableCell>Used Sales</TableCell>
                            <TableCell>Inventory</TableCell>
                            <TableCell>Appointment Set Rate</TableCell>
                            <TableCell>Appointment Close Rate</TableCell>
                            <TableCell>Actions</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {sales.map((sale) => (
                            <TableRow key={sale.id}>
                                <TableCell>{sale.month}</TableCell>
                                <TableCell>{sale.newVehicleSales}</TableCell>
                                <TableCell>{sale.usedVehicleSales}</TableCell>
                                <TableCell>{sale.inventoryLevels}</TableCell>
                                <TableCell>{sale.appointmentSetRate}</TableCell>
                                <TableCell>{sale.appointmentCloseRate}</TableCell>
                                <TableCell>
                                    <Button variant="outlined" size="small" onClick={() => handleEdit(sale)} className="mr-2">
                                        <EditIcon />
                                    </Button>
                                    <Button variant="contained" color="error" size="small" onClick={() => handleDelete(sale.id)}>
                                        <DeleteIcon />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </div>
        </div>
    );
};

export default SalesCrud;
