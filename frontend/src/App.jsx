import React from 'react';
import { PropTypes } from 'prop-types';
import { Route, Router, Switch } from 'react-router-dom';

import Home from './components/HomePage/Home';
import Sock from './components/SockPage/Sock';
import PageNotFound from './components/PageNotFound';
import './scss/main.scss';

const App = ({ history }) =>
  <Router history={history}>
    <Switch>
      <Route exact path="/" component={Home} />
      <Route exact path="/sock/:id" component={Sock} />

      <Route component={PageNotFound} />
    </Switch>
  </Router>;

App.propTypes = {
  history: PropTypes.object.isRequired
};

export default App;
