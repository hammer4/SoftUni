function radioCrystals(input) {

    var cut = function(x) {return x/4; };
    var lap = function(x) {return x - x * 0.2; };
    var grind = function(x) {return x - 20; };
    var etch = function(x) {return x - 2; };
    var xray = function(x)  {return x + 1; };
    var wash = function(x) {return parseInt(x);};

    input = input.map(Number);

    let desiredThickness = input[0];

    for(let i=1; i<input.length; i++) {
        let thickness = input[i];
        console.log(`Processing chunk ${thickness} microns`);

        let cuts = 0, laps = 0, grinds = 0, etchs = 0, xrays = 0;

        let previousOperation = '';
        let currentOperation = '';
        while(thickness != desiredThickness && thickness != desiredThickness - 1) {

            let newThickness = thickness;

            if(cut(thickness) < newThickness && cut(thickness) >= desiredThickness-1) {
                newThickness = cut(thickness);
            }
            if(lap(thickness) < newThickness && lap(thickness) >= desiredThickness-1) {
                newThickness = lap(thickness);
            }
            if(grind(thickness)  < newThickness && grind(thickness) >= desiredThickness-1) {
                newThickness = grind(thickness);
            }
            if(etch(thickness) < newThickness && etch(thickness) >= desiredThickness -1) {
                newThickness = etch(thickness);
            }

            switch (newThickness) {
                case cut(thickness):
                    cuts++;
                    currentOperation = 'cut';
                    thickness = cut(thickness);
                    break;
                case lap(thickness):
                    laps++;
                    currentOperation = 'lap';
                    thickness = lap(thickness);
                    break;
                case grind(thickness):
                    grinds++;
                    currentOperation = 'grind';
                    thickness = grind(thickness);
                    break;
                case etch(thickness):
                    etchs++;
                    currentOperation = 'etch';
                    thickness = etch(thickness);
                    break;
            }

            if(currentOperation != previousOperation && previousOperation != '') {
                thickness = wash(thickness);
            }
            previousOperation = currentOperation;
        }

        if(thickness == desiredThickness - 1) {
            xrays++;
        }

        if(cuts > 0) {
            console.log(`Cut x${cuts}`);
            console.log("Transporting and washing");
        }

        if(laps > 0) {
            console.log(`Lap x${laps}`);
            console.log("Transporting and washing");
        }

        if(grinds > 0) {
            console.log(`Grind x${grinds}`);
            console.log("Transporting and washing");
        }

        if(etchs > 0) {
            console.log(`Etch x${etchs}`);
            console.log("Transporting and washing");
        }

        if(xrays > 0) {
            console.log("X-ray x1");
        }

        console.log(`Finished crystal ${desiredThickness} microns`);
    }
}
