import config from '../config.json';
import getEnvironment from './getEnvironment';

const env = getEnvironment();

Object.keys(config).map(key => {
  if (typeof config[key] === 'object' && config[key][env]) {
    config[key] = config[key][env];
  }
  return key;
});

export default config;
