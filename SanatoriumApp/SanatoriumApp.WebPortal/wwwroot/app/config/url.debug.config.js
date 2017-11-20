var apiTokenUrl = 'http://localhost/SanatoriumApp.WebPortal/token';
var serverApiUri = 'http://localhost/SanatoriumApp.WebPortal/';
var clientUrl = 'http://localhost/SanatoriumApp.WebPortal/39484/';

angular.module('DataAccessApp').constant('ngUrlSettings', {
    apiTokenUrl: apiTokenUrl,
    serverApiUri: serverApiUri,
    curentUrl: clientUrl,
    clientId: 'DataAccessClientId'
});
