import React from 'react';
import { PropTypes } from 'prop-types';

let sockIdFromUrl = 0;
class Sock extends React.Component {
  constructor(props) {
    console.log('constructor');
    super(props);
    sockIdFromUrl = this.props.match.params.id;
    console.log(`sock id from url ${sockIdFromUrl}`);
  }

  componentDidMount() {
    console.log('componentDidMount');
    if (this.props.currentSock === null || this.props.currentSock.sockId !== sockIdFromUrl) {
      console.log(`getting sock by id ${sockIdFromUrl}`);
      this.props.getSock(sockIdFromUrl);
    }
  }

  render() {
    if (this.props.error) {
      return (<div>An Error Has Occurred</div>);
    }
    console.log('render');
    if (this.props.currentSock) {
      console.log(`render sock by id ${sockIdFromUrl}`);
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
  getSock: PropTypes.func.isRequired,
  error: PropTypes.bool
};

Sock.defaultProps = {
  currentSock: null,
  error: false
};

export default Sock;
