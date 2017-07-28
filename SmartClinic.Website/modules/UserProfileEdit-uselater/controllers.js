/*
Create By  : Tony Jacob
Description: Controller for UserProfileEdit module
*/
'use strict';
 
console.log('From UserProfileEdit-controllers.js');
angular.module('UserProfileEdit')
 
.controller('UserProfileEditController',
    ['$scope', '$rootScope', '$location', 'AuthenticationService', 'UtilityService', 
    function ($scope, $rootScope, $location, AuthenticationService, UtilityService) {
		console.log("Inside UserProfileEditController");
		
		$scope.loggedIn = false;
		$scope.UsrType = '';
		
		//$scope.existingUserInfoList = null;
	
		$scope.formLoad = function () {
			console.log("tjv...Inside formLoad UserProfileEdit");
			
			
			
			return;
		};
		
		$scope.dummy = function () {
			
			return;
		};
		
		var initVariables = function()
        {
			//$scope.existingUserInfoList = UtilityService.ExistingUserInfoList;
		};
		
		var init = function () 
		{
			initVariables();
			
            return;
        };
		
		init();
			
    }]);