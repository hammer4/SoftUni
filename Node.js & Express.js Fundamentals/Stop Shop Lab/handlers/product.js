const fs = require('fs');
const path = require('path');

const Product = require('../models/Product');
const Category = require('../models/Category');

module.exports.addGet = (req, res) => {
    Category.find().then((categories) => {
        res.render('product/add', {categories: categories})
    })
} 

module.exports.addPost = (req, res) => {
    let productObj = req.body;
    productObj.image = '\\' + req.file.path;

    Product.create(productObj).then((product) => {
        Category.findById(product.category).then((category) => {
            category.products.push(product._id);
            category.save();
        })
        res.redirect('/');
    })
}

module.exports.editGet = (req, res) => {
    let id = req.params.id;
    Product.findById(id).then(product => {
        if(!product){
            res.sendStatus(404);
            return;
        }

        Category.find().then((categories) => {
            res.render('product/edit', {
                product: product,
                categories: categories
            })
        })
    })
}

module.exports.editPost = (req, res) => {
    let id = req.params.id;
    let editedProduct = req.body;

    Product.findById(id).then((product) => {
        if(!product) {
            res.redirect(`/?error=${encodeURIComponent('Product was not found!')}`);
            return;
        }

        product.name = editedProduct.name;
        product.description = editedProduct.description;
        product.price = editedProduct.price;

        if(req.file) {
            product.image = '\\' + req.file.path;
        }

        if(product.category.toString() !== editedProduct.category) {
            Category.findById(product.category).then((currentCategory) => {
                Category.findById(editedProduct.category).then((nextCategory) => {
                    let index = currentCategory.products.indexOf(product._id);
                    if (index >= 0) {
                        currentCategory.products.splice(index, 1);
                    }
                    currentCategory.save();

                    nextCategory.products.push(product._id);
                    nextCategory.save();

                    product.category = editedProduct.category;

                    product.save().then(() => {
                        res.redirect('/?success=' + encodeURIComponent('Product was edited successfully'));
                    })
                })
            })
        } else {
            product.save().then(() => {
                res.redirect('/?success=' + encodeURIComponent('Product was edited successfully'));
            })
        }
    })
}

module.exports.deleteGet = (req, res) => {
    let id = req.params.id;
    Product.findById(id).then(product => {
        if(!product){
            res.sendStatus(404);
            return;
        }

        res.render('product/delete', {product: product});
    })
}

module.exports.deletePost = (req, res) => {
    let id = req.params.id;

    Product.findById(id).then((product) => {
        if(!product) {
            res.redirect(`/?error=${encodeURIComponent('Product was not found!')}`);
            return;
        }

        Category.findById(product.category).then((category) => {
            let index = category.products.indexOf(id);
            if(index >= 0) {
                category.products.splice(index, 1);                
            }
            category.save();
            
            Product.remove({_id: id}).then(() => {
                fs.unlink(path.normalize(path.join('.', product.image)), () => {
                    res.redirect('/?success=' + encodeURIComponent('Product was deleted successfully'));             
                })
            })
        })
    })
}

module.exports.buyGet = (req, res) => {
    let id = req.params.id;
    Product.findById(id).then(product => {
        if(!product){
            res.sendStatus(404);
            return;
        }

        res.render('product/buy', {product: product});
    })
}