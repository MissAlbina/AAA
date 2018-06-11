'use strict';

angular.module('RestaurantSiteApp')
  .service('DataBaseService', ['$http', function ($http) {

      this.AddClientItem = function (client) {
          var response = $http({
              method: "post",
              url: "/Client/AddClient",
              data: JSON.stringify(client),
              dataType: "json"
          });
          return response;
      }

      this.GetClientItem = function (clientID) {
          var response = $http({
              method: "get",
              url: "/Client/GetClientByNo",
              params: {
                  id: JSON.stringify(clientID)
              }
          });
          return response;
      }

      this.GetTotalItems = function (search) {
          var response = $http({
              method: "get",
              url: "/Client/GetTotalItems",
              params: {
                  search: search
              }
          });
          return response;
      }

      //Delete Client
      this.DeleteClientItem = function (client) {
          var response = $http({
              method: "post",
              url: "/Client/DeleteClient",
              data: JSON.stringify(client),
              dataType: "json"
          });
          return response;
      }

      // Update Client
      this.UpdateClientItem = function (client) {
          var response = $http({
              method: "post",
              url: "/Client/UpdateClient",
              data: JSON.stringify(client),
              dataType: "json"
          });
          return response;
      }


      //RestaurantMenuController
      this.GetMenuItem = function (menuItemsID) {
          var response = $http({
              method: "get",
              url: "/RestaurantMenu/GetMenuItemByNo",
              params: {
                  id: JSON.stringify(menuItemsID)
              }
          });
          return response;
      }

      this.GetTotalItemsMenu = function (search) {
          var response = $http({
              method: "get",
              url: "/RestaurantMenu/GetTotalItems",
              params: {
                  search: search
              }
          });
          return response;
      }

      // Add 
      this.AddMenuItem = function (item) {
          var response = $http({
              method: "post",
              url: "/RestaurantMenu/AddMenuItem",
              data: JSON.stringify(item),
              dataType: "json"
          });
          return response;
      }

      // Update
      this.UpdateMenuItem = function (item) {
          var response = $http({
              method: "post",
              url: "/RestaurantMenu/UpdateMenuItem",
              data: JSON.stringify(item),
              dataType: "json"
          });
          return response;
      }

      //Delete
      this.DeleteMenuItem = function (item) {
          var response = $http({
              method: "post",
              url: "/RestaurantMenu/DelMenuItem",
              data: JSON.stringify(item),
              dataType: "json"
          });
          return response;
      }

      // CheckCheng
      this.CheckCheng = function (item) {
          var response = $http({
              method: "post",
              url: "/RestaurantMenu/CheckCheng",
              data: JSON.stringify(item),
              dataType: "json"
          });
          return response;
      }
  }]);
