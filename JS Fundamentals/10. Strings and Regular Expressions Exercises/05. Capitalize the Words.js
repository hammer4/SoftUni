function capitalizeTheWords([str]) {
    console.log(str.toLowerCase().split(" ").map(w => w[0].toUpperCase() + w.substr(1)).join(' '));
}