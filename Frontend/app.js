angular.module('BetrayalApp', ['ngRoute'])

.controller('BetrayalController', function($scope, $http){
	
	$scope.reset = function(){
		$http.post('http://localhost:59858/api/Admin/Reset');
	};

	$scope.loadCharacters = function(){		
		$http.get('http://localhost:59858/api/betrayal/GetCharacters').success(function(data){
			//alert('this has worked');
			$scope.characters = data;
		});
	}

	$scope.getEm = function(){
		$scope.characters = [{"Name":"Ox Bellows","Speed":[0,2,2,2,3,4,5,5,6],"CurrentSpeed":5,"Might":[0,4,5,5,6,6,7,8,8],
								"CurrentMight":3,"Sanity":[0,2,2,3,4,5,5,6,7],"CurrentSanity":3,"Knowledge":[0,2,2,3,3,5,5,6,6],
								"CurrentKnowledge":3,"InUse":false,"InUseBy":null,"Id":1},{"Name":"Darrin 'Flash' Williams","Speed":[0,4,4,4,5,6,7,7,8],
								"CurrentSpeed":5,"Might":[0,2,3,3,4,5,6,6,7], "CurrentMight":3,"Sanity":[0,1,2,3,4,5,5,5,7],"CurrentSanity":3,
								"Knowledge":[0,2,3,3,4,5,5,5,7],"CurrentKnowledge":3,"InUse":false,"InUseBy":null,"Id":2}]
	}
});