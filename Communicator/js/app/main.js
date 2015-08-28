(function () {

    angular.module('communicator', ['ngMaterial']).controller('DemoController', DemoController);


    function DemoController($scope, $mdSidenav) {

        $scope.foto = 'https://material.angularjs.org/latest/img/list/60.jpeg?0';
        $scope.nombre = 'Me';
        $scope.conversaciones = [];
        $scope.toggleConversaciones = toggleConversaciones;

        init();

        function init() {
            for (var i = 0; i < 100; i++) {
                $scope.conversaciones.push({
                    imagen: 'https://material.angularjs.org/latest/img/list/60.jpeg?' + i,
                    nombre: 'Fulanito de tal',
                    grupo: 'desarrollo',
                    texto: 'asdfasdf....'
                });
            }
        }

        function toggleConversaciones() {
            $mdSidenav('conversaciones').toggle();
        }

    }

})();