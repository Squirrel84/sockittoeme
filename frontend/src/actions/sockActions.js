import apiHost from 'utils/apiHost';
import fetchRequest from 'utils/fetch-request';

const getSockById = id => fetchRequest(`${apiHost}sock/get/${id}`)
    .then(r => r.json())
    .catch(ex => {
      console.log(ex.message);
      return null;
    });

export default getSockById;
