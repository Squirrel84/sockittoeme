import React from 'react';
import { PropTypes } from 'prop-types';
import { Provider } from 'react-redux';
import { Route, Router, Switch } from 'react-router-dom';

import Home from './components/HomePage/Home';
import Sock from './components/SockPage/Sock';
import PageNotFound from './components/PageNotFound';
import './scss/main.scss';

const App = ({ store, history }) =>
  <Provider store={store}>
    <Router history={history}>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route exact path="/sock/:id" component={Sock} />

        <Route component={PageNotFound} />
      </Switch>
    </Router>
  </Provider>;

App.propTypes = {
  history: PropTypes.object.isRequired,
  store: PropTypes.object.isRequired,
};

export default App;
