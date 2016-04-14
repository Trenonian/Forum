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
                    $state.go('home');
                });
        }

    }

    export class PostController {
        public post;

        public editComment(comment) {
            if (comment.creator.userName == this.accountService.getUserName() && !comment.editing) {
                comment.editedContent = comment.content;
                comment.editing = true;
            }
            else
            {
                comment.editedContent = null;
                comment.editing = false;
            }
        }

        public saveChanges(comment) {
            console.log(`content: ${comment.editedContent}`);
            if (comment.creator.userName == this.accountService.getUserName()) {
                this.$http.put(`/api/comments/${comment.id}`, `"${comment.editedContent}"`)
                    .then((s) => {
                        comment.editing = false;
                        comment.content = comment.editedContent;
                        comment.editedContent = null;
                        comment.error = null;
                    })
                    .catch((e) => {
                        comment.error = "Could not edit comment.";
                    });
            }
        }
        
        constructor(
            private $http: ng.IHttpService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private accountService: forum.Services.AccountService
        ) {
            $http.get(`/api/posts/${$stateParams['boardName']}/${$stateParams['postId']}`)
                .then((s) => {
                    this.post = s.data;
                })
                .catch((e) => {
                    console.log(e);
                    $state.go('board.list', {boardName:$stateParams['boardName']});
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
