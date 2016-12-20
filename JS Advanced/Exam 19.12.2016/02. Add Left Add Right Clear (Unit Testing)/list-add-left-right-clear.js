function makeList() { 
    let data = []; 
    return {
        addLeft: function(item) {
            data.unshift(item);
        },
        addRight: function(item) { 
            data.push(item); 
        }, 
        clear: function() { 
            data = []; 
        }, 
        toString: function() { 
            return data.join(", "); 
        } 
    }; 
} 

module.exports = makeList;