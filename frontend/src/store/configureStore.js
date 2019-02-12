import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { connectRouter } from 'connected-react-router';
import rootReducer from './reducers';

export default function configureStore(history) {
  /* eslint-enable */
  const store = createStore(
    connectRouter(history)(rootReducer),
    applyMiddleware(thunk)
  );

  if (module.hot) {
    module.hot.accept('./reducers', () => {
      store.replaceReducer(rootReducer);
    });
  }

  return store;
}
