import axios from 'axios';
import React from 'react';
import {TextField,  Card, CardActions,  CardContent, Button, NativeSelect} from '@material-ui/core';

interface IMainProps {
    match: {
        params: {
            id: number
        }
    }
}

interface KindAnimal {
    id: number,
    kindAnimalName: string
}

interface Location {
    id: number,
    locationName: string
}

interface Region {
    id: number,
    regionName: string
}

interface SkinColor {
    id: number,
    skinColorName:string
}

interface IMainState {
        id: number,
        animalName: string,
        kindAnimalId: number,
        locationId: number,
        regionId: number,
        skinColorId: number,
        KindAnimals: Array<KindAnimal>,
        Locations: Array<Location>,
        Regions: Array<Region>,
        SkinColors:Array<SkinColor>
}

export default class CreateExpenseAndIncome extends React.Component<IMainProps, IMainState> {
    constructor(props: {match: {params: {id:0}}}) {
        super(props);

        this.state = {
            id: 0,
            animalName: '',
            kindAnimalId: 0,
            locationId: 0,
            regionId: 0,
            skinColorId: 0,
            KindAnimals: [],
            Locations: [],
            Regions: [],   
            SkinColors: []
        }

        this.handleExpenseAndIncome = this.handleExpenseAndIncome.bind(this);

        this.handleAnimalNameChange = this.handleAnimalNameChange.bind(this);
        this.handleKindOnChange = this.handleKindOnChange.bind(this);
        this.handleLocationOnChange = this.handleLocationOnChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleSkinColorOnChange = this.handleSkinColorOnChange.bind(this);
        this.handleRegionOnChange = this.handleRegionOnChange.bind(this);
    }

    handleExpenseAndIncome(event: React.ChangeEvent<HTMLInputElement>) {
        const expenseAndIncome = event.target.value;
        this.setState = () => {
            return {
                expenseAndIncome,
                validContent: expenseAndIncome.length <= 200
            }
        };
        return;
    }
    
    handleAnimalNameChange(event: React.ChangeEvent<HTMLInputElement>) {
        this.setState({animalName: event.target.value})
    }

    handleKindOnChange(event: React.ChangeEvent<HTMLSelectElement>) {
        this.setState({kindAnimalId: +event.target.value})
    }

    handleLocationOnChange(event: React.ChangeEvent<HTMLSelectElement>) {
        this.setState({locationId: +event.target.value})
    }

    handleRegionOnChange(event: React.ChangeEvent<HTMLSelectElement>) {
        this.setState({regionId: +event.target.value})
    }

    handleSkinColorOnChange(event: React.ChangeEvent<HTMLSelectElement>) {
        this.setState({skinColorId: +event.target.value})
    }
    
    componentDidMount(){
        axios
            .get("/api/animals/" + this.props.match.params.id)
            .then((response) => {
                this.setState({animalName: response.data.animalName})
                this.setState({id: response.data.id})
                this.setState({kindAnimalId: response.data.kindAnimalId})
                this.setState({locationId: response.data.locationId})
                this.setState({regionId: response.data.regionId})
                this.setState({skinColorId: response.data.skinColorId})
            })
            
        axios
            .get("/api/animals/helpedTypes")
            .then((response) => {                
                this.setState({KindAnimals: response.data.kinds})
                this.setState({Locations: response.data.locations})
                this.setState({Regions: response.data.regions})
                this.setState({SkinColors: response.data.skinColors})
            })
            .catch(function (error) {
                console.log(error);
            })
    }
    handleSubmit(state: IMainState) {
        axios
            .put("/api/animals",
                {
                    Id: this.state.id,
                    AnimalName: this.state.animalName,
                    KindAnimalId: this.state.kindAnimalId,
                    LocationId: this.state.locationId,
                    RegionId: this.state.regionId,
                    SkinColorId: this.state.skinColorId
                })
            .then(function (response) {
                console.log(response);
            });
    }    

    public render() {
        return (            
            <form>
                <Card className="minWidth: 275, maxWidth: 500">
                    <CardContent>       
                        <div>
                            <label>Название</label>
                            <TextField
                                value = {this.state.animalName}
                                onChange = {this.handleAnimalNameChange}
                            />
                        </div>
                        <div>
                        <NativeSelect
                            value={this.state.kindAnimalId}
                            onChange={this.handleKindOnChange}
                            name="Kind"
                            inputProps={{ 'aria-label': 'Cat' }}>
                                {this.state.KindAnimals.map(item=> (
                                        <option key={item.id}
                                            value={item.id}>
                                                {item.kindAnimalName}
                                        </option>
                                ))}
                        </NativeSelect>
                        <NativeSelect
                            value={this.state.locationId}
                            onChange={this.handleLocationOnChange}
                            name="Location"
                            inputProps={{ 'aria-label': 'type' }}>
                                {this.state.Locations.map(item=> (
                                    <option key={item.id}
                                        value={item.id}>
                                            {item.locationName}
                                    </option>
                                ))}
                        </NativeSelect>
                        <NativeSelect
                            value={this.state.regionId}
                            onChange={this.handleRegionOnChange}
                            name="Region"
                            inputProps={{ 'aria-label': 'type' }}>
                                {this.state.Regions.map(item=> (
                                    <option key={item.id}
                                        value={item.id}>
                                            {item.regionName}
                                    </option>
                                ))}
                        </NativeSelect>
                        <NativeSelect
                            value={this.state.skinColorId}
                            onChange={this.handleSkinColorOnChange}
                            name="SkinColor"
                            inputProps={{ 'aria-label': 'type' }}>
                                {this.state.SkinColors.map(item=> (
                                    <option key={item.id}
                                        value={item.id}>
                                            {item.skinColorName}
                                    </option>
                                ))}                       
                        </NativeSelect>                            
                        </div>
                    </CardContent>
                    <CardActions>
                        <Button  size="small" onClick = {() => this.handleSubmit(this.state)}>Post</Button>
                    </CardActions>  
                </Card>
            </form>
        );
    }
}