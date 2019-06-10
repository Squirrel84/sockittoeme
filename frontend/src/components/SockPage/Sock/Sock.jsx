import React from 'react';
import { PropTypes } from 'prop-types';
import getSockById from '../../../actions/sockActions';

class Sock extends React.Component {
  constructor(props) {
    super(props);
    this.state = { currentSock: null };
    this.getSock = this.getSock.bind(this);
  }

  componentDidMount() {
    if (this.state.currentSock === null) {
      this.getSock(this.props.match.params.id);
    }
  }

  getSock(id) {
    getSockById(id).then(sock => {
      console.log(sock);
      this.setState({ currentSock: sock, error: sock === null });
    });
  }

  render() {
    if (this.state.error) {
      return (<h1>Oops... We have lost your sock!!!</h1>);
    }
    if (this.state.currentSock) {
      console.log(this.state.currentSock);
      return (
        <div className="container">
          <div className="span3 well" style={{ textAlign: 'center' }}>
            <img
              alt="sock"
              src="/public/images/Sock404.png"
              name="aboutsock" width="480" height="480"
              className="img-circle"
            />
            <h3>{this.state.currentSock.description}</h3>
            <h4>Colour: {this.state.currentSock.colour}</h4>
            <h4>Material: {this.state.currentSock.material}</h4>
            <h4>Thickness: {this.state.currentSock.thickness}</h4>
          </div>
        </div>
      );
    }
    return (<div>Loading...</div>);
  }
}

Sock.propTypes = {
  match: PropTypes.shape({
    params: PropTypes.shape({
      id: PropTypes.node,
    }).isRequired,
  }).isRequired
};

Sock.defaultProps = {
};

export default Sock;
