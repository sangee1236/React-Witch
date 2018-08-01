import React from 'react';

import DropDownMenu from 'material-ui/DropDownMenu';
import MenuItem from 'material-ui/MenuItem';

export default class GetDropDownMenu extends React.Component {
    constructor() {
        super();
        this.state = {
            value: 0
        };
    }

    render() {
        return (<DropDownMenu value={this.state.value} onChange={(event, index, value) => {
                this.setState({value: value})
                this.props.onSelectedValue('DropDown',value);
            }}>
                <MenuItem Key='0' value={0} primaryText={this.props.menuTitle} disabled={true}/>
                {this.props.bindDropDownList.map((bindList) =>
                    <MenuItem Key={bindList.id} value={bindList.id} primaryText={bindList.name}/>)}
            </DropDownMenu>
        );
    }
}

