function constructionCrew(worker) {
    if(worker.handsShaking){
        worker.bloodAlcoholLevel += 0.1 * worker.weight * worker.experience;
        worker.handsShaking = false;
    }
    return worker;
}
