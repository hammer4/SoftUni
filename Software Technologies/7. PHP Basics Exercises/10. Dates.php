<html>
<head>

</head>
<body>
<form>
    Start Date:
    <br>
    <input type="text" name="date">

    <br>
    Output Format:
    <br>
    <input type="text" name="format">
    <br>
    Commands:
    <br>
    <textarea name="commands"></textarea>
    <br>
    <input type="submit">
</form>
</body>
</html>

<?php
if(isset($_GET['date']) && isset($_GET['format']) && isset($_GET['commands'])) {
    $dateAsString = $_GET['date'];
    $date = DateTime::createFromFormat('d/m/Y', $dateAsString);
    $commands = explode("/n", $_GET['commands']);
    $commands = array_map('trim', $commands);
    foreach ($commands as $command) {
        $tokens = explode(" ", $command);
        $action = $tokens[0];
        $value = intval($tokens[1]);
        switch ($action) {
            case "add": $date->modify("+$value days"); break;
            case "subtract": $date->modify("-$value days"); break;
        }
    }

    echo $date->format($_GET['format']);
}