const createRequest = (endpoint,
  { body, method = 'GET', headers = { 'Content-Type': 'application/json' }, mode = 'no-cors', encType = null }) =>
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

const fetchRequest = (url, requestOptions = {}) => createRequest(url, requestOptions).then(response => response);

export default fetchRequest;
