import {get, post} from './requester';

function addComment(postId, text, author, callback) {
    let commentData = {
        text: text,
        author: author,
        postId: postId
    };

    post('appdata', 'comments', commentData, 'kinvey')
        .then(callback);
}

function loadComments(postId, callback) {
    get('appdata', `comments?query={"postId":"${postId}"}`, 'kinvey')
        .then(callback)
}

export {addComment, loadComments}