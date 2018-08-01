const projectReducer = (state = {
    ProjectsList: []
}, action) => {
    switch (action.type) {
        case 'GET_PROJECTS':
            state = {
                ...state, ProjectsList: action.payload
            };
            break;
        default:
    }
    return state;
}
export default projectReducer;