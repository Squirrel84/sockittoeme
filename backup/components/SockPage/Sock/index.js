import { connect } from 'react-redux';
import getSockById from 'actions';

import Sock from './Sock';

const mapStateToProps = state => ({
  currentSock: state.socks.currentSock
});

const mapDispatchToProps = dispatch => ({
  getSock: id => {
    dispatch(getSockById(id));
  }
});

export default connect(mapStateToProps, mapDispatchToProps)(Sock);
