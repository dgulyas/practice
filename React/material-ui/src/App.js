//This project is for learning about Material UI.
//Large portions of code have been copied from
//https://mui.com/material-ui/

import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { useState } from 'react';







export default function App() {
  const [Name, setName] = useState('')
  const [Calories, setCalories] = useState('')
  const [Carbs, setCarbs] = useState('')
  const [Protein, setProtein] = useState('')

  function createData(
    name: string,
    calories: number,
    carbs: number,
    protein: number,
  ) {
    return { name, calories, carbs, protein };
  }

  const [rows, setRows] = useState([
    createData('Frozen yoghurt', 159, 24, 4.0),
    createData('Ice cream sandwich', 237, 37, 4.3),
    createData('Eclair', 262, 24, 6.0),
    createData('Cupcake', 305, 67, 4.3),
    createData('Gingerbread', 356, 16.0, 49, 3.9),
  ]);

  function AddRow(){
    setRows([...rows, createData(Name, Calories, Carbs, Protein)]);
  }

  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Dessert (100g serving)</TableCell>
              <TableCell align="right">Calories</TableCell>
              <TableCell align="right">Carbs&nbsp;(g)</TableCell>
              <TableCell align="right">Protein&nbsp;(g)</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {rows.map((row) => (
              <TableRow
                key={row.name}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {row.name}
                </TableCell>
                <TableCell align="right">{row.calories}</TableCell>
                <TableCell align="right">{row.carbs}</TableCell>
                <TableCell align="right">{row.protein}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      
      <Button variant="contained" onClick={() => {AddRow();}}>Add New</Button>
      <TextField id="Name" label="Name" variant="outlined" onChange={e => {setName(e.target.value)}}/>
      <TextField id="Calories" label="Calories" variant="outlined" onChange={e => {setCalories(e.target.value)}}/>
      <TextField id="Carbs" label="Carbs (g)" variant="outlined" onChange={e => {setCarbs(e.target.value)}}/>
      <TextField id="Protein" label="Protein (g)" variant="outlined" onChange={e => {setProtein(e.target.value)}}/>
    </div>
  );
}

