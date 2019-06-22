const axios = require('axios');

const instance = axios.create({
    baseURL: 'http://localhost:5000/api/movie/',
    timeout: 10000,
    headers: {'X-Custom-Header': 'foobar'}
  });

  export default instance;