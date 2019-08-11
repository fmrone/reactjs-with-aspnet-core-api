import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';

import Lista from './pages/produto/Lista';
import Cria from '././pages/produto/Cria';
import Altera from './pages/produto/Altera';
import Exclui from './pages/produto/Exclui';

export default function Routes() {

    return(

        <BrowserRouter>
            <Route path="/" exact component={Lista} />
            <Route path="/cria" component={Cria} />
            <Route path="/altera/:id" component={Altera} />
            <Route path="/exclui/:id" component={Exclui} />
        </BrowserRouter>

    );

        

    

}