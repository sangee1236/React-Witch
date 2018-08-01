import React from 'react';
import ReactDOM from 'react-dom';
import {createStore} from 'redux';
import  {Provider}from 'react-redux';
import allReducers from './reducers/index';
import LogTimeSheet from './components/LogTimesheet/log-timesheet'

const store = createStore(allReducers);

ReactDOM.render(
    <Provider store ={store}>
        <LogTimeSheet/>
    </Provider>
    ,document.getElementById('root')
);
