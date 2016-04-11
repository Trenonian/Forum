namespace forum.Controllers {

    export class HomeController {
        public posts;

        constructor(
            private $http: ng.IHttpService,
            private $state: ng.ui.IStateService
        ) {
            $http.get('api/posts/new')
                .then((s) => {
                    this.posts = s.data;
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
