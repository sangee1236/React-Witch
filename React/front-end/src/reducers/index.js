import {combineReducers} from 'redux';

import loginReducer from './login/loginReducer';
import projectReducer from './projects/project-reducers';

const allReducers = combineReducers({
    login :loginReducer,
    projects : projectReducer
});

export default allReducers ;