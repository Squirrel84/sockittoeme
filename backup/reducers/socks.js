const socks = (state = {}, action) => {
  switch (action.type) {
    case 'GET_SOCK_SUCCESS':
      return {
        ...state,
        currentSock: action.receivedData
      };
    default:
      return state;
  }
};

export default socks;
