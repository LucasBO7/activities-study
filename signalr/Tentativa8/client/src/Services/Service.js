import axios from 'axios';

const apiPort = '3001';
const localApi = `http://localhost:${apiPort}`;

const api = axios.create({
    baseURL: localApi
});

export default api;