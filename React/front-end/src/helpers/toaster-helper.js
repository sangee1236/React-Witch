import React from 'react';

import {NotificationContainer, NotificationManager} from 'react-notifications';

export const Toaster = (type) => {
    switch (type) {
        case 'info' :
            NotificationManager.info('hey people');
            break;
        case 'success' :
            NotificationManager.success('record added successfully', 'Success');
            break;
        case 'warning':
            NotificationManager.warning('waning', 'warning');
            break;
        case 'error':
            NotificationManager.error('something went wrong', 'oops');
            break;
        case 'deleted':
            NotificationManager.error('record deleted successfully', 'Deleted');
            break;
            default :
    }
}

export const ToasterContainer = () => {
    return (<div>
        <NotificationContainer/>
    </div>);
}


