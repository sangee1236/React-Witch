const loginReducer = (state = {
    loggedIn: false,
    User: []
}, action) => {
    switch (action.type) {
        case "LOGIN_SUCCESS":
            state = {
                ...state,
                loggedIn: true,
                User: action.payload
            };
            break;
        case "LOGIN_FAILURE":
            console.log(action.type);
            break;
        default:
    }
    return state;
};

export default loginReducer;