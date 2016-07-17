<?php

/**
 * Parse REQUEST_URI to extract request parts: {controller}/{action}/{params}
 * @return array holding: 'controller' (string), 'action' (string) and
 * 'params' (array of strings). When controller / action is not available,
 * returns the default controller 'home' / action 'index'.
 */
function parseRequest() : array
{
    $requestPath = $_SERVER['REQUEST_URI']; // holds /blog/home/index or /home/index
    if (substr($requestPath, 0, strlen(APP_ROOT . '/')) != APP_ROOT . '/') {
        die('APP_ROOT is incorrectly defined in config.php. Use "" or "/blog".');
    }
    $requestPath = substr($requestPath, strlen(APP_ROOT)); // remove APP_ROOT prefix
    $requestParts = explode('/', $requestPath);

    // Extract the controller from {controller}/{action}/{params}
    $controller = DEFAULT_CONTROLLER;
    if (count($requestParts) >= 2 && $requestParts[1] != '') {
        $controller = $requestParts[1];
    }

    // Extract the action from {controller}/{action}/{params}
    $action = DEFAULT_ACTION;
    if (count($requestParts) >= 3 && $requestParts[2] != '') {
        $action = $requestParts[2];
    }

    // Extract the action parameters from {controller}/{action}/{params}
    $params = array_splice($requestParts, 3);

    $requestParsed = [
        'controller' => $controller,
        'action' => $action,
        'params' => $params];
    return $requestParsed;
}

/**
 * Processes the parsed request /{controller}/{action}/{params}. Creates and
 * initializes the requested controller class, invokes the requested action
 * and renders its view.
 * @param array $requestParsed associative array holding: 'controller' (string),
 * 'action' (string) and 'params' (array of strings).
 */
function processRequest(array $requestParsed)
{
    // Create the controller class
    $controller = $requestParsed['controller'];
    $action = $requestParsed['action'];
    $controllerClassName = ucfirst(strtolower($controller)) . 'Controller';
    if (class_exists($controllerClassName)) {
        $controller = new $controllerClassName($controller, $action);
    } else {
        $controllerFileName = "controllers/" . $controllerClassName . '.php';
        die("Cannot find controller '$controller' in class '$controllerFileName'");
    }

    // Invoke the requested action and renders its view (if not rendered)
    if (method_exists($controller, $action)) {
        // Invoke $controller->{$action}($params);
        $params = $requestParsed['params'];
        call_user_func_array(array($controller, $action), $params);
        $controller->renderView();
    } else {
        die("Cannot find action '$action' in controller '$controllerClassName'");
    }
}

/**
 * Auto load the controller and model classes from their .php files.
 * @param string $class_name <p>the name of the class to load</p>
 */
function __autoload(string $class_name)
{
    if (file_exists("controllers/$class_name.php")) {
        include "controllers/$class_name.php";
    }
    if (file_exists("models/$class_name.php")) {
        include "models/$class_name.php";
    }
}

function cutLongText(string $text, int $maxSize=200, bool $htmlEscape = true) : string
{
    $append = '';
    if (strlen($text) > $maxSize) {
        $text = substr($text, 0, $maxSize);
        $append = '&hellip;';
    }
    if ($htmlEscape)
        $text = htmlspecialchars($text);
    return $text . $append;
}