import React from 'react';
import ReactDOM from 'react-dom';

import 'bootstrap/dist/css/bootstrap.min.css';

import store from './store';
import Root from './routing/root';



ReactDOM.render(
    <Root store ={store} />
    , document.getElementById('root'));

