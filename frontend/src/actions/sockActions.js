import apiHost from 'utils/apiHost';
import fetchRequest from 'utils/fetch-request';

export const SOCK_GET_REQUEST = 'SOCK_GET_REQUEST';
export const SOCK_GET_SUCCESS = 'SOCK_GET_SUCCESS';
export const SOCK_GET_FAILURE = 'SOCK_GET_FAILURE';

export const getSockRequest = id => ({
  type: SOCK_GET_REQUEST,
  sockId: id
});

export const getSockSuccess = response => ({
  type: SOCK_GET_SUCCESS,
  receivedData: response
});

export const getSockFailure = () => ({
  type: SOCK_GET_FAILURE
});

export const getSockByApi = id =>
fetchRequest(`${apiHost}sock/get/${id}`)
  .then(r => {
    if (!r.ok) { return null; }
    return r.json();
  })
  .catch(() => null);

export const getSockById = id =>
  dispatch => {
    dispatch(getSockRequest(id));
    return getSockByApi(id)
      .then(response => {
        if (response == null) {
          dispatch(getSockFailure());
        } else {
          dispatch(getSockSuccess(response));
        }
      })
      .catch(() => dispatch(getSockFailure()));
  };
