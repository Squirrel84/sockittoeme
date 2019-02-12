const DEFAULT_ENV = 'local';

let env;
const appEl = document.getElementById('root');

if (appEl) {
  env = appEl.getAttribute('data-env');
}

const getEnvironment = () => env || DEFAULT_ENV;

export default getEnvironment;
