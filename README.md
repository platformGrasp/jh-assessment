
# Jack Henry Assessment

**Portal Application**
 - The API comes with a console test application that connects to the API and pulls the report every 2 seconds, 
   while the API asynchronously processes the twitter api stream.
 - The challenge comes with a SPA application to have a better UI to show the full capability of the API. 
   The UI application uses angular; please ensure before running the code the first time ***run npm install***.
 - The Angular application connects to an API in the backend; the API
   URL is in the environment file.
 - To retrieve continuous messages from the backed API, the angular uses ***Signal-R***, it is highly recommended to run the API first, as   
   resilience reconnection is not implemented per time constraints.
 - Would you mind noticing the UI only shows the first 20 tweets as per 
   UI constraints, but is there a continuous data flow in the console   
   log (Warning View)
 - See the Twitter details link does an API call in the backed; I am   
   aware the continuous flow brings similar data, but to do a   
   demonstration of not blocking report, I am doing API call and socket 
   connection simultaneously.

**API Application**

 - In the app setting, you can find the Twitter section, replace your
   desired values, and use the current configuration, which is also valid.
 - Existing unit test integration was created for the development
   porpoise; unit test coverage is not near 10% per time constraints.
