const createRequest = (endpoint,
  { body, method = 'GET', headers = { 'Content-Type': 'application/json' }, mode = 'cors', encType = null }) =>
  fetch(endpoint, {
    body,
    method,
    encType,
    mode,
    headers: {
      pragma: 'no-cache',
      'cache-control': 'no-cache',
      ...headers
    }
  });

const fetchFromApi = (url, requestOptions = {}) =>
  createRequest(url, requestOptions)
    .then(response => {
      // alert("requesting data " + url + " status:" +  response.status);
      if (response.status === 401) {
        return new Error('login required');
      }
      return response;
    });

export default fetchFromApi;
