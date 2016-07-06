<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="commands"></textarea>
    <input type="submit">
</form>
</body>
</html>

<?php
$arr = [];
if(isset($_GET['delimiter']) && isset($_GET['commands'])) {
    $delimiter = $_GET['delimiter'];
    $commands = explode("\n", $_GET['commands']);

    foreach ($commands as $command) {
        $tokens = explode($delimiter, $command);
        switch ($tokens[0]) {
            case "add": $arr[] = intval($tokens[1]); break;
            case "remove": array_splice($arr, intval($tokens[1]), 1);
        }
    }

    foreach ($arr as $i) {
        echo $i . "<br>";
    }
}