import {addLogTime} from '../../services/timelog/timelog-service';

import {Toaster} from '../../helpers/toaster-helper';

export default function addTimeLog(objTimeLog){
    return function(){
        addLogTime(objTimeLog).then(
          response=>{
              if(response)
                 Toaster('success');
              else
                  Toaster('error');
          }
        );
    }
}