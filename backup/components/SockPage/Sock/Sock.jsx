import React from 'react';
import { PropTypes } from 'prop-types';

class Sock extends React.Component {
  componentDidMount() {
    this.props.getSock(this.props.match.params.id);
  }

  render() {
    if (this.props.currentSock) {
      return (
        <div className="container">
          <div className="span3 well" style={{ textAlign: 'center' }}>
            <a href="#aboutModal" data-toggle="modal" data-target="#myModal">
              <img
                alt="profile"
                src="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRbezqZpEuwGSvitKy3wrwnth5kysKdRqBW54cAszm_wiutku3R"
                name="aboutme" width="140" height="140"
                className="img-circle"
              />
            </a>
            <h3>Joe Sixpack</h3>
            <em>click my face for more</em>
          </div>
        </div>
      );
    }
    return (<div>Loading...</div>);
  }
}

Sock.propTypes = {
  match: PropTypes.object.isRequired,
  currentSock: PropTypes.object,
  getSock: PropTypes.func.isRequired
};

Sock.defaultProps = {
  currentSock: null
};

export default Sock;
