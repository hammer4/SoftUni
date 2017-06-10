module.exports = {
    custIf: (a, op, b, options) => {
        if (op == '==' && a == b) return options.fn(this);
        if (op == '===' && a.toString() === b.toString()) return options.fn(this);    
        if (op == '>' && a > b) return options.fn(this);
        if (op == '<' && a < b) return options.fn(this);

        // return options.inverse(this);
    }
}