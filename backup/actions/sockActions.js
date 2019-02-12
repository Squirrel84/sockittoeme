import apiHost from 'utils/apiHost';
import fetchFromApi from 'utils/fetchFromApi';

export const getSockStart = id => ({
  type: 'GET_SOCK',
  id
});

export const getSockSuccess = receivedData => ({
  type: 'GET_SOCK_SUCCESS',
  receivedData
});

export const getSockFail = () => ({
  type: 'GET_SOCK_FAIL'
});

export const getSockApi = id =>
fetchFromApi(`${apiHost}sock/get/${id}`)
  .then(r => {
    if (!r.ok) { return null; }
    return r.json();
  })
  .catch(() => null);

export const getSockById = id =>
  dispatch => {
    dispatch(getSockStart(id));
    return getSockApi(id)
      .then(json => {
        dispatch(getSockSuccess(json));
      })
      .catch(() => dispatch(getSockFail()));
  };
