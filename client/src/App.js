import React from 'react';
import './App.css';
import api from './api';
import MovieView from './movie-view';

class App extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoading: false,
      data: [] ,
    }
  } 
  componentDidMount() { 
     this.setState({isLoading:true}, () => {
      api.get("movie").then(response => {  
        this.setState({  
            isLoading:false,
            data: response.data  
        });  
     })
    })
  }
  render() {
    return (
      <div className="App">
             { this.state.isLoading ? 
              "Loading..." :
               <MovieView data = {this.state.data}/>
             }             
      </div>
    );
  }
}

export default App;
