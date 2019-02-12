import { SOCK_GET_SUCCESS, SOCK_GET_FAILURE } from '../../actions/sockActions';

const socks = (state = {}, action) => {
  switch (action.type) {
    case SOCK_GET_SUCCESS:
      console.log('sock success');
      return {
        ...state,
        currentSock: action.receivedData
      };
    case SOCK_GET_FAILURE:
      return {
        ...state,
        error: true
      };
    default:
      return state;
  }
};

export default socks;
