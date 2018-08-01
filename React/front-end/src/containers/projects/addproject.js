import React from 'react';

import TextField from 'material-ui/TextField';
import RaisedButton from 'material-ui/RaisedButton';
import {Card, CardActions, CardHeader, CardText} from 'material-ui/Card';

var cardStyle = {
    display: 'block',
    width: '23%',
    transitionDuration: '0.3s',
    height: '277px'
}

export default class AddProjects extends React.Component {
    render() {
        return (
            <Card style ={cardStyle}>
                <CardHeader>
                <h2>Add Projects</h2>
                </CardHeader>
                <CardText>
                <TextField
                    floatingLabelText="Add Projects"
                    name="Projects"
                    />
                </CardText>
                <CardActions>
                <RaisedButton label={'add'}
                />
                </CardActions>
            </Card>
        );
    }
}