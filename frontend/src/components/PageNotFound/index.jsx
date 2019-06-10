import React from 'react';

const PageNotFound = () => (
  <div>
    <h1>Error 404 - Page Not Found</h1>
    <p>
      <strong>Description:</strong> HTTP 404. The resource you are looking for could have been removed, had its name
        changed, or is temporarily unavailable.  Please review the following URL and make sure that it is spelled correctly.
    </p>
    <p>
      <strong>Requested URL:</strong> { location.href }
    </p>
    <p><a href="/" title="home">Click here to go Home</a></p>
  </div>);

export default PageNotFound;
