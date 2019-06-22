import React from 'react';
import './App.css';
import api from './api';
import MovieView from './movie-view';

class App extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isLoading: false,
      data: [],
      searchText: '',
      selectedOption:'',
      searchButton:false,
    }
  }
  componentDidMount() {
    if(this.state.selectedOption !== '' && this.state.searchText !== ''){
        this.getData();
    }else{
      this.setState({isLoading : false});
    }
  }

  getData = () => {
    this.setState({ isLoading: true }, () => {
      api.get(this.state.selectedOption + this.state.searchText).then(response => {
        this.setState({
          isLoading: false,
          data: response.data
        });
      })
    });
  }
  CheckBoxControl = () => {
    if(this.state.selectedOption === ''){
        alert("Please check the search type!");
        return false;
    }
    return true;
  }
  SearchValueControl = () => {
    if(this.state.searchText === ''){
      alert("Please enter a search key!");
      return false;
     }
    return true;
  }
  ControlAndGetData = () => {
    if(this.CheckBoxControl() && this.SearchValueControl()){
      this.getData();
    }
  }
  ControlAndShowData()
  {
    var result = {};
    if(this.state.isLoading)
    { 
      result =  "Loading..."; 
    }else if(this.state.data === null || this.state.data.length === 0)
    {
      result = "Movie not found!";
    }else 
    {
      result = <MovieView data={this.state.data}/>;
    }
    return result;
  }

  render() {
    return (
      <div style = {{marginTop: '15px'}} className="App">
        <label>
        <input type="radio"
               value= "getbyid/"
               checked={this.state.selectedOption === "getbyid/"} 
               onChange={e => this.setState({selectedOption : e.target.value})} />
               ID
        </label>
        <label>
        <input style = {{marginLeft: '15px'}}
               type="radio"
               value= "getbytitle/"
               checked={this.state.selectedOption === "getbytitle/"} 
               onChange={e => this.setState({selectedOption : e.target.value})} />  
               Title
        </label>   
        <input style = {{marginLeft: '15px'}} value={this.state.searchText} onChange={e => this.setState({ searchText: e.target.value })} />
        <button disabled = {this.state.isLoading} onClick={() => {this.ControlAndGetData(); this.setState({searchButton:true});}}>
          Search
        </button>
        <br />
        <br />
        {
         this.state.searchButton ? this.ControlAndShowData() : "You can search any movie..."
        }
      </div>
    );
  }
}

export default App;
