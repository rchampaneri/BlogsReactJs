import React, {Component} from 'react';
import axios from 'axios';
export class Blogs extends Component
{
    constructor(props){
        super(props);

        this.onBlogView = this.onBlogView.bind(this);

        this.state = {
            blogs: [],
            loading: true,
            failed: false,
            error: ''
        }
    }

    componentDidMount() {
        this.populateBlogsData();
    }

    onBlogView(id) {
        const { history } = this.props;
        history.push('/view/' + id);;
    }

    populateBlogsData(){
        axios.get("api/Blog/GetBlogs").then(result => {
            const response = result.data;
            this.setState({blogs: response, loading: false, failed: false, error:""});
        }).catch(error => {
            this.setState({blogs: [], loading: false, failed: true, error:"Blogs could not be loaded"});
        });
    }

    renderAllBlogsTable(blogs){
        return (
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Title</th>
                        {/*<th>Content</th>*/}
                        <th>Number of Comments</th>
                        <th>Published Date</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        blogs.map(blog => (
                            <tr key={blog.id}>
                            <td>{blog.title}</td>
                            {/*<td>{blog.bodyContents}</td>*/}
                            <td>{blog.numberOfComments}</td>
                            <td>{blog.publishedDate ? new Date(blog.publishedDate).toISOString().slice(0,10) :  '-' }</td>
                            <td>
                                <div className="form-group">
                                    <button onClick={() => this.onBlogView(blog.id)} className="btn btn-success">
                                        View Detail
                                    </button>
                                </div>
                            </td>
                        </tr>
                        ))
                    }
                    
                </tbody>
            </table>
        );
    }

    render(){

        let content = this.state.loading ? (
            <p>
                <em>Loading...</em>
            </p>
        ) : ( this.state.failed ? (
            <div className="text-danger">
                <em>{this.state.error}</em>
            </div>
            ) : (
                this.renderAllBlogsTable(this.state.blogs))
        )

        return (
            <div>
                {content}
            </div>
        );
    }
}