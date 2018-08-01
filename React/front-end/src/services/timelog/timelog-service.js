import { getRequestOptions ,getApiUrl } from '../../helpers/service-helper'

const apiUrl =  getApiUrl('TimeSheet/');
let requestOptions = '';

export const timelogListById =(userId)=>{
    requestOptions = getRequestOptions('GET');
    return fetch(apiUrl + 'logtimelistbyid?resourceId='+userId,requestOptions)
        .then(response=>response.json());
}

export const addLogTime =(logTimeInfo)=>{
    requestOptions = getRequestOptions('POST' , logTimeInfo);
    return fetch(apiUrl + 'AddTimeSheetEntry',requestOptions)
        .then(response=>response.ok);
}


export const updateLogTime =(logTimeInfo)=>{
    requestOptions = getRequestOptions('PUT' , logTimeInfo);
    return fetch(apiUrl + 'UpdateTimeSheetEntry',requestOptions)
        .then(response=>response.ok);
}

export const  deleteLogTime =(logId,userId)=>{
    requestOptions = getRequestOptions('DELETE');
    return fetch(apiUrl + 'DeleteLogTimeSheetEntry',requestOptions)
        .then(response=>response.ok);
}