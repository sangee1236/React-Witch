import {getRequestOptions ,getApiUrl} from '../../helpers/service-helper';

const apiUrl =  getApiUrl('Projects/');
let requestOptions = '';

export const allProjectList = ()=>{
    requestOptions = getRequestOptions('GET');
return fetch(apiUrl+'allprojectlist',requestOptions)
    .then(response=>response.json()
    );
}

export const getProjectsByUserId  =(userId)=> {
    requestOptions = getRequestOptions('GET');
         return fetch(apiUrl+'projectslistbyid?resourceId='+userId,requestOptions)
            .then(response=>response.json());
}

export const addProjects = (projectName) =>{
    requestOptions = getRequestOptions('POST');
    return fetch(apiUrl+'addproject?projectName='+projectName,requestOptions)
        .then(response=>{
            response.ok
        });
}

export const updatePoject = (project) =>{
    requestOptions = getRequestOptions('PUT' ,project)
    return fetch(apiUrl+'updateproject',requestOptions)
        .then(response=>{
            response.ok
        });
}

export const deleteProjects = (projectId)=>{
    requestOptions = getRequestOptions('DELETE')
    return fetch(apiUrl+'deleteproject?projectId='+projectId,requestOptions)
        .then(response=>{
            response.ok
        });
}

