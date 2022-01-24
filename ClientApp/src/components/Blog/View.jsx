import React, {Component} from 'react';
import axios from 'axios';

export class View extends Component{
    constructor(props){
        super(props);

        this.state = {
            title: '',
            publishedDate: null,
            bodyContents: ''
        }
    }

    componentDidMount(){
        const {id} = this.props.match.params;

        axios.get("api/Blog/Blog/"+id).then(blog => {
            const response = blog.data;

            this.setState({
                title: response.title,
                bodyContents: response.bodyContents,
                publishedDate: response.publishedDate ? new Date(response.publishedDate).toISOString().slice(0,10) : null
            })
        })
    }

    render(){
        return (
            <div className="blog-form" >
                <h3>View Blog Content</h3>
                    <div className="form-group">
                        <label>
                            {this.state.title}
                        </label>
                    </div>
                    <div className="form-group">
                        <label>
                            {this.state.publishedDate}
                        </label>
                    </div>
                    <div className="row">
                        <div className="col col-md-6 col-sm-6 col-xs-12">
                            <div className="form-group">
                                <label>
                                    {this.state.bodyContents}
                                </label>
                            </div>
                        </div>
                    </div>
            </div>
        )
    }
}