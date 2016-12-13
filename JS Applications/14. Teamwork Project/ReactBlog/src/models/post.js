import {get, post, update, deleteItem} from './requester';

function loadPosts(callback) {
    // Request posts from db
    get('appdata', 'posts?sort={"_kmd.lmt": -1}', 'kinvey')
        .then(callback);
}

function loadRecentPosts(callback) {
    get('appdata', 'posts?limit=3&sort={"_kmd.lmt": -1}', 'kinvey')
        .then(callback);
}

function create(title, content, callback) {
    let postData = {
        title: title,
        content: content
    };
    post('appdata', 'posts', postData, 'kinvey')
        .then(callback);
}

function loadPostDetails(postId, onPostSuccess) {
    get('appdata', 'posts/' + postId, 'kinvey')
        .then(onPostSuccess);
}

function deletePost(postId, callback) {
    deleteItem('appdata', 'posts', postId, 'kinvey')
        .then(callback);

}

function edit(postId, name, description, callback) {
    let teamData = {
        title: name,
        content: description
    };
    update('appdata', 'posts/' + postId, teamData, 'kinvey')
        .then(callback(true))
        .catch(callback);
}

function loadAuthorsDetails(userId, onAuthorsSuccess) {
    get('appdata', `authors?query={"user_id":"${userId}"}`, 'kinvey')
        .then(onAuthorsSuccess);
}

export {loadPosts, loadRecentPosts, create, loadPostDetails, deletePost, edit, loadAuthorsDetails}
