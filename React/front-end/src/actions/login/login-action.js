import LoginService from '../../services/login/login-service';

export default function login(userName,password) {
    return function (dispatch)  {
        LoginService(userName, password)
            .then(
                user => {
                    dispatch(success(user));
                },
                error => {
                    dispatch(failure(error));
                }
            )
    }

    function success(user) {
        return {
            type: 'LOGIN_SUCCESS',
            payload: user
        }
    }

    function failure(error) {
        return {
            type: 'LOGIN_FAILURE',
            payload: error
        }
    }
}