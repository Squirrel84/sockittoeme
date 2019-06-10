const createRequest = (endpoint,
  { body,
    method = 'GET',
    headers = {
      'Content-Type': 'application/json; charset=utf-8',
      'Access-Control-Allow-Credentials': 'true',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With'
    }, mode = 'cors', encType = null }) =>
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

const fetchRequest = (url, requestOptions = {}) =>
  createRequest(url, requestOptions)
    .then(response => response);

export default fetchRequest;
