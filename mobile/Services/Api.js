import axios from 'axios'

const Api = axios.create({ baseURL: 'http://leobonetti.com' });

export default Api;