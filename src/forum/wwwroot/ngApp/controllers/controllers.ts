namespace forum.Controllers {

    export class HomeController {
        public boards;

        constructor(
            private $http: ng.IHttpService,
            private $state: ng.ui.IStateService
        ) {
            $http.get('/api/boards')
                .then((s) => {
                    this.boards = s.data;
                });
        }
    }

    export class BoardController {
        public board;
        public postId;
        public error;

        constructor(
            private $http: ng.IHttpService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            $http.get(`/api/boards/${$stateParams['boardName']}`)
                .then((s) => {
                    this.board = s.data;
                    this.postId = $stateParams;
                })
                .catch((e) => {
                    console.log(e);
                });
        }

    }

    export class PostController {
        public post;
        
        constructor(
            private $http: ng.IHttpService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            $http.get(`/api/posts/${$stateParams['boardName']}/${$stateParams['postId']}`)
                .then((s) => {
                    this.post = s.data;
                })
                .catch((e) => {
                    console.log(e);
                    $state.go('board.list');
                });
        }
            
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'About Me';
    }

}
