import axios from 'axios'

const Api = axios.create({ baseURL: 'localhost:3000' });

export default Api;