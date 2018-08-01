import React from 'react';

import DatePicker from 'material-ui/DatePicker';

export default class GetDatePicker extends React.Component {
    constructor(props){
        super(props);
    }
    render() {
        return (
            <DatePicker
                hintText="Select Date"
                maxDate={new Date()}
                onChange={(event,date)=>{this.props.onSelectedValue('DatePicker',date)}} />
        );
    }
}

