function linkStrings(input) {
    for(let line of input){
        let outputObj = {};

        let tokens = line.split(/[&\?]+/);
        for(let token of tokens){
            if(token.indexOf("=") != -1){
                let subToken = token.split("=");
                let key = subToken[0];
                let value = subToken[1];

                key = key.replace(/^\++/g, "").replace(/\++$/g, "").replace(/^(%20)+/g, "").replace(/(%20)+$/g, "");
                value = value.replace(/^\++/g, "").replace(/\++$/g, "").replace(/^(%20)+/g, "").replace(/(%20)+$/g, "");

                if(! outputObj.hasOwnProperty(key)){
                    outputObj[key] = [];
                }
                outputObj[key].push(value);
            }
        }

        for(let i of Array.from(Object.keys(outputObj))){
            let plusRegex = /\++/g;
            let anotherSpaceRegex = /(%20)+/g;
            let multispaceRegex = /\s+/g;

            if(plusRegex.exec(i) || anotherSpaceRegex.exec(i) || multispaceRegex.exec(i)) {
                let newVal = i.replace(/\++/g, " ").replace(/(%20)+/g, " ").replace(/\s+/g, " ");
                outputObj[newVal] = outputObj[i];
                delete  outputObj[i];
            }
        }

        for(let key of Object.keys(outputObj)){
            for(let i in outputObj[key]){
                outputObj[key][i] = outputObj[key][i].replace(/\++/g, " ").replace(/(%20)+/g, " ").replace(/\s+/g, " ");
            }
        }

        let outputText = "";
        Object.keys(outputObj).forEach(k => outputText+= `${k}=[${outputObj[k].join(", ")}]`);
        console.log(outputText);
    }
}
