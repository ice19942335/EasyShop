'use strict';

const API = 'https://localhost:44374';

class DevBlogLikes {
    constructor() {
        this.linkNodes = document.querySelectorAll('[data-postId]');
    }
    fetchData(url) {
        return fetch(url)
            .then(result => result.json())
            .catch(error => console.log(error));
    }
    async linksInitialization() {
        for (let node of this.linkNodes) {
            let postId = node.dataset.postid;
            const response = await this.fetchData(`${API}/DevBlog/UserHasAlreadyLikedThePost?postId=${postId}`);

            this.setLinkStyles(response, node);
            this.setLinkEvent(node, postId);
        }
    }
    async setLinkEvent(node, postId){
        node.addEventListener('click', async e => {
            e.preventDefault();
            const response = await this.fetchData(`${API}/DevBlog/IncrementLike?postId=${postId}`);
            if(response.result.toLowerCase() === 'NotAuthenticated'.toLowerCase()){
                window.location.href = `${API}/Account/Register`;
            }
            this.setLinkStyles(response, node);
            this.setCounterStyels(response, node);
        });
    }
    async setLinkStyles(response, node) {
        if (response.result.toLowerCase() === 'true') {
            node.style.color = '#00aced';
        } else if(response.result.toLowerCase() === 'false'){
            node.style.color = '#ccc';
        }
    }
    setCounterStyels(response, node){
        const likesCounterNode = node.parentNode.lastChild.previousElementSibling.children[0];
        let splitedText = likesCounterNode.innerText.split(' ');
        let likesCounter = parseInt(splitedText[1])

        if(response.result.toLowerCase() === 'true'){
            likesCounter = likesCounter + 1;
            likesCounterNode.innerText = `Likes: ${likesCounter}`;
        }
        if(response.result.toLowerCase() === 'false'){
            likesCounter = likesCounter - 1;
            likesCounterNode.innerText = `Likes: ${likesCounter}`;
        }

        if(likesCounter === 0){
            likesCounterNode.style.display = 'none';
        }else if(likesCounter > 0){
            likesCounterNode.style.display = 'block';
        }
    }
    _init() {
        this.linksInitialization(this.linkNodes);
    }
}

const devBlog = new DevBlogLikes();
devBlog._init();