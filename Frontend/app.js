angular.module('BetrayalApp', ['ngRoute'])

.controller('BetrayalController', function($scope, $http){
	
	$scope.reset = function(){
		$http.post('http://localhost:59858/api/betrayal/Reset');
	};

	$scope.loadCharacters = function(){		
		$http.get('http://localhost:59858/api/betrayal/GetCharacters').success(function(data){
			alert('this has worked');
			$scope.characters = data;
		});
	}
});