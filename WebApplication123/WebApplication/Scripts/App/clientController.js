'use strict';
angular.module('RestaurantSiteApp').controller('ClientController', ['$scope', '$resource', 'DataBaseService', function ($scope, $resource, DataBaseService) {
    var _cntrl = this;

    _cntrl.setPage = _setPage;
    _cntrl.pageChanged = _pageChanged;
    _cntrl.AddClient = _AddClient;
    _cntrl.EditClient = _EditClient;
    _cntrl.ClientDiv = _ClientDiv;
    _cntrl.CancelClientDiv = _CancelClientDiv;
    _cntrl.DeleteClient = _DeleteClient;
    _cntrl.refreshData = _refreshData;
    _cntrl.enterSearch = _enterSearch;
    _cntrl.cancelSearch = _cancelSearch;
    _cntrl.UpdateClient = _UpdateClient;

    _cntrl.divClient = false;
    _cntrl.currentPage = 1;
    _cntrl.numPerPage = 5;
    _cntrl.statusSort = false;
    _getTotalItems();
    _cntrl.sortName = "id";
    _RefreshData("id", 1);

    function _AddClient() {
        var Client = {
            Id: 0,
            surname: _cntrl.clientsurname,
            name: _cntrl.clientname,
            patronymic: _cntrl.clientpatronymic,
            phone: _cntrl.clientphone,
            table_number: _cntrl.clienttable_number,
            time: _cntrl.clienttime,
            hours: _cntrl.clienthours,
            date_time_reg: null,
            comment_text: ""
        };

            var getData = DataBaseService.AddClientItem(Client);
            getData.then(function (msg) {
                alert(msg.data);

            }, function () {
                alert('Error in adding record');
            });
        
    }

    function _getTotalItems(sortName, numberPage, statusSort, search) {
        var getData = DataBaseService.GetTotalItems(search);
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
        _cntrl.allClients = _GetCurrentList(sortName, numberPage, statusSort, search);
    }

    //получение записей 
    function _GetCurrentList(sortName, numberPage, statusSort, search) {
        return $resource('/Client/GetClients').query({ sort: sortName, numberPage: numberPage, statusSort: statusSort, search: search });
    }

    //метод для сортировки по полям таблицы
    function _refreshData(sortName) {
        if (sortName == _cntrl.sortNamePrev) {
            _cntrl.statusSort = !_cntrl.statusSort;
            _cntrl.reverse = !_cntrl.reverse;
        }
        else {
            _cntrl.statusSort = false;
            _cntrl.reverse = false;
        }
        _cntrl.sortName = sortName;
        _cntrl.sortKey = sortName;
        _cntrl.sortNamePrev = sortName;
        _RefreshData(sortName, _cntrl.currentPage, _cntrl.statusSort, _cntrl.search);
    }

    //метод для поиска по записям
    function _enterSearch(keyEvent) {
        if (keyEvent.which === 13) {
            _getTotalItems(_cntrl.sortName, 1, _cntrl.statusSort, _cntrl.search);
        }
    }

    //сброс поиска по записям
    function _cancelSearch(keyEvent) {
        _cntrl.search = "";
        _getTotalItems(_cntrl.sortName, 1, _cntrl.statusSort, _cntrl.search);
        _cntrl.setPage(1);
    }

    function _DeleteClient(client) {
        var getData = DataBaseService.DeleteClientItem(client);
        getData.then(function (msg) {
            alert('Client Deleted');
            _getTotalItems();
            _cntrl.setPage(1);
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    //редактирование 
    function _EditClient(client) {
        var getData = DataBaseService.GetClientItem(client.Id);
        getData.then(function (clientItem) {
            _cntrl.client = clientItem.data;
            _cntrl.clientId = client.Id;
            _cntrl.clientsurname = client.surname;
            _cntrl.clientname = client.name;
            _cntrl.clientpatronymic = client.patronymic;
            _cntrl.clientphone = client.phone;
            _cntrl.clienttable_number = client.table_number;
            _cntrl.clienttime = client.time;
            _cntrl.clienthours = client.hours;
            _cntrl.clientdate_time_reg = client.date_time_reg;
            _cntrl.clientcomment_text = client.comment_text;
            _cntrl.Action = "Update";
            _cntrl.divClient = true;
        },
        function () {
            alert('Error in getting records');
        });
    }

    function _ClientDiv() {
        _ClearFields();
        _cntrl.Action = "Add";
        _cntrl.divClient = true;
    }

    //кнопка "Отмена"
    function _CancelClientDiv() {
        _ClearFields();
        _cntrl.divClient = false;
    }

    function _ClearFields() {
        _cntrl.clientId = "";
        _cntrl.clientsurname = "";
        _cntrl.clientname = "";
        _cntrl.clientpatronymic = "";
        _cntrl.clientphone = "";
        _cntrl.clienttable_number = "";
        _cntrl.clienttime = "";
        _cntrl.clienthours = "";
        _cntrl.clientdate_time_reg = "";
        _cntrl.clientcomment_text = "";
    }

    function _UpdateClient() {
        var UpClient = {
            surname: _cntrl.clientsurname,
            name: _cntrl.clientname,
            patronymic: _cntrl.clientpatronymic,
            phone: _cntrl.clientphone,
            table_number: _cntrl.clienttable_number,
            time: _cntrl.clienttime,
            hours: _cntrl.clienthours,
            date_time_reg: _cntrl.clientdate_time_reg,
            comment_text: _cntrl.clientcomment_text
        };
        UpClient.Id = _cntrl.clientId;
        var getData = DataBaseService.UpdateClientItem(UpClient);
            getData.then(function (msg) {
                alert(msg.data);
                _cntrl.divClient = false;
                _RefreshData(_cntrl.sortName, _cntrl.currentPage, _cntrl.statusSort, _cntrl.search);
            }, function () {
                alert('Error in updating record');
            });       
           }

}]);