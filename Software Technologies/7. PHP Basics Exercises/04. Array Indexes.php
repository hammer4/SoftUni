<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Array-size: <input type="text" name="array-size">
    Input: <textarea name="key-value-pairs"></textarea>
    <input type="submit">
</form>
</body>
</html>
<?php
if(isset($_GET['array-size'])) {
    $arraySize = $_GET['array-size'];
    $arr = array($arraySize);
    for($i = 0; $i<$arraySize; $i++) {
        $arr[$i] = 0;
    }

    if(isset($_GET['delimiter']) && isset($_GET['key-value-pairs'])) {
        $delimiter = $_GET['delimiter'];
        $pairs = explode("\n", $_GET['key-value-pairs']);
        for($i = 0; $i < count($pairs); $i++) {
            $keyValue = explode($delimiter, $pairs[$i]);
            $arr[intval($keyValue[0])] = intval($keyValue[1]);
        }
    }

    for ($i = 0; $i<count($arr); $i++) {
        echo $arr[$i] . "<br>";
    }
}
?>