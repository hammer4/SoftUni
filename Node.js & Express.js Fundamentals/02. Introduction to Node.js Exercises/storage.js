const fs = require('fs');
const dataFile = 'storage.dat';

let data = {};

function validateKey(key) {
    if(typeof key !== 'string') {
        throw new Error('Key must be a string');
    }
}

function validateKeyExists(key) {
    return data.hasOwnProperty(key);
}

let put = (key, value) => {
    validateKey(key);
    if(validateKeyExists(key)) {
        throw new Error('Key already exists');
    }

    data[key] = value;
}

let get = (key) => {
    validateKey(key);
    if(!validateKeyExists(key)) {
        throw new Error('Key not found');
    }

    return data[key];
}

let update = (key, value) => {
    validateKey(key);
    if(!validateKeyExists(key)) {
        throw new Error('Key not found');
    }

    data[key] = value;
}

let deleteItem = (key) => {
    validateKey(key);
    if(!validateKeyExists(key)) {
        throw new Error('Key not found');
    }

    delete data[key];
}

let clear = () => {
    data = {};
}

let save = () => {
    return new Promise((resolve, reject) => {
        let dataAsString = JSON.stringify(data);

        fs.writeFile(dataFile, dataAsString, err => {
            if(err) {
                reject(err);
                return;
            }

            resolve();
        })
    })
}

let load = () => {
    return new Promise((resolve, reject) => {
        fs.readFile(dataFile, 'utf8', (err, dataJson) =>{
            if(err) {
                reject(err);
                return;
            }

            data = JSON.parse(dataJson);
            resolve();
        })
    }) 
}

module.exports = {
    put: put,
    get: get,
    update: update,
    delete: deleteItem,
    clear: clear,
    save: save,
    load: load
}