angular.module('BetrayalApp', ['ngRoute'])

.controller('BetrayalController', function($scope, $http){
	$scope.reset = function(){
		$http.post('http://localhost:59858/api/betrayal/Reset');
	};
});