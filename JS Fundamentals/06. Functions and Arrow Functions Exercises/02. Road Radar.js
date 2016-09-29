function roadRadar([speed, area]) {
    speed = Number(speed);

    function getLimit(area) {
        switch (area) {
            case "city": return 50;
            case "interstate": return 90;
            case "motorway": return 130;
            case "residential": return 20;
        }
    }

    let limit = getLimit(area);

    function getInfraction(speed, limit) {
        let overspeed = speed - limit;

        if(overspeed <= 0) {
            return false;
        } else if(overspeed > 0 && overspeed <= 20){
            return "speeding";
        } else if(overspeed > 20 && overspeed <= 40) {
            return "excessive speeding";
        } else {
            return "reckless driving";
        }
    }

    let infraction = getInfraction(speed, limit);

    if(infraction) {
        console.log(infraction);
    }
}
