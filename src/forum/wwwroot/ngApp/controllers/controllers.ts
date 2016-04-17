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
            if (comment.creator.userName == this.accountService.getUserName() && comment.editing) {
                this.$http.put(`/api/comments/${comment.id}`, `"${comment.editedContent}"`)
                    .then((s) => {
                        comment.editing = false;
                        comment.content = comment.editedContent;
                        comment.editedContent = null;
                        comment.editError = null;
                    })
                    .catch((e) => {
                        comment.editError = "Could not edit comment.";
                    });
            }
        }

        public reply(comment) {
            if (this.accountService.getUserName() && !comment.replying) {
                comment.replying = true;
                comment.reply = "";
            }
            else {
                comment.replying = false;
                comment.reply = null;
            }
        }

        public submitReply(comment) {
            if (this.accountService.getUserName() && comment.replying) {
                var reply:any = {};
                reply.creatorId = this.accountService.getUserName();
                reply.content = comment.reply;
                reply.created = Date.now;
                reply.parentPostId = this.post.id;
                this.$http.post(`/api/comments/${comment.id}`, reply)
                    .then((s) => {
                        comment.replying = false;
                        comment.reply = null;
                        comment.replyError = null;
                        reply = null;
                    })
                    .catch((e) => {
                        comment.replyError = "Could not reply to comment.";
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
