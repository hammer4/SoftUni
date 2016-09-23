function imperialUnits([inches]) {
    inches = Number(inches);
    let feet = Number.parseInt(inches/12);
    inches = inches % 12;

    console.log(`${feet}'-${inches}"`);
}
