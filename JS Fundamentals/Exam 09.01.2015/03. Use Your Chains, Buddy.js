function useYourChainsBuddy([html]) {
    let start = html.indexOf("<p>");
    let end = html.indexOf("</p>", start + 1);
    let decryptedTextArr = [];

    while(start != -1 && end != -1){
        decryptedTextArr.push(html.substring(start + 3, end));
        start = html.indexOf("<p>", end);
        end = html.indexOf("</p>", start + 1);
    }

    let decryptedText = decryptedTextArr.join("");
    let asciiCodesArr = [];
    for(let i = 0; i<decryptedText.length; i++) {
        asciiCodesArr.push(decryptedText[i].charCodeAt(0));
        if(asciiCodesArr[i] >= 97 && asciiCodesArr[i] <= 109){
            asciiCodesArr[i] += 13;
        } else if(asciiCodesArr[i] >= 110 && asciiCodesArr[i] <= 122){
            asciiCodesArr[i] -= 13;
        } else if(asciiCodesArr[i] < 48 || asciiCodesArr[i] > 57){
            asciiCodesArr[i] = 32;
        }
    }

    let encryptedText = ""
    asciiCodesArr.forEach(ch => encryptedText += String.fromCharCode(ch));
    console.log(encryptedText.replace(/\s+/g, " "));
}
