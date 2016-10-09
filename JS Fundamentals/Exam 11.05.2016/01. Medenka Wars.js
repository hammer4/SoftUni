function medenkaWars(input) {
    let whiteDamage = 0, darkDamage = 0;
    let whiteNormalAttacks = [];
    let darkNormalAttacks = [];

    for(let line of input){
        let tokens = line.split(' ').filter(t => t != "");
        let damage = Number(tokens[0]) * 60;
        let attacker = tokens[1];

        if(attacker == 'white'){
            if(whiteNormalAttacks.length >= 1){
                if(damage == whiteNormalAttacks[whiteNormalAttacks.length - 1]){
                    damage *= 2.75;
                    whiteNormalAttacks = [];
                } else {
                    whiteNormalAttacks.push(damage);
                }
            } else {
                whiteNormalAttacks.push(damage);
            }

            whiteDamage += damage;
        } else {
            if(darkNormalAttacks.length >= 4){
                if(damage == darkNormalAttacks[darkNormalAttacks.length - 1] && damage == darkNormalAttacks[darkNormalAttacks.length - 2] && damage == darkNormalAttacks[darkNormalAttacks.length - 3] && damage == darkNormalAttacks[darkNormalAttacks.length - 4]) {
                    damage *= 4.5;
                }
            }

            darkDamage += damage;
            darkNormalAttacks.push(damage);
        }
    }

    if(whiteDamage > darkDamage) {
        console.log("Winner - Vitkor");
        console.log(`Damage - ${whiteDamage}`);
    } else {
        console.log("Winner - Naskor");
        console.log(`Damage - ${darkDamage}`);
    }
}
