import { connect } from 'react-redux';
import { getSockById } from '../../../actions/sockActions';

import Sock from './Sock';

function mapStateToProps(state) {
  return {
    currentSock: state.socks.currentSock,
    error: state.socks.error
  };
}

function mapDispatchToProps(dispatch) {
  return {
    getSock: id => dispatch(getSockById(id))
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(Sock);
