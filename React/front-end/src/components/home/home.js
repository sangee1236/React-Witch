import React from 'react'

import '../../../node_modules/react-notifications/dist/react-notifications.js'
import '../../../node_modules/react-notifications/dist/react-notifications.css';

import  NavBar  from './navbar/navbar';
import AddDailyLog from '../../containers/addtimelog/dailylog/addlog';

import DropDownMenu from 'material-ui/DropDownMenu';
import MenuItem from 'material-ui/MenuItem';
import FlatButton from 'material-ui/FlatButton';

import Modal from 'react-responsive-modal';
import {ToasterContainer} from '../../helpers/toaster-helper';

export default class Home extends  React.Component{
    constructor(){
        super();
        this.state = {
            open: false
        };
    }

    render(){
        const actions = [
            <FlatButton
                label ="cancel"
                onClick={()=>this.setState({open:false})} />
        ]
        return(
            <div>

                <ToasterContainer />
            <NavBar/>
                <div>
                    <DropDownMenu value={1}>
                        <MenuItem value={1} primaryText="Add Log Time" onClick ={()=>this.setState({open:true}) }/>
                        <MenuItem value={2} primaryText="Weekly Log Time"/>
                    </DropDownMenu>
                    <Modal open={this.state.open}
                           onClose={()=>this.setState({open:false})} little>
                        <AddDailyLog />
                    </Modal>             </div>
            </div>
        );

    }
}
