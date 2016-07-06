<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Reverse Numbers</title>
</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter" />
    Input: <textarea rows="3" name="numbers"></textarea>
    <input type="submit" value="Submit" />
</form>
<?php
if(isset($_GET['numbers']) && isset($_GET['delimiter'])) {
    $delimiter = $_GET['delimiter'];
    $lines = $_GET['numbers'];

    $arr = explode($delimiter, $lines);
    $arr = array_map('trim', $arr);

    for($i = count($arr) - 1; $i >= 0; $i--) {
        echo $arr[$i] . "<br>";
    }
}
?>
</body>
</html>