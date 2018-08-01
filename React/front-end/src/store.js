import {createStore,applyMiddleware} from 'redux';
import logger from 'redux-logger' ;
import thunk from 'redux-thunk';

import allReducers from './reducers/index';

const middleWare = applyMiddleware(thunk,logger);

export default createStore(allReducers,middleWare)
