module.exports = {
    isAuthenticated: (req, res, next) => {
        if(req.isAuthenticated()) {
            next();
        } else {
            res.redirect('/user/login');
        }
    },
    isInRole: (role) => {
        return (req, res, next) => {
            if(req.user && req.user.roles.indexOf(role) > -1) {
               next();
            } else {
                res.redirect('/user/login');
            }
        }
    }
}