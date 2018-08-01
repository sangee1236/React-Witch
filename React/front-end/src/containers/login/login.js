import React from 'react' ;
import {connect} from 'react-redux';

import './login.css';

import login from '../../actions/login/login-action'

import {TextValidator, ValidatorForm} from 'react-material-ui-form-validator';
import TextField from 'material-ui/TextField';


class Login extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="container">
               <div className="card card-container">
                    <img className="profile-img-card"
                         src="https://imgs.tuts.dragoart.com/how-to-draw-the-deadpool-symbol_1_000000022495_5.png"/>
                    <p className="profile-name-card"></p>
                    <form className="form-signin"  ref="logins" onSubmit={(e) => {
                        e.preventDefault();
                        this.props.onLogin(this.refs.email.props.value, this.refs.password.props.value);
                        if (this.props.user.loggedIn)
                            this.props.history.push('home');
                    }
                    }>
                        <span className="reauth-email"></span>
                        <TextField
                            floatingLabelText="Email address"
                            name="email"
                            ref = "email"
                        value={"sangee1236@gmail.com"}
                           />
                        <TextField
                            type="password"
                            floatingLabelText="Password"
                            name="password"
                            ref="password"
                        value={"1234"}
                        />
                        {/*<button type="submit" className="btn btn-lg btn-primary btn-block btn-signin"  */}
                        {/*onClick={(e) => {*/}
                        {/*e.preventDefault();*/}
                        {/*this.props.onLogin(this.refs.userName.value, this.refs.password.value);*/}
                        {/*if (this.props.user.loggedIn) {*/}
                        {/*this.props.history.push('home');*/}
                        {/*}*/}
                        {/*}*/}
                        {/*}>*/}
                        <button type="submit" className="btn btn-lg btn-primary btn-block btn-signin">
                            Bro ,Let Me In
                        </button>
                    </form>
                    {/*card-container */}
                </div>
                {/*/container*/}
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        user: state.login
    }
}


const mapDispatchToProps = (dispatch) => {
    return {
        onLogin: (userName, password) => {
            dispatch(login(userName, password));
        }
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Login);