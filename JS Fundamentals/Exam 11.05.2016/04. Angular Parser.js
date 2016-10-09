function angularParser(input) {
    let applications = {};
    let controlers = {};
    let models = {};
    let views = {};

    for(let line of input){
        if(line.startsWith("$app")){
            let tokens = line.split("=");
            let appName = tokens[1].replace("'", "").replace("'", "");
            applications[appName] = {};
        } else if(line.startsWith("$controller")){
            let tokens = line.split("'");
            let appName = tokens[3];
            let controllerName = tokens[1];
            if(! controlers[appName]){
                controlers[appName] = [];
            }
            controlers[appName].push(controllerName);
        } else if(line.startsWith("$model")){
            let tokens = line.split("'");
            let appName = tokens[3];
            let modelName = tokens[1];
            if(! models[appName]){
                models[appName] = [];
            }
            models[appName].push(modelName);
        } else if(line.startsWith("$view")){
            let tokens = line.split("'");
            let appName = tokens[3];
            let viewName = tokens[1];
            if(! views[appName]){
                views[appName] = [];
            }
            views[appName].push(viewName);
        }
    }

    for(let app of Object.keys(applications)){
        let ctrls = controlers[app] != undefined ? controlers[app].sort((a, b) => a.localeCompare(b)) : [];
        let mdls = models[app] != undefined ? models[app].sort((a, b) => a.localeCompare(b)) : [];
        let vs = views[app] != undefined ? views[app].sort((a, b) => a.localeCompare(b)) : []

        applications[app] = {
            controllers: ctrls,
            models: mdls,
            views: vs
        }
    }

    applications = sortObject(applications);
    console.log(JSON.stringify(applications));

    function sortApps(a, b) {
        if(applications[a]['controllers'].length != applications[b]['controllers'].length){
            return applications[b]['controllers'].length - applications[a]['controllers'].length;
        }
        return applications[a]['models'].length - applications[b]['models'].length;
    }

    function sortObject(obj) {
        return Object.keys(obj).sort((a, b) => sortApps(a, b)).reduce(function (result, key) {
            result[key] = obj[key];
            return result;
        }, {});
    }
}
