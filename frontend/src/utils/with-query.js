const e = encodeURIComponent;

const queryParams = params =>
    Object.keys(params).map(k => `${e(k)}=${e(params[k])}`).join('&');

const addParams = (url, params) => (params ? `${url}?${params}` : url);

export default (url, params) => addParams(url, queryParams(params));
