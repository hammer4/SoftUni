<html>
<head>

</head>
<body>
<form>
    Input: <textarea name="lines"></textarea>
    <input type="submit">
</form>
</body>
</html>

<?php
if(isset($_GET['lines'])) {
    $lines = $_GET['lines'];
    $arr = explode("\n", $lines);
    $arr = array_map('trim', $arr);
    for($i = 0; $i < count($arr); $i++) {
        if($arr[$i] == "Stop") {
            break;
        }

        echo $arr[$i] . "<br>";
    }
}
?>