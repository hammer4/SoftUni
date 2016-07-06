<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="lines"></textarea>
    <input type="submit">
</form>
</body>
</html>

<?php
if(isset($_GET['lines']) && isset($_GET['delimiter'])) {
    $delimiter = $_GET['delimiter'];
    $lines = $_GET['lines'];

    $arr = explode($delimiter, $lines);
    $arr = array_map('trim', $arr);

    for($i = 0; $i < count($arr); $i++) {
        if($arr[$i] == "Stop") {
            break;
        }

        echo $arr[$i] . "<br>";
    }
}
?>