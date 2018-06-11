'use strict';
var RestaurantSiteApp = angular.module('RestaurantSiteApp', ['ngResource', 'ngTable', 'ui.bootstrap', 'ngTouch', 'ngAnimate', 'file-model'])
    .config(['uibPaginationConfig', function (uibPaginationConfig) {
                                               uibPaginationConfig.previousText = "‹";
                                               uibPaginationConfig.nextText = "›";
                                               uibPaginationConfig.firstText = "«";
                                               uibPaginationConfig.lastText = "»";
    }]);