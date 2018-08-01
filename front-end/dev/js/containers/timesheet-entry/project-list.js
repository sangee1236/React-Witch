import  React , {Component} from  'react';
import {bindActionCreators} from 'redux';
import{connect} from 'react-redux';

class ProjectList extends Component {

    CreateProjectItem(){
        return this.props.projects.map((project)=>{
            return (
                <li key={project.id}>{project.name}</li>
            );
        })
    }
    render(){
        return(
            <ul>
                {this.CreateProjectItem()}
            </ul>
        );
    }
}

function mapStateToProps(state) {
    return {
        projects : state.projects
    };
}

export default connect(mapStateToProps)(ProjectList) ;
