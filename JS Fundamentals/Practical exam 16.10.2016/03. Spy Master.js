function spyMaster(input) {
    let specialKey = input.shift();
    let specialKeyChars = "";
    for(let char of specialKey){
        specialKeyChars += `[${char.toUpperCase()}${char.toLowerCase()}]`;
    }

    let specialKeyRegex = new RegExp("(^| )(" + specialKeyChars + ")(\\s+)([A-Z!%\\$#]{8,})( |,|\\.|$)", "g");

    for(let line of input){
        let match = specialKeyRegex.exec(line);
        while (match){
            let decodedMessage = match[4].toLowerCase().replace(/!/g, "1").replace(/%/g, "2").replace(/#/g, "3").replace(/\$/g, "4");
            let decoded = match[4].replace(match[4], decodedMessage);
            line = line.replace(match[0], match[1] + match[2] + match[3] + decoded + match[5]);
            match = specialKeyRegex.exec(line);
        }

        console.log(line);
    }
}
