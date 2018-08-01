import React from 'react';
import './navbar.css';

import AppBar from 'material-ui/AppBar';
import FlatButton from 'material-ui/FlatButton';
import Avatar from 'material-ui/Avatar';

import {Link} from 'react-router-dom';

import 'font-awesome/css/font-awesome.min.css'

function handleClick() {
    alert('onClick triggered on the title component');
}

const styles = {
    title: {
        cursor: 'pointer',
    },
};

var buttonStyle = {
    backgroundColor: 'transparent',
    color: 'white' ,
    marginRight: '10px'
};


const navButtons = (
    <div>
        {/*<FlatButton label="Home" style={buttonStyle}/>*/}
        <Link to='/Projects' style={buttonStyle}>Projects</Link>
        <Link to='/Projects' style={buttonStyle}>Run</Link>
        <Avatar src='http://energy106.ca/wp-content/uploads/2018/02/maxresdefault.jpg'/>
    </div>
);


class NavBar extends React.Component {
    constructor() {
        super();
        this.state = {
            open: false
        };
    }

    render() {
        return (
            <div>
                <AppBar
                            style = {{backgroundColor: '#FF4081'}}
                            title={<span style={styles.title}>Title</span>}
                            onTitleClick={handleClick}
                            iconElementRight={navButtons}/>
                <button className="cn-button" id="cn-button" onClick={() => {
                    if (this.state.open)
                        this.setState({open: false});
                    else
                        this.setState({open: true});
                    console.log(this.state.open);
                }}>{this.state.open ? "-" : "+"}
                </button>
                <div className={this.state.open ? "cn-wrapper opened-nav" : "cn-wrapper"} id="cn-wrapper">
                    <ul>
                        <li><a href="#"><span className="fa fa-spinner fa-spin"></span></a></li>
                        <li><a href="#"><span className="fa fa-spinner fa-spin"></span></a></li>
                        <li><a href="#"><span className="icon-home"></span></a></li>
                        <li><a href="#"><span className="icon-facetime-video"></span></a></li>
                        <li><a href="#"><span className="icon-envelope-alt"></span></a></li>
                    </ul>
                </div>
                <div id="cn-overlay" className={this.state.open ? "cn-overlay on-overlay" : "cn-overlay"}></div>
            </div>
        );
    }
}

export default NavBar;
