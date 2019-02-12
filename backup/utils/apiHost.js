const url = () => `https://${window.location.host}`;

export default process.env.NODE_ENV === 'production' ? `${url()}/api/` : 'http://localhost:8081/api/';
