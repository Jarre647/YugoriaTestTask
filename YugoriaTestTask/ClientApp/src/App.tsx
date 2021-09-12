import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import ViewAllAnimals from './components/ViewAllAnimals/ViewAllAnimals';
import AddAnimal from './components/AddAnimal/AddAnimal';
import EditAnimal from './components/EditAnimal/EditAnimal';
import { path } from './Routes';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path={path.ViewAllAnimals} component={ViewAllAnimals} />
        <Route path={path.AddAnimal} component={AddAnimal} />
        <Route exact path={path.EditAnimal} component={EditAnimal} />
    </Layout>
);
