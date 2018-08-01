import {combineReducers} from 'redux' ;
import userReducer  from './reducers-user';
import projectsReducer from './reducers-project';

const allReducers = combineReducers({
    user : userReducer,
    projects: projectsReducer
});

export default allReducers ;