import React from 'react';
import ReactDOM from 'react-dom';
import { createStore } from 'redux';
import { AppContainer } from 'react-hot-loader';
import { createBrowserHistory } from 'history';
import App from './App';
import rootReducer from './reducers';

const store = createStore(rootReducer);
const history = createBrowserHistory();

const render = () => {
  ReactDOM.render(
    <AppContainer>
      <App store={store} history={history} />
    </AppContainer>,
    document.getElementById('root')
  );
};

const main = () => {
  render();
  if (module.hot) {
    module.hot.accept('./App', () => render());
  }
};

main();
