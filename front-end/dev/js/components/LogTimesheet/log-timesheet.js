import React from 'react';
import  ProjectList from '../../containers/timesheet-entry/project-list';

const LogTimeDetails = () =>(
<div width="288px">
    <div className="form-group">
        <label for="lblProject">Select Project</label>
        <div className="dropdown">
            <button className="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown">Project
                <span className="caret"></span></button>
            <ProjectList />
        </div>
    </div>
    <div className="form-group">
        <label for="Date">Date</label>
        <input className="form-control input-sm col-md-4"  type="text" />
    </div>
    <div className="form-group">
        <label for="Task">Task</label>
        <input className="form-control input-sm" id="Task" type="text" />
    </div>
    <div className="form-group">
        <label for="Task Details">Task Details</label>
        <input className="form-control input-sm" id="txtTaskDetails" type="text" />
    </div>
    <div className ="form-group">
        <label for="Hours">Hours</label>
        <input className="form-control input-sm" id="txtHours" type="text" />
    </div>
    <div className ="form-group">
        <label for="lblBillingStatus">Billing Status</label>
        <div className="dropdown">
            <button className="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown">Billable
                <span className="caret"></span></button>
            <ul className="dropdown-menu">
                <li className="active">Non Billable</li>
            </ul>
        </div>
    </div>
    <div>
        <button type ="button" className ="btn btn-default">Submit</button>
    <button type ="button" className ="btn btn-info">Cancel</button>
</div>
</div>
);

export default LogTimeDetails;