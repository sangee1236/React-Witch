import React from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';

import getProjectList from '../../../actions/projects/project-actions';
import addTimeLog from '../../../actions/timesheet/addtimelog-actions'

import GetDatePicker from '../../../components/helper/datepicker';
import GetDropDownMenu from '../../../components/helper/dropdown-menu';
import {ToasterContainer} from '../../../helpers/toaster-helper';

import DropDownMenu from 'material-ui/DropDownMenu';
import MenuItem from 'material-ui/MenuItem';
import TextField from 'material-ui/TextField';
import RaisedButton from 'material-ui/RaisedButton';

class AddDailyLog extends React.Component {
    constructor() {
        super();
        this.state = {
            selectedDate: '',
            selectedProjectId: '',
            BillingStatus: 0
        }
    }

    componentWillMount() {
        this.props.getProjectList(this.props.User.id);
    }

    onSelectedValue = (controls, value) => {
        switch (controls) {
            case 'DatePicker':
                this.setState({selectedDate: value})
                break;
            case 'DropDown':
                this.setState({selectedProjectId: value})
                break;
            default:
        }
    }

    render() {
        return (
            <form ref="logtime">
                <ToasterContainer/>
                <h1>Add New Time Log</h1>
                <p>Project</p>
                <GetDropDownMenu
                    bindDropDownList={this.props.projects.ProjectsList}
                    menuTitle="Projects"
                    onSelectedValue={this.onSelectedValue}/>
                <GetDatePicker onSelectedValue={this.onSelectedValue}/>
                <TextField ref="TaskName" floatingLabelText="Task Name"/>
                <br/>
                <TextField ref="TaskDetails" floatingLabelText="Task Details"/>
                <br/>
                <TextField ref="Hours" floatingLabelText="Hours" type="number"/>
                <br/>
                <DropDownMenu value={this.state.BillingStatus} onChange={(event, index, value) => {
                    this.setState({BillingStatus: value})
                }}>
                    <MenuItem Key='0' value={0} primaryText="Billing Status" disabled={true}/>
                    <MenuItem value={1} primaryText='Non-Billable'/>
                    <MenuItem value={2} primaryText='Billable'/>
                </DropDownMenu>
                <div>
                    <RaisedButton label="Add" secondary={true} onClick={() => {
                        const objTimeLog = {
                            resourceId: this.props.User.id,
                            projectId: this.state.selectedProjectId,
                            date: this.state.selectedDate,
                            task: this.refs.TaskName.getValue(),
                            taskDetails: this.refs.TaskDetails.getValue(),
                            hours: this.refs.Hours.getValue(),
                            billingStatus: this.state.BillingStatus
                        }
                         this.props.addTimeLog(objTimeLog);
                    }}/>
                </div>

            </form>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        projects: state.projects,
        User: state.login.User
    }
}


const mapDispatchToProps = (dispatch) => {
    return {
        getProjectList: bindActionCreators(getProjectList, dispatch),
        addTimeLog: bindActionCreators(addTimeLog, dispatch)
        //  getProjectList :(userId) => {
//     dispatch(getProjectList(userId));
// }
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(AddDailyLog);
