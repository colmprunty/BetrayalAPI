angular.module('BetrayalApp', ['ngRoute'])

.controller('BetrayalController', function($scope, $http){
	
	$scope.reset = function(){
		$http.post('http://localhost:59858/api/Admin/Reset');
	};

	$scope.loadCharacters = function(){		
		$http.get('http://localhost:59858/api/betrayal/GetCharacters').success(function(data){			
			$scope.characters = data;
		});
	}

	$scope.selectCharacter = function(id){
		$http.post('http://localhost:59858/api/Betrayal/SetCharacter/id');
	}
});