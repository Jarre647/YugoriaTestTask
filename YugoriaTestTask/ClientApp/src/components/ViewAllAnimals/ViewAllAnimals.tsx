import axios from 'axios';
import React from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

interface IMainProps {

}

interface TableData {
    id: number,
    animalName: string,
    kindAnimalName: string,
    locationName: string,
    regionName: string,
    skinColorName: string 
}

interface IMainState {
    tableData: Array<TableData>
}

export default class TableAllExpensesAndIncomes extends React.Component<IMainProps, IMainState> {
    constructor(props: Readonly<{}>) {
        super(props);

        this.state = {
            tableData: [
                {
                    id: 1,
                    animalName: '',
                    kindAnimalName: '',
                    locationName: '',
                    regionName: '',
                    skinColorName: ''                  
                }
            ]
        }
        this.deleteAnimal = this.deleteAnimal.bind(this);
    }
    componentDidMount() {
        this.getAnimals();
    }

    getAnimals() {
        axios
            .get("/api/animals")
            .then((response) => {
                this.setState({ tableData: response.data })
            })
            .catch(function (error) {
                console.log(error)
            })
    }

    deleteAnimal(event: React.MouseEvent<HTMLAnchorElement>, id:number) {
        event.preventDefault();
        axios
            .delete("/api/animals/" + id)
            .then((response)=> {
                if(response.status === 200) this.getAnimals()
            })
            .catch(function (error) {
                console.log(error)
            })
    }
    
    public render() {
        return (
            <TableContainer component={Paper}>
                <Table >
                    <TableHead>
                        <TableRow>
                            <TableCell>Название</TableCell>
                            <TableCell>Вид</TableCell>
                            <TableCell>Цвет шкуры</TableCell>
                            <TableCell>Местоположение</TableCell>
                            <TableCell>Регион</TableCell>
                            <TableCell>Изменить</TableCell>
                            <TableCell>Удалить</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {this.state.tableData.map(item => (
                            <TableRow key={item.id}>
                                <TableCell>
                                    {item.animalName}
                                </TableCell>
                                <TableCell>
                                    {item.kindAnimalName}
                                </TableCell>
                                <TableCell>
                                    {item.skinColorName}
                                </TableCell>
                                <TableCell>
                                    {item.locationName}                                  
                                </TableCell>
                                <TableCell>
                                    {item.regionName}                                  
                                </TableCell>
                                <TableCell>
                                    <a href={'/edit-animal/' + item.id}>Изменить</a>                                 
                                </TableCell>
                                <TableCell>
                                    <a href='/' onClick={(e) => { this.deleteAnimal(e, item.id)}}>Удалить</a>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        )
    }
}