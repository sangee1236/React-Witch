import {getProjectsByUserId} from '../../services/projects/project-service';

export default function getProjectList(userId){
    return function(dispatch){
        getProjectsByUserId(userId).then(
           projects => {
               dispatch(GetProjectList(projects));
           });
    }

    function GetProjectList(projects){
     return {
         type:'GET_PROJECTS',
         payload:projects
        }
    }
}