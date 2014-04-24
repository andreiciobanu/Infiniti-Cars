var demo = angular.module('demo', ['ngRoute']);

demo.config(['$routeProvider', '$locationProvider',
  function ($routeProvider, $locationProvider) {
      $routeProvider
          //.when('/Home', { templateUrl: 'app/Templates/Make/Makes.html', controller: 'makesController' })
           .when('/Home', { templateUrl: 'app/Templates/User/Users.html', controller: 'usersController' })
            //makes
          .when('/Makes', { templateUrl: 'app/Templates/Make/Makes.html', controller: 'makesController' })
          .when('/MakeAdd', { templateUrl: 'app/Templates/Make/MakeAdd.html', controller: 'makeAddController' })
          .when('/MakeEdit/:makeId', { templateUrl: 'app/Templates/Make/MakeEdit.html', controller: 'makeEditController' })
          // users
          .when('/Users', { templateUrl: 'app/Templates/User/Users.html', controller: 'usersController' })
          .when('/UserAdd', { templateUrl: 'app/Templates/User/UserAdd.html', controller: 'userAddController' })
          .when('/UserEdit/:userId', { templateUrl: 'app/Templates/User/UserEdit.html', controller: 'userEditController' })

          .otherwise({
              redirectTo: '/Home'
          });

      //$locationProvider.html5Mode(true);

  }]);
