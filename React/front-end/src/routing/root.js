import React from 'react'
import PropTypes from 'prop-types'
import {Provider} from  'react-redux' ;
import { BrowserRouter as Router ,Switch , Route} from 'react-router-dom';

import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';

import Login from '../containers/login/login';
import Home from '../components/home/home';
import AddProjects from '../containers/projects/addproject';


const Routes = ()=>(
    <Switch>
        <Route exact path = '/' component = {Login}/>
        <Route  path = '/home'  component ={Home}/>
        <Route  path = '/Projects'  component ={AddProjects}/>
    </Switch>
);


 const Root =({store})=>(
     <MuiThemeProvider>
    <Provider store = {store}>
        <Router>
        <Routes />
        </Router>
    </Provider>
     </MuiThemeProvider>
);

 Root.propTypes = {
     store: PropTypes.object.isRequired
 }

export default  Root ;