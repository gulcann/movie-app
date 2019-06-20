import React from 'react';
import PropTypes from 'prop-types';

class MovieView extends React.Component
{  constructor(props) {
    super(props);
   }
    movieList() {
        var valueArr = Object.assign(this.props.data);
        var arr = this.getMovieValues(valueArr);
        var tagArr = Object.keys(valueArr);
        var movieView = arr.map((i, index) => {
            return (<div key={i.imdbid} align="left">
                <span>
                    <strong>
                        {this.capitalizeFirstLetter(tagArr, index)}
                    </strong>
                </span>
                {"=" + arr[index]}
            </div>
            );
        });
        return movieView;
    }
    capitalizeFirstLetter(tagArr, index) {
        return tagArr[index].charAt(0).toUpperCase() + tagArr[index].slice(1);
    }

    getMovieValues(valueArr) {
        var arr = [];
        for (var key in valueArr) {
            if (Array.isArray(valueArr[key])) {
                var innerValuesArr = [];
                var tmpArr = Object.assign(valueArr[key]);
                for (let i = 0; tmpArr.length > i; i++) {
                    innerValuesArr.push(Object.values(tmpArr[i]));
                    if (i !== tmpArr.length - 1) {
                        innerValuesArr.push("-");
                    }
                }
                arr.push(innerValuesArr);
            }
            else {
                arr.push(valueArr[key]);
            }
        }
        return arr;
    }

render()
{
    return(
    <form>
         {this.movieList()}
    </form>
    );
}
}

MovieView.defaultProps = {
    data : []
};
MovieView.propTypes = {
    data : PropTypes.array.isRequired
};

export default MovieView;
