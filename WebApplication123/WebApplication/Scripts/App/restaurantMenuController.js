'use strict';
angular.module('RestaurantSiteApp').controller('RestaurantMenuController', ['$scope', '$resource', 'DataBaseService', function ($scope, $resource, DataBaseService) {
    var _cntrl = this;

    _cntrl.setPage = _setPage;
    _cntrl.pageChanged = _pageChanged;
    _cntrl.AddMenuItemDiv = _AddMenuItemDiv;
    _cntrl.CancelMenuItemDiv = _CancelMenuItemDiv;
    _cntrl.AddUpdateMenuItem = _AddUpdateMenuItem;
    _cntrl.EditMenuItem = _EditMenuItem;
    _cntrl.DeleteMenuItem = _DeleteMenuItem;
    //_cntrl.refreshData = _refreshData;
    _cntrl.enterSearch = _enterSearch;
    _cntrl.cancelSearch = _cancelSearch;
    _cntrl.enterSearch2 = _enterSearch2;
    _cntrl.CheckCheng = _CheckCheng;

    _cntrl.divMenuItem = false;
    _cntrl.buttonAddMenuItem = true;
    _cntrl.currentPage = 1;
    _cntrl.numPerPage = 5;
    _cntrl.statusSort = false;
    _getTotalItemsMenu();
    _cntrl.sortName = "_Id";
    _RefreshData("_Id", 1);

    function _getTotalItemsMenu(sortName, numberPage, statusSort, search) {
        var getData = DataBaseService.GetTotalItemsMenu(search);
        getData.then(function (param) {
            _cntrl.totalItems = param.data;
            _RefreshData(sortName, numberPage, statusSort, search);
        },
        function () {
            _cntrl.totalItems = 1;
            _RefreshData();
        });
    }

    function _setPage(pageNo) {
        _cntrl.currentPage = pageNo;
    };

    function _pageChanged() {
        _RefreshData(_cntrl.sortName, _cntrl.currentPage, _cntrl.statusSort, _cntrl.search)
    };

    //обновление таблицы
    function _RefreshData(sortName, numberPage, statusSort, search) {
        //источник данных таблицы
        _cntrl.allMenuItems = _GetCurrentList(sortName, numberPage, statusSort, search);
    }

    //получение записей 
    function _GetCurrentList(sortName, numberPage, statusSort, search) {
        return $resource('/RestaurantMenu/GetMenuItems').query({ sort: sortName, numberPage: numberPage, statusSort: statusSort, search: search });
    }

    function _AddUpdateMenuItem() {
        debugger;
        var Item = {
            category: _cntrl._categoryItem,
            name: _cntrl._nameItem,
            information: _cntrl._informationItem,
            price: _cntrl._priceItem,
            picture: _cntrl._pictureItem.name
        };
        var getAction = _cntrl.Action;

        if (getAction == "Update") {          
            Item.Id = _cntrl._IdItem;
            var getData = DataBaseService.UpdateMenuItem(Item);
            getData.then(function (msg) {
                alert(msg.data);
                _cntrl.divMenuItem = false;
                _cntrl.buttonAddMenuItem = true;
                _RefreshData(_cntrl.sortName, _cntrl.currentPage, _cntrl.statusSort, _cntrl.search);
            }, function () {
                alert('Error in updating record');
            });
        }
        else {
            var getData = DataBaseService.AddMenuItem(Item);
            getData.then(function (msg) {
                alert(msg.data);
                _cntrl.divMenuItem = false;
                _cntrl.buttonAddMenuItem = true;
                _getTotalItemsMenu();
                _cntrl.setPage(1);
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    function _AddMenuItemDiv() {
        _cntrl.buttonAddMenuItem = false;
        _ClearFields();
        _cntrl.Action = "Add";
        _cntrl.divMenuItem = true;
    }

    function _CancelMenuItemDiv() {
        _ClearFields();
        _cntrl.buttonAddMenuItem = true;
        _cntrl.divMenuItem = false;
    }

    function _ClearFields() {
        _cntrl._IdItem = "";
        _cntrl._categoryItem = "",
        _cntrl._nameItem = "",
        _cntrl._informationItem = "",
        _cntrl._priceItem = "",
        _cntrl._pictureItem = ""
    }

    function _EditMenuItem(item) {
        var getData = DataBaseService.GetMenuItem(item._Id);
        getData.then(function (menuItem) {
            _cntrl.item = menuItem.data;
            _cntrl._IdItem = item._Id;
            _cntrl._categoryItem = item._category;
            _cntrl._nameItem = item._name;
            _cntrl._informationItem = item._information;
            _cntrl._priceItem = item._price;
            _cntrl._pictureItem = item._picture;
            _cntrl.Action = "Update";
            _cntrl.divMenuItem = true;
            _cntrl.buttonAddMenuItem = false;
        },
        function () {
            alert('Error in getting records');
        });
    }

    function _CheckCheng(item) {
        var Item = {
            Id : item._Id,
            availability: item._availability,
            novelty: item._novelty,
            hit: item._hit
        };       
        var getData = DataBaseService.CheckCheng(Item);
        getData.then(function (msg) {
            alert(msg.data);
            _RefreshData(_cntrl.sortName, _cntrl.currentPage, _cntrl.statusSort, _cntrl.search);
        }, function () {
            alert('Error in updating record');
        });
    }

    function _DeleteMenuItem(item) {
        var getData = DataBaseService.DeleteMenuItem(item);
        getData.then(function (msg) {
            alert('MenuItem Deleted');
            _getTotalItemsMenu();
            _cntrl.setPage(1);           
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    //метод для поиска по записям
    function _enterSearch(keyEvent) {
        if (keyEvent.which === 13) {
            _getTotalItemsMenu(_cntrl.sortName, 1, _cntrl.statusSort, _cntrl.search);
        }
    }

    //сброс поиска по записям
    function _cancelSearch(keyEvent) {
        _cntrl.search = "";
        _getTotalItemsMenu(_cntrl.sortName, 1, _cntrl.statusSort, _cntrl.search);
        _cntrl.setPage(1);
    }

    function _enterSearch2(item) {
        if (item != 0){
        _cntrl.search = item;}
        _getTotalItemsMenu(_cntrl.sortName, 1, _cntrl.statusSort, _cntrl.search);
    }
}]);