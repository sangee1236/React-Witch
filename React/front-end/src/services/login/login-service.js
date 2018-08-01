import {getRequestOptions , getApiUrl} from  '../../helpers/service-helper';

const apiUrl =  getApiUrl('Resources/');
let requestOptions = '';

const LogService =(userName,password)=>   {
     requestOptions =getRequestOptions('GET');
        return fetch(apiUrl +'LogCreds?EmailID=' + userName + '&password=' + password, requestOptions)
            .then(user => {
                localStorage.setItem('user', JSON.stringify(user));
                return user.json();
            });
    }

export default LogService ;
