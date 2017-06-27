
module.exports = (product, user) => {
    let isAuthor = product.creator.equals(user._id);
    let isAdmin = user.roles.indexOf('Admin') >= 0;

    return isAuthor || isAdmin;
};
